using Microsoft.OpenApi;
using System.Text.Json.Serialization;
using trilha_Api_TIVIT.Infra.Interface;
using trilha_Api_TIVIT.Infra.Repositories;
using trilha_Api_TIVIT.Models;
using trilha_Api_TIVIT.Service;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers() .AddJsonOptions(options => 
{ // Converte enums para string automaticamente 
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); 
});
// OpenAPI / Swagger
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Tarefa.xml"));
    c.SwaggerDoc("v1", new()
    {
        Title = "API de Tarefas",
        Version = "v1",
        Description = "API responsável por gerenciar tarefas (CRUD + buscas)",
        Contact = new OpenApiContact
        {
            Name = "DVFWeb - Daniela",
            Url = new Uri("https://www.linkedin.com/in/danielavelteredu/")
        }
    });

    
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Authorization
builder.Services.AddAuthorization();

// REGISTRO DO SERVICE
builder.Services.AddScoped<IRepository<Tarefa>, TarefaRepository>();
builder.Services.AddScoped<TarefaService>();


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

