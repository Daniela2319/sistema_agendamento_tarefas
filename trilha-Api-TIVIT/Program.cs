
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using trilha_Api_TIVIT.Extensions;
using trilha_Api_TIVIT.Infra.Context;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Middlewares;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Security;
using trilha_Api_TIVIT.Service;

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
builder.Services.AddScoped(typeof(IRepository<Tarefa>), typeof(RepositoryGeneric<Tarefa>));
builder.Services.AddScoped(typeof(IRepository<Usuario>), typeof(RepositoryGeneric<Usuario>));
builder.Services.AddScoped<RepositoryAuth>();
builder.Services.AddScoped<ServiceTarefa>();
builder.Services.AddScoped<ServiceUsuario>();
builder.Services.AddScoped<ServiceAuth>();
builder.Services.AddScoped<TokenGenerator, TokenGenerator>();
builder.Services.AddScoped<PasswordHasher<Usuario>>();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Aplica as migrations automaticamente ao iniciar a aplicação
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    try
    {
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrations: {ex.Message}");
        throw;
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowReact");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

