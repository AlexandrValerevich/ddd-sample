using System.Reflection;
using Registration.Infrastructure.DataBaseAccess;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Registration.Domain.UserRegistration.Interfaces;
using Registration.Infrastructure.DataBaseAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(Assembly.GetCallingAssembly());
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RegistrationDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("RegistrationUser");
    options.UseNpgsql(connectionString);
});

builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
