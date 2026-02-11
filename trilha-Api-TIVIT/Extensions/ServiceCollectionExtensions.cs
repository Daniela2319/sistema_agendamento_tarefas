using Microsoft.EntityFrameworkCore;
using trilha_Api_TIVIT.Infra.Context;

namespace trilha_Api_TIVIT.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            string connectionString;

            if (environment.IsDevelopment())
            {
                // Ambiente local (user-secrets ou appsettings)
                connectionString = configuration.GetConnectionString("LocalConnection");
            }
            else if (environment.IsEnvironment("Docker"))
            {
                // Ambiente Docker
                connectionString = configuration.GetConnectionString("DockerConnection");
            }
            else
            {
                // Produção - Azure SQL Database
                connectionString = configuration.GetConnectionString("AzureConnection");
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
