using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Infra.Repositories
{
    public class RepositoryTarefa : RepositoryInDbSQLServer
    {
        public RepositoryTarefa(ApplicationDbContext context) : base(context)
        {
        }
    }
}