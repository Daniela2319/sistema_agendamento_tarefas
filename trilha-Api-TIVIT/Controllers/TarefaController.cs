using Microsoft.AspNetCore.Mvc;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Models.Enum;
using trilha_Api_TIVIT.Service;

namespace trilha_Api_TIVIT.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController(TarefaService tarefaService) : ControllerBase
    {
        private readonly TarefaService _tarefaService = tarefaService;

        /// <summary>
        /// Retorna todas as tarefas cadastradas.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            var tarefas = _tarefaService.Read();
            return Ok(tarefas);
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
                var tarefa = _tarefaService.ReadById(id);
                return Ok(tarefa);
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
        public IActionResult Post([FromBody] Tarefa tarefa)
        {
            var id = _tarefaService.Create(tarefa);
            return CreatedAtAction(nameof(GetById), new { id = id }, tarefa);
        }

        /// <summary>
        /// Busca tarefas pelo título.
        /// </summary>
        /// <param name="titulo">Texto a ser buscado no título da tarefa</param>
        [HttpGet("buscarPorTitulo")]
        public IActionResult BuscarPorTitulo(string titulo)
        {
            var tarefas = _tarefaService.BuscarPorTitulo(titulo);
            return Ok(tarefas);
        }

        /// <summary>
        /// Busca tarefas pela data de criação.
        /// </summary>
        /// <param name="dataCriacao">Data de criação da tarefa</param>
        [HttpGet("buscarPorDataCriacao")]
        public IActionResult BuscarPorDataCriacao(DateTime dataCriacao)
        {
            var tarefas = _tarefaService.BuscarPorDataCriacao(dataCriacao);
            return Ok(tarefas);
        }

        /// <summary>
        /// Busca tarefas pelo status.
        /// </summary>
        /// <param name="status">Status da tarefa (Pendente, Concluída, EmAndamento)</param>
        [HttpGet("buscarPorStatus")]
        public IActionResult BuscarPorStatus(EnumStatusTarefa status)
        {
            var tarefas = _tarefaService.BuscarPorStatus(status);
            return Ok(tarefas);
        }

        /// <summary>
        /// Atualiza uma tarefa existente.
        /// </summary>
        /// <param name="id">ID da tarefa</param>
        /// <param name="tarefa">Objeto tarefa atualizado</param>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tarefa tarefa)
        {
            if (id != tarefa.Id)
            {
                return BadRequest("ID da tarefa não corresponde ao ID da URL.");
            }

            try
            {
                _tarefaService.Update(tarefa);
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
            var tarefa = _tarefaService.ReadById(id);
            if (tarefa == null) return NotFound();
            tarefa.Status = EnumStatusTarefa.Finalizado;
            _tarefaService.Update(tarefa);
            return Ok(tarefa);
        }

    }
}
