using Microsoft.AspNetCore.Identity;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Security;

namespace trilha_Api_TIVIT.Service
{
    public class ServiceAuth
    {
        // Injetar dependência necessárias, como repositorio e serviços de hashing de senha
        private readonly RepositoryAuth _authRepository;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;

        public ServiceAuth(RepositoryAuth authRepository, PasswordHasher<Usuario> sha256PasswordHasher, TokenGenerator tokenGenerator)
        {
            _authRepository = authRepository;
            _passwordHasher = sha256PasswordHasher;
            _tokenGenerator = tokenGenerator;
            
        }
    }
}
