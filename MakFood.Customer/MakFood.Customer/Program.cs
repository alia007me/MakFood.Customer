using FluentValidation;
using MakFood.Customer.Application.Behavior;
using MakFood.Customer.Application.Commands.Friendship.CreateFriendship;
using MakFood.Customer.Application.Commands.Login;
using MakFood.Customer.Application.Commands.User.RegisterUser;
using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Persistence.Repository;
using MakFood.Customer.Infrastructure.Substructure.Settings;
using MakFood.Customer.JwtOptionsSetup;
using MakFood.Customer.Middelware;
using MakFood.Customer.OptionsSetup;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;



public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionStringConfiguration = builder.Configuration.GetSection(nameof(ConnectionStrings));

        builder.Services.Configure<ConnectionStrings>(connectionStringConfiguration);

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            option.OperationFilter<SecurityRequirementsOperationFilter>();
        });


        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(RegisterUserCommandHandler).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateFriendshipCommand).Assembly);
        });

        builder.Services.AddValidatorsFromAssembly(typeof(CreateFriendshipCommandValidator).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IFriendshipRepository, FriendshipRepository>();
        builder.Services.AddScoped<IJwtProvider, JwtProvider>();


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

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        builder.Services.ConfigureOptions<JwtOptionSetup>();
        builder.Services.ConfigureOptions<JwtBearerOptionSetup>();


        var app = builder.Build();
        app.UseRouting();

        app.UseAuthentication();

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
    }
}