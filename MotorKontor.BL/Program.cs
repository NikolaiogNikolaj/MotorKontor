using Microsoft.EntityFrameworkCore;
using MotorKontor.BL.Models;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<myContext>(opt => opt
    .EnableDetailedErrors()
    .UseSqlServer(config.GetConnectionString("SqlServer")), ServiceLifetime.Transient
    

);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
