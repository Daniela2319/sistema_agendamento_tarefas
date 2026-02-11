using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.LoginDTO;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Service;

namespace trilha_Api_TIVIT.Controllers
{
    /// <summary>
    /// Controller responsável pela autenticação e geração de token JWT.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAuth _authService;

        /// <summary>
        /// Construtor da controller de autenticação.
        /// </summary>
        /// <param name="authService">Serviço de autenticação</param>
        public AuthController(IServiceAuth authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Realiza o login do usuário e retorna um token JWT.
        /// </summary>
        /// <param name="request">Credenciais do usuário</param>
        /// <returns>Token JWT</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginRequest request)
        {
            var token = _authService.Login(request.Email, request.Password);

            var response = new AuthLoginResponse
            {
                Token = token,
                Message = "Login realizado com sucesso"
            };

            return Ok(response);
        }
    }
}
