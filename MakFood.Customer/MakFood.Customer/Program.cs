using MakFood.Customer.Application.Commands.RegisterUser;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Persistence.Repository;
using MakFood.Customer.Infrastructure.Substructure.Settings;
using MassTransit;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionStringConfiguration = builder.Configuration.GetSection(nameof(ConnectionStrings));

builder.Services.Configure<ConnectionStrings>(connectionStringConfiguration);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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



var app = builder.Build();
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});





app.Run();
