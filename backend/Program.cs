using BLL.Services;
using BLL.Services.Interfaces;
using DAL;
using DAL.Interfaces.User;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utils.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.CookiePolicy;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("1ee27e30488b3be2c99b53411375caa3bed79a6f2d319a9df564e81d0efeb223")),
            ValidateIssuerSigningKey = true,
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["Cookie"];

                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

// Регистрация сервисов
builder.Services.AddScoped<IWorkspaceService, WorkspaceService>();
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<BLL.Services.Interfaces.IBookingService, BLL.Services.BookingService>();
builder.Services.AddScoped<DAL.Repositories.Interfaces.IBookingRepository, DAL.Repositories.BookingRepository>();

builder.Services.AddSingleton<EmailService>();


// Регистрация контекста базы данных
builder.Services.AddDbContext<WorkspacesDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавление контроллеров
builder.Services.AddControllers();

// Добавление Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Настройка HTTP-запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();