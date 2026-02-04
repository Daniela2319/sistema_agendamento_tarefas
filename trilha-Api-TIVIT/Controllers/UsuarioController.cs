using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            var user = _usuarioService.Read();
            return Ok(user);
        }

        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario user = _usuarioService.ReadById(id);
            return Ok(user);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            var id = _usuarioService.Create(usuario);
            return CreatedAtAction(nameof(GetById), new { id = id }, usuario);
        }

        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario usuario)
        {
            _usuarioService.Update(usuario);
            return Ok();
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
