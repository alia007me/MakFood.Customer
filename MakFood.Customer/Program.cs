using MakFood.Customer.Infrstructure.DataAccess.Context;
using MakFood.Customer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories;
using MakFood.Customer.Application.CommandHandler.CreateUser;
using MakFood.Customer.Controller;
using FluentValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IFriendshipRepsitory, >();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);


builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(typeof(CreateUserCommandHandler).Assembly);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {

        options.EnableTryItOutByDefault();

    });
}

app.Run();

