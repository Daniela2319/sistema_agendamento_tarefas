using System.ComponentModel.DataAnnotations;

namespace trilha_Api_TIVIT.DTO.TarefasDTO
{
    public class TarefaPostRequestDTO
    {
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 500 caracteres.")]
        public string Descricao { get; set; } = string.Empty;
        
    }
}
