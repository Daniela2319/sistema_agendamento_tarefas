using trilha_Api_TIVIT.Models.Enum;
namespace trilha_Api_TIVIT.Models
{
    public class Tarefa : BaseModel
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public EnumStatusTarefa Status { get; set; }
    }
}