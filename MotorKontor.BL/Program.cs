using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MotorKontor.BL.Interfaces;
using MotorKontor.BL.Models;
using MotorKontor.BL.Repository;
using MotorKontor.BL.Service;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<myContext>(opt => opt
    .EnableDetailedErrors()
    .UseLazyLoadingProxies()
    .UseSqlServer(config.GetConnectionString("SqlServer")), ServiceLifetime.Transient);

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });

    opt.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Beaerer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Type = SecuritySchemeType.ApiKey,
    });


    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("JWTkey").ToString())),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
