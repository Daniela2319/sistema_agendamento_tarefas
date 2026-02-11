using Microsoft.AspNetCore.Identity;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Models;

namespace trilha_Api_TIVIT.Service
{
    public class ServiceUsuario : ServiceGeneric<Usuario>, IUsuarioService
    {
        private readonly PasswordHasher<Usuario> _passwordHasher;
        public ServiceUsuario(IRepository<Usuario> repository, PasswordHasher<Usuario> passwordHasher) : base(repository)
        {
            _passwordHasher = passwordHasher;
        }

        public override int Create(Usuario model)
        {
            if (model.Password.Length < 3)
                throw new ArgumentException("A senha deve ter no mínimo 3 caracteres.");

            model.Password = _passwordHasher.HashPassword(model, model.Password);
            return base.Create(model);
        }

        public override void Update(Usuario model)
        {
            Usuario existingUser = ReadById(model.Id);
            if (existingUser != null)
            {
                model.Email = existingUser.Email; // Evita alterar o email
                model.Nome = existingUser.Nome; // Evita alterar o PersonId
                model.Password = _passwordHasher.HashPassword(model, model.Password); // Atualiza a senha com hash
            }
            base.Update(model);
        }
    }
}
