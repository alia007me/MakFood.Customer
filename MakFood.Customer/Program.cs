using MakFood.Customer.Application.CommandHandler.CreateUser;
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


//?? ??????? + ???? ?? ???
builder.Services.AddMassTransit(x =>

{
    x.UsingRabbitMq((context, cfg) =>

    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");

        });
    });
});



// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IFriendshipRepository,FriendshipRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    //sqlOptions => sqlOptions.EnableRetryOnFailure(
    //    maxRetryCount: 5,               // ?????? ? ??? ????
    //    maxRetryDelay: TimeSpan.FromSeconds(10), // ?? ??? ?? ????? ?????
    //    errorNumbersToAdd: null         // ??? ?????? transient

    ));
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

