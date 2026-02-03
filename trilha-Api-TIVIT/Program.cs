
using System.Text.Json.Serialization;
using trilha_Api_TIVIT.Extensions;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Interface.Repo;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers() .AddJsonOptions(options => 
{ // Converte enums para string automaticamente 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
});

builder.Services.AddSwaggerGen();

// Carrega User Secrets em desenvolvimento
if (builder.Environment.IsDevelopment()) 
{ builder.Configuration.AddUserSecrets<Program>(); }

// Chama a extensão para configurar o banco
builder.Services.AddDatabaseConfiguration(builder.Configuration, builder.Environment);

// Configuração do Swagger
builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllers();

// Authorization
builder.Services.AddAuthorization();

// REGISTRO DO SERVICE
builder.Services.AddScoped<IRepository<Tarefa>, RepositoryTarefa>();
builder.Services.AddScoped<TarefaService>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowReact");

app.MapControllers();

app.Run();

