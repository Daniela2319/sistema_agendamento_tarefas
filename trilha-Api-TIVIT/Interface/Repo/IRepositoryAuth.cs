using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Interface.Repo
{
    public interface IRepositoryAuth
    {
        Usuario GetUserByEmail(string email);
    }
}
