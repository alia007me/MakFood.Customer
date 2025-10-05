using MakFood.Customer.Infrstructure.DataAccess.Context;
using MakFood.Customer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories;
using MakFood.Customer.Application.CommandHandler.CreateUser;
using MakFood.Customer.Application.Servises;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository,UserRepository>();
//builder.Services.AddScoped<IFriendshipRepository,FriendshipRepository>();
builder.Services.AddScoped<IUserService, UserService>();

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

