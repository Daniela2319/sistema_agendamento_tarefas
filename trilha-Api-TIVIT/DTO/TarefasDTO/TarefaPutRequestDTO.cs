using trilha_Api_TIVIT.Models.Enum;

namespace trilha_Api_TIVIT.DTO.TarefasDTO
{
    public class TarefaPutRequestDTO : BaseDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public EnumStatusTarefa Status { get; set; }
    }
}
