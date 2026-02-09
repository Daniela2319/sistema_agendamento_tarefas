namespace trilha_Api_TIVIT.DTO.TarefasDTO
{
    public class TarefaGetResponseDTO : BaseDTO
    {

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; }

        public Enum Status { get; set; } 
    }
}
