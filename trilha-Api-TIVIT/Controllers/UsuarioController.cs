using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Mappers;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Service;


namespace trilha_Api_TIVIT.Controllers
    {/// <summary>
     /// Controller responsável pelo gerenciamento de usuários do sistema.
     /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServiceUsuario _usuarioService;

        /// <summary>
        /// Construtor da controller de usuário.
        /// </summary>
        /// <param name="usuarioService">Serviço de regras de negócio do usuário</param>
        public UsuarioController(ServiceUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.Read();
            var response = UsuarioMapper.ToResponseList(usuarios);
            return Ok(response);
        }

        /// <summary>
        /// Retorna um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Usuário encontrado</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Usuario usuario = _usuarioService.ReadById(id);
            var response = UsuarioMapper.ToResponse(usuario);
            return Ok(response);
        }

        /// <summary>
        /// Cria um novo usuário no sistema.
        /// </summary>
        /// <param name="request">Dados do usuário para criação</param>
        /// <returns>Usuário criado</returns>
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioPostRequestDTO request)
        {
           
            var model = UsuarioMapper.ToModel(request);
            var id = _usuarioService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = id }, UsuarioMapper.ToResponse(model));
        }

        /// <summary>
        /// Atualiza a senha de um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="request">Dados para atualização</param>
        /// <returns>Sem conteúdo</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UsuarioPutRequestDTO request)
        {
            var usuario = _usuarioService.ReadById(id);

            UsuarioMapper.ToModelPut(usuario, request);
              _usuarioService.Update(usuario);
              return NoContent();
        }

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <returns>Sem conteúdo</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioService.Delete(id);
            return NoContent();
              
        }
    }
}
