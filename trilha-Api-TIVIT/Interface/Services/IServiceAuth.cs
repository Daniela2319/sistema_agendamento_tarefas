using trilha_Api_TIVIT.Interface.Repo;

namespace trilha_Api_TIVIT.Interface.Services
{
    public interface IServiceAuth
    {
        string Login(string email, string password);
    }
}
