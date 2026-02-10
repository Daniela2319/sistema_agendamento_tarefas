using System.ComponentModel.DataAnnotations;

namespace trilha_Api_TIVIT.DTO.UsuarioDTO
{
    public class UsuarioPutRequestDTO : BaseDTO
    {
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Senha deve ter no mínimo 3 caracteres")]
        public string Password { get; set; } = string.Empty;
    }
}
