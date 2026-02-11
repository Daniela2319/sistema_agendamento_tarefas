namespace trilha_Api_TIVIT.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
