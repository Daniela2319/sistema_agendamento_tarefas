namespace trilha_Api_TIVIT.Security
{
    public class TokenConfiguration
    {
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Secret { get; set; } = string.Empty;
    }
}
