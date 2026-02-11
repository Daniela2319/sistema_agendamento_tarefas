using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Interface.IMapper;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Mappers
{
    public class UsuarioMapper : IUsuarioMapper
    {
        public UsuarioGetResponseDTO ToResponse(Usuario usuario)
        {
            return new UsuarioGetResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
        }

        public List<UsuarioGetResponseDTO> ToResponseList(List<Usuario> usuarioList)
        {
            return usuarioList.Select(ToResponse).ToList();
        }

        public Usuario ToModel(UsuarioPostRequestDTO request)
        {
            return new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Password = request.Password
            };

        }

        // Put
        public void ToModelPut(Usuario usuario, UsuarioPutRequestDTO dto)
        {
            usuario.Id = dto.Id;
            usuario.Password = dto.Password;
        }

    }
}
