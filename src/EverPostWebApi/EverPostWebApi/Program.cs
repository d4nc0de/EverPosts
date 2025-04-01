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
builder.Services.AddScoped<Utilities>();
builder.Services.AddScoped<ADOHelper>();

//services
builder.Services.AddScoped<IUserService<User>, UserService>();
builder.Services.AddScoped<IPostService<Post, DataPaginatedDTO<Post>>, PostService>();
builder.Services.AddScoped<ICommentsService<Comment, DataPaginatedDTO<Comment>, CommentCreateDto>, CommentsService>();
builder.Services.AddScoped<ICategorieService<Categorie>, CategorieService>();

//Repositories
builder.Services.AddKeyedScoped<IRepository<User, LoginDto,UserDto, User>, UserRepository>("UserRepositoryINJ");
builder.Services.AddKeyedScoped<IRepository<Post, PostGetDto, PostCreateDto, PostUpdateDto>, PostRepository>("PostRepositoryINJ");
builder.Services.AddKeyedScoped<IRepository<Comment, Comment, CommentCreateDto, Comment>, CommentsRepository>("CommentRepositoryINJ");
builder.Services.AddKeyedScoped<IRepository<Categorie, Categorie, Categorie, Categorie>, CategorieRepository>("CategorieRepositoryINJ");


builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => 
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
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

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
