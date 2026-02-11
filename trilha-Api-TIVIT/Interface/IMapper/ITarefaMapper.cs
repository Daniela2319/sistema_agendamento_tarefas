using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Interface.IMapper
{
    public interface ITarefaMapper
    {
        Tarefa ToModel(TarefaPostRequestDTO dto);
        void ToModelPut(Tarefa model, TarefaPutRequestDTO dto);
        TarefaGetResponseDTO ToResponse(Tarefa model);
        List<TarefaGetResponseDTO> ToResponseList(List<Tarefa> models);
    }
}
