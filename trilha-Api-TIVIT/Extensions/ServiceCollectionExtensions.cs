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
                // Local - Azure SQL Edge
                connectionString = configuration.GetConnectionString("LocalConnection");
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
