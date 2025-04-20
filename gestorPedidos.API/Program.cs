using gestorPedidos.Application.Interfaces;
using gestorPedidos.Application.Services;
using gestorPedidos.Infra.Context;
using gestorPedidos.Infra.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddScoped<IPedidoService, PedidoService>();

builder.Services.AddDbContext<GestorPedidosDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Inicializa o banco de dados com dados de seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<GestorPedidosDbContext>();
    context.Database.Migrate();
    SeedData.Initialize(services, context);
}

var enableSwagger = builder.Configuration.GetValue<bool>("EnableSwagger");

if (enableSwagger)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
