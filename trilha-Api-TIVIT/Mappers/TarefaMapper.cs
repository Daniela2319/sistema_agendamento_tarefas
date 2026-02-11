using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.Interface.IMapper;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Mappers
{
    public class TarefaMapper : ITarefaMapper
    {
        // Model => DTO (resposta)
        public TarefaGetResponseDTO ToResponse(Tarefa model)
        {
            return new TarefaGetResponseDTO
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataCriacao = model.DataCriacao,
                Status = model.Status 
            };
        }

        // Model → DTO (lista)
        public List<TarefaGetResponseDTO> ToResponseList(List<Tarefa> tarefas)
        {
            return tarefas.Select(ToResponse).ToList();
        }

        // DTO => Model (entrada ou pergunta request)
        public Tarefa ToModel(TarefaPostRequestDTO request)
        {
            return new Tarefa
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                
            };
        }

        // Put
        public void ToModelPut(Tarefa tarefa, TarefaPutRequestDTO dto)
        {
            tarefa.Id = dto.Id;
            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Status = dto.Status;
        }
    }
}
