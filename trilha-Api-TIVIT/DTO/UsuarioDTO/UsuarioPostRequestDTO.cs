using System.ComponentModel.DataAnnotations;

namespace trilha_Api_TIVIT.DTO.UsuarioDTO
{
    public class UsuarioPostRequestDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email está em um formato inválido")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Senha deve ter no mínimo 3 caracteres.")]
        public string Password { get; set; } = string.Empty;
        
       
    }
}
