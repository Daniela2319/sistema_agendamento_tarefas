
namespace trilha_Api_TIVIT.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public override string ToString()
        {
            return $"{this.Id} - {this.DataCriacao}";
        }
    }
}