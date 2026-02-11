using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using trilha_Api_TIVIT.Extensions;
using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers() 
    .AddJsonOptions(options => 
    { // Converte enums para string automaticamente 
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
    });

builder.Services.AddSwaggerGen();

// Carrega User Secrets em desenvolvimento
if (builder.Environment.IsDevelopment()) 
{ builder.Configuration.AddUserSecrets<Program>(); }

// Chama a extensão para configurar o banco
builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment);

// Autentificação JWT
builder.Services.AddAuthenticationConfiguration(builder.Configuration);

// Configuração do Swagger
builder.Services.AddSwaggerDocumentation();


// Authorization
builder.Services.AddAuthorization();

// REGISTRO DO SERVICE
builder.Services.AddProjectServices();

// Cors
builder.Services.AddLocalCors();

var app = builder.Build();

// Aplica as migrations automaticamente ao iniciar a aplicação para docker
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

//    try
//    {
//        db.Database.Migrate();
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Erro ao aplicar migrations: {ex.Message}");
//        throw;
//    }
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowReactLocal");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

