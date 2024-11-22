using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EnergyKids.Data;
using EnergyKids.Services;
using EnergyKids.Repositories.Interfaces;
using EnergyKids.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configuração do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the database connection using the connection string in appsettings.json
builder.Services.AddDbContext<DataContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


builder.Services.AddScoped<DicasService>();
builder.Services.AddScoped<EstimativaConsumoService>();
builder.Services.AddScoped<GeradorDicasService>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseDeveloperExceptionPage();

    // Ativa o Swagger somente em desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
