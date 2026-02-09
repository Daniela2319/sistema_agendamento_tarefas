using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.Mappers;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;
using trilha_Api_TIVIT.Service;

namespace trilha_Api_TIVIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TarefaController : ControllerBase
    {
        private readonly ServiceTarefa _tarefaService;

        public TarefaController(ServiceTarefa serviceTarefa)
        {
            _tarefaService = serviceTarefa;
        }

        /// <summary>
        /// Retorna todas as tarefas cadastradas.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var tarefa = _tarefaService.Read();
            List<Tarefa> Tarefas = new List<Tarefa>();
            var response = TarefaMapper.ToResponseList(Tarefas);
            
            return Ok(response);
        }

        /// <summary>
        /// Retorna uma tarefa pelo ID.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Tarefa model = _tarefaService.ReadById(id);
                var response = new TarefaGetResponseDTO
                {
                    Id = model.Id,
                    Titulo = model.Titulo,
                    Descricao = model.Descricao,
                    DataCriacao = model.DataCriacao,
                    Status = model.Status,
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Cria uma nova tarefa.
        /// </summary>
        /// <param name="tarefa">Objeto tarefa enviado no corpo da requisição</param>
        [HttpPost]
        public IActionResult Post([FromBody] TarefaPostRequestDTO request)
        {
            Tarefa model = new Tarefa
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
            };
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
            try
            {

                var tarefas = _tarefaService.BuscarPorTitulo(titulo);
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Busca tarefas pela data de criação.
        /// </summary>
        /// <param name="dataCriacao">Data de criação da tarefa</param>
        [HttpGet("buscarPorDataCriacao")]
        public IActionResult BuscarPorDataCriacao(DateTime dataCriacao)
        {
            try
            {
                var tarefas = _tarefaService.BuscarPorDataCriacao(dataCriacao);
                return Ok(tarefas);

            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Busca tarefas pelo status.
        /// </summary>
        /// <param name="status">Status da tarefa (Pendente, Concluída, EmAndamento)</param>
        [HttpGet("buscarPorStatus")]
        public IActionResult BuscarPorStatus(EnumStatusTarefa status)
        {
            try
            {
                var tarefas = _tarefaService.BuscarPorStatus(status);
                return Ok(tarefas);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        /// <param name="tarefa">Objeto tarefa atualizado</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TarefaPostRequestDTO request)
        {
            try
            {
                Tarefa model = new Tarefa
                {
                    Id = id,
                    Titulo = request.Titulo,
                    Descricao = request.Descricao,

                };
                _tarefaService.Update(model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
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
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("{id}/finalizar")]
        public IActionResult Finalizar(int id)
        {  
            try
            {
                var tarefa = _tarefaService.ReadById(id);
                if (tarefa == null) return NotFound();
                tarefa.Status = EnumStatusTarefa.Finalizado;
                _tarefaService.Update(tarefa);
                return Ok(tarefa);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); 
            }
        }

    }
}
