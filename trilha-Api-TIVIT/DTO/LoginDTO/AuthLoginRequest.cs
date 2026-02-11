using System.ComponentModel.DataAnnotations;

namespace trilha_Api_TIVIT.DTO.LoginDTO
{
    public class AuthLoginRequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail deve ser um endereço de e-mail válido.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [MinLength(3, ErrorMessage = "O campo Senha deve ter no mínimo 3 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
