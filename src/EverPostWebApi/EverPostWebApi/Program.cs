using ChannelMonitoring.Utils;
using EverPostWebApi.Commons;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.Config;
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;
using EverPostWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Inyectar el contexto ENTITY FRAMEWORK
builder.Services.AddDbContext<EverPostContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Dev"));
});


// Useful injections
builder.Services.AddSingleton<Utilities>();
builder.Services.AddSingleton<ADOHelper>();
builder.Services.AddScoped<IUserService<User>, UserService>();
builder.Services.AddKeyedScoped<IRepository<User, LoginDto,UserDto>, UserRepository>("UserRepositoryINJ");
builder.Services.AddKeyedScoped<IRepository<Post,PostGetDto,PostCreateDto>, PostRepository>("PostRepositoryINJ");


builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => 
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]!))
        };
    }
    
);




builder.Services.AddControllers();
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
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
