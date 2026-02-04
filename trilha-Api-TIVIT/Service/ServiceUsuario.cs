using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Service
{
    public class ServiceUsuario : ServiceGeneric<Usuario>
    {
        public ServiceUsuario(IRepository<Usuario> repository) : base(repository)
        {
        }

        public override void Update(Usuario model)
        {
        }
    }
}
