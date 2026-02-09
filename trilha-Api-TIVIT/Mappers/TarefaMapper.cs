using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Mappers
{
    public static class TarefaMapper
    {
        // Model => DTO (resposta)
        public static TarefaGetResponseDTO ToResponse(Tarefa model)
        {
            return new TarefaGetResponseDTO
            {
                Id = model.Id,
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                DataCriacao = model.DataCriacao,
                Status = model.Status,
            };
        }

        // Model → DTO (lista)
        public static List<TarefaGetResponseDTO> ToResponseList(List<Tarefa> tarefas)
        {
            return tarefas.Select(ToResponse).ToList();
        }

        // DTO => Model (entrada ou pergunta request)
        public static Tarefa ToModel(TarefaPostRequestDTO request)
        {
            return new Tarefa
            {
                Titulo = request.Titulo,
                Descricao = request.Descricao,
            };
        }
    }
}
