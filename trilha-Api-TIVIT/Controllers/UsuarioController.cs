using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Interface.IMapper;
using trilha_Api_TIVIT.Interface.Services;
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
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioMapper _usuarioMapper;

        /// <summary>
        /// Construtor da controller de usuário.
        /// </summary>
        /// <param name="usuarioService">Serviço de regras de negócio do usuário</param>
        /// <param name="usuarioMapper"></param>
        public UsuarioController(IUsuarioService usuarioService, IUsuarioMapper usuarioMapper)
        {
            _usuarioService = usuarioService;
            _usuarioMapper = usuarioMapper;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _usuarioService.Read();
            var response = _usuarioMapper.ToResponseList(usuarios);
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
            var response = _usuarioMapper.ToResponse(usuario);
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
           
            var model = _usuarioMapper.ToModel(request);
            var id = _usuarioService.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = id }, _usuarioMapper.ToResponse(model));
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

            _usuarioMapper.ToModelPut(usuario, request);
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
            try
            {
                _usuarioService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
