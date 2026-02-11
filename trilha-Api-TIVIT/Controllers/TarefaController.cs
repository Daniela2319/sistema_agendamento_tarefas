using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.Interface.IMapper;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Models.Enum;


namespace trilha_Api_TIVIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        private readonly ITarefaMapper _tarefaMapper;

        public TarefaController(ITarefaService tarefaService, ITarefaMapper tarefaMapper)
        {
            _tarefaService = tarefaService;
            _tarefaMapper = tarefaMapper;
        }

        /// <summary>
        /// Retorna todas as tarefas cadastradas.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var tarefas = _tarefaService.Read();
            var response = _tarefaMapper.ToResponseList(tarefas);
            
            return Ok(response);
        }

        /// <summary>
        /// Retorna uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = _tarefaService.ReadById(id);
            var response = _tarefaMapper.ToResponse(tarefa);
            return Ok(response);
          
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="request">Objeto tarefa enviado no corpo da requisição</param>
        [HttpPost]
        public IActionResult Post([FromBody] TarefaPostRequestDTO request)
        {
            var model = _tarefaMapper.ToModel(request);
            _tarefaService.Create(model);
            return Created();
        }

        /// <summary>
        /// Busca tarefas pelo título.
        /// </summary>
        /// <param name="titulo">Texto a ser buscado no título da tarefa</param>
        [HttpGet("buscarPorTitulo")]
        public IActionResult BuscarPorTitulo(string titulo)
        {
           var tarefas = _tarefaService.BuscarPorTitulo(titulo);
            var response = _tarefaMapper.ToResponseList(tarefas);
            return Ok(response);
        }

        /// <summary>
        /// Busca tarefas pela data de criação.
        /// </summary>
        /// <param name="dataCriacao">Data de criação da tarefa</param>
        [HttpGet("buscarPorDataCriacao")]
        public IActionResult BuscarPorDataCriacao(DateTime dataCriacao)
        {
            var tarefas = _tarefaService.BuscarPorDataCriacao(dataCriacao);
             var response = _tarefaMapper.ToResponseList(tarefas);
            return Ok(response);
        }

        /// <summary>
        /// Busca tarefas pelo status.
        /// </summary>
        /// <param name="status">Status da tarefa (Pendente, Concluída, EmAndamento)</param>
        [HttpGet("buscarPorStatus")]
        public IActionResult BuscarPorStatus(EnumStatusTarefa status)
        {
           var tarefas = _tarefaService.BuscarPorStatus(status);
            var response = _tarefaMapper.ToResponseList(tarefas);
            return Ok(response);
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        /// <param name="request">Objeto tarefa atualizado</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TarefaPutRequestDTO request)
        {
            var tarefa = _tarefaService.ReadById(id);

            if (tarefa == null)
                return NotFound("Tarefa não encontrada");

            // Mapper atualiza o model
            _tarefaMapper.ToModelPut(tarefa, request);

            _tarefaService.Update(tarefa);

            return Ok(_tarefaMapper.ToResponse(tarefa));
        }

        /// <summary>
        /// Exclui uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _tarefaService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        
        [HttpPatch("{id}/finalizar")]
        public IActionResult Finalizar(int id)
        {
            _tarefaService.Finalizar(id);
            return NoContent();
        }


    }
}
