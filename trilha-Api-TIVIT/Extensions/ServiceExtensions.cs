using Microsoft.AspNetCore.Identity;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Interface.IMapper;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Interface.Services;
using trilha_Api_TIVIT.Mappers;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Security;
using trilha_Api_TIVIT.Service;

namespace trilha_Api_TIVIT.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        { // Repositórios
            services.AddScoped(typeof(IRepository<Tarefa>), typeof(RepositoryGeneric<Tarefa>)); 
            services.AddScoped(typeof(IRepository<Usuario>), typeof(RepositoryGeneric<Usuario>)); 
            services.AddScoped<IRepositoryAuth, RepositoryAuth>();

            // Serviços
            services.AddScoped<ITarefaService, ServiceTarefa>();
            services.AddScoped<IUsuarioMapper, UsuarioMapper>();
            services.AddScoped<ITarefaMapper, TarefaMapper>();
            services.AddScoped<IUsuarioService, ServiceUsuario>();
            services.AddScoped<IServiceAuth, ServiceAuth>();


            // Utilitários
            services.AddScoped<TokenGenerator, TokenGenerator>(); 
            services.AddScoped<PasswordHasher<Usuario>>(); 
            return services; 
        }
        
    }
}
