using ConsumeGitHubAPI.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>(); // Criar apenas uma instância do serviço durante o ciclo de vida da aplicação
builder.Services.AddScoped<GitHubController>();

// Adiciona serialização JSON
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Adiciona HttpClient para consumir APIs
builder.Services.AddHttpClient();

// Adiciona o explorador da API para documentação dos endpoints
builder.Services.AddEndpointsApiExplorer();

// Configura o Swagger para gerar documentação
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GitHub API",
        Version = "v1",
        Description = "Uma API construída para consumir a API do GitHub de forma personalizada.",
        Contact = new OpenApiContact
        {
            Name = "Luigi Ferronatto",
            Email = "luigi_ferronatto@hotmail.com"
        }
    });
});

// Adiciona AWS Lambda Hosting
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

var app = builder.Build();

// Habilita o Swagger apenas em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Repositories GitHub - V1");
    });
}

// Habilita o redirecionamento HTTPS
app.UseHttpsRedirection();

// Mapeia os controladores
app.MapControllers();

app.Run();
