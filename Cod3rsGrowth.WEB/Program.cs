using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.INFRA.Repositorio;
using Cod3rsGrowth.WEB.Exceptions;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureProblemDetailsModelState();

builder.Services.AddScoped<ServicoCarro>();
builder.Services.AddScoped<ValidadorCarro>();
builder.Services.AddScoped<IRepositorioCarro, RepositorioCarro>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
app.UseProblemDetailsExceptionHandler(factory);

app.UseDefaultFiles();

// Exemplo de como mapear seus arquivos estáticos para encontrar o i18n https://learn.microsoft.com/pt-br/aspnet/core/fundamentals/static-files?view=aspnetcore-9.0
var provider = new FileExtensionContentTypeProvider();
provider.Mappings[".properties"] = "application/x-msdownload";

app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
