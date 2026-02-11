namespace trilha_Api_TIVIT.Extensions
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddLocalCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("AllowReactLocal",
                    policy => policy
                    .WithOrigins("http://localhost:3000", "http://localhost:5173") 
                    .AllowAnyMethod() 
                    .AllowAnyHeader()
                ); 
            }); 
            return services; 
        }
    }
}
