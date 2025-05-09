using gestorPedidos.API.Configuration;
using gestorPedidos.API.Middlewares;
using gestorPedidos.Infra.Context;
using gestorPedidos.Infra.Messaging;
using gestorPedidos.Infra.Seeds;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PedidoDistribuidorConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("pedidoDistribuidorQueue", e =>
        {
            e.ConfigureConsumer<PedidoDistribuidorConsumer>(context);
        });
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();

builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.WriteIndented = true;
    });

builder.Services.AddApplicationServices();

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

app.UseMiddleware<ErroHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
