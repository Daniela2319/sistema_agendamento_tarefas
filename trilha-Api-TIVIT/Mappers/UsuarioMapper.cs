using trilha_Api_TIVIT.DTO.TarefasDTO;
using trilha_Api_TIVIT.DTO.UsuarioDTO;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioGetResponseDTO ToResponse(Usuario usuario)
        {
            return new UsuarioGetResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
            };
        }

        public static List<UsuarioGetResponseDTO> ToResponseList(List<Usuario> usuarioList)
        {
            return usuarioList.Select(ToResponse).ToList();
        }

        public static Usuario ToModel(UsuarioPostRequestDTO request)
        {
            return new Usuario
            {
                Nome = request.Nome,
                Email = request.Email,
                Password = request.Password
            };

        }

        // Put
        public static void ToModelPut(Usuario usuario, UsuarioPutRequestDTO dto)
        {
            usuario.Id = dto.Id;
            usuario.Password = dto.Password;
        }

    }
}
