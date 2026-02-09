using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Service;


namespace trilha_Api_TIVIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServiceUsuario _usuarioService;

        public UsuarioController(ServiceUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Usuario> usuarios = _usuarioService.Read();
            List<UsuarioGetResponseDTO> listDto = new List<UsuarioGetResponseDTO>();
            foreach (Usuario user in usuarios)
            {
                listDto.Add(new UsuarioGetResponseDTO
                {
                    Id = user.Id,
                    Nome = user.Nome,
                    Email = user.Email

                });
            }
            return Ok(listDto);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario user = _usuarioService.ReadById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioPostRequestDTO modelDTO)
        {
            Usuario model = new Usuario
            {
                Nome = modelDTO.Nome,
                Email = modelDTO.Email,
                Password = modelDTO.Password,
            };

            var id = _usuarioService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioPutRequestDTO request)
        {
            Usuario model = new Usuario
            {
                Id = request.Id,
                Password = request.Password

            };
              _usuarioService.Update(model);
              return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
