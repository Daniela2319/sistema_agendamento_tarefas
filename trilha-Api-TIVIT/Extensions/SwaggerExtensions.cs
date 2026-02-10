using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace trilha_Api_TIVIT.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            { // Inclui comentários XML
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath); // Configuração do SwaggerDoc
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "API de Tarefas",
                    Version = "v1",
                    Description = "API responsável por gerenciar tarefas (CRUD + buscas)",
                    Contact = new OpenApiContact { Name = "DVFWeb - Daniela",
                        Url = new Uri("https://www.linkedin.com/in/danielavelteredu/")
                    }
                });

                // Esquema JWT Bearer
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Digite: Bearer {seu_token}",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer", // IMPORTANTE
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securityScheme, new string[] { }
                    }
                };

                c.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }
    } 
}
