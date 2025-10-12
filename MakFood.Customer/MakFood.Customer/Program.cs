using MakFood.Customer.Infrastructure.Persistence.Context;
using MakFood.Customer.Infrastructure.Substructure.Settings;
using MakFood.Customer.Middelware;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionStringConfiguration = builder.Configuration.GetSection(nameof(ConnectionStrings));
builder.Services.Configure<ConnectionStrings>(connectionStringConfiguration);

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    var connectionString = connectionStringConfiguration.Get<ConnectionStrings>()!;

    var connectionBuilder = new SqlConnectionStringBuilder
    {
        DataSource = connectionString.Server,
        InitialCatalog = connectionString.InitialCatalog,
        TrustServerCertificate = true,
        IntegratedSecurity = true
    };

    options.UseSqlServer(connectionBuilder.ConnectionString);
});

builder.Services.AddMassTransit(c =>
{
    c.UsingRabbitMq((context, configuration) =>
    {
        configuration.Host(new Uri($"amqp://guest:guest@127.0.0.1:5672"));
        configuration.ReceiveEndpoint("RegisterUsers", c => { });
    });
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddelware>();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerUI(options =>
{
    options.EnableTryItOutByDefault();
});


app.Run();
