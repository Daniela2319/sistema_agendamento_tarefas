using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Infra.Repositories
{
    public class RepositoryAuth : IRepositoryAuth

    {
        private readonly ApplicationDbContext _context;

        public RepositoryAuth(ApplicationDbContext context)
        {
            _context = context;
        }

        public Usuario? GetUserByEmail(string email)
        {
            var usuario = _context.usuarios.FirstOrDefault(u => u.Email == email);
            return usuario;
        }
    }
}
