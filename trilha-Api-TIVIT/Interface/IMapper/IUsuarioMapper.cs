using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Interface.IMapper
{
    public interface IUsuarioMapper
    {
        Usuario ToModel(UsuarioPostRequestDTO dto);
        void ToModelPut(Usuario model, UsuarioPutRequestDTO dto);
        UsuarioGetResponseDTO ToResponse(Usuario model);
        List<UsuarioGetResponseDTO> ToResponseList(List<Usuario> models);
    }
}
