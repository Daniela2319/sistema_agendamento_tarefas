namespace trilha_Api_TIVIT.Models
{
    public class Usuario : BaseModel
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
