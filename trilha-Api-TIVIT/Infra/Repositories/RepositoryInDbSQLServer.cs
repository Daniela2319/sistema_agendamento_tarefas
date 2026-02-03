using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Infra.Repositories
{
    public class RepositoryInDbSQLServer : RepositoryGeneric<Tarefa>
    {
        public RepositoryInDbSQLServer(ApplicationDbContext context) : base(context)
        {
        }
    }
}
