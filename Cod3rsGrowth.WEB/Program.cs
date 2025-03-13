using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.INFRA.Repositorio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ServicoCarro>();
builder.Services.AddScoped<ValidadorCarro>();
builder.Services.AddScoped<IRepositorioCarro, RepositorioCarro>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
