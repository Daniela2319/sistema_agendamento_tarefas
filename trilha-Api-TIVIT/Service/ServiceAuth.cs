using Microsoft.AspNetCore.Identity;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Security;

namespace trilha_Api_TIVIT.Service
{
    public class ServiceAuth : IServiceAuth 
    {
        // Injetar dependência necessárias, como repositorio e serviços de hash de senha
        private readonly IRepositoryAuth _authRepository;
        private readonly PasswordHasher<Usuario> _passwordHasher;
        private readonly TokenGenerator _tokenGenerator;
        

        public ServiceAuth(IRepositoryAuth authRepository, PasswordHasher<Usuario> sha256PasswordHasher, TokenGenerator tokenGenerator)
        {
            _authRepository = authRepository;
            _passwordHasher = sha256PasswordHasher;
            _tokenGenerator = tokenGenerator;  
        }

        // Login
        public string Login(string email, string password)
        {
            var model = _authRepository.GetUserByEmail(email);
            if (model == null)
                throw new UnauthorizedAccessException("Usuário não encontrado.");

            var result = _passwordHasher.HashPassword(model, password);
                return _tokenGenerator.GenerateToken(model);
        }

    }
}
            

        
