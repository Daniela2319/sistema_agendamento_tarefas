using trilha_Api_TIVIT.Infra.Context;

namespace trilha_Api_TIVIT.Infra.Repositories
{
    public class RepositoryUsuario : RepositoryInDbSQLServer
    {
        public RepositoryUsuario(ApplicationDbContext context) : base(context)
        {
        }
    }
}
