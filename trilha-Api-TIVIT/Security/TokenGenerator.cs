using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Security
{
    public class TokenGenerator
    {
        private readonly TokenConfiguration _tokenConfiguration;

        public TokenGenerator(IOptions<TokenConfiguration> tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration.Value;
        }

        public string GenerateToken(Usuario model)
        {
            var claims = new List<Claim>
            {
                new Claim("Nome", model.Nome),
                new Claim("Email", model.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(2);

            // ===== Gera o token =====
            var token = new JwtSecurityToken(
                issuer: _tokenConfiguration.Issuer,
                audience: _tokenConfiguration.Audience,
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
            var tokenHandler = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenHandler;
        }
    }
}
