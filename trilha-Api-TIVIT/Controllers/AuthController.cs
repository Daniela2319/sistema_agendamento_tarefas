using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.LoginDTO;
using trilha_Api_TIVIT.Service;

namespace trilha_Api_TIVIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ServiceAuth _authService;

        public AuthController(ServiceAuth authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginRequest request)
        {
            try
            {
                string retorno = _authService.Login(request.Email, request.Password);
                AuthLoginResponse response = new AuthLoginResponse();
                response.Token = retorno;
                response.Message = "Login realizado com sucesso";
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
               
        }
    }
}
