using System.Data;
using Microsoft.Data.SqlClient;
using pjMultimodulo.Repositories.Interfaces;
using pjMultimodulo.Repositories.Implementations;
using pjMultimodulo.Services.Interfaces;
using pjMultimodulo.Services.Implementations;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// DB connection
builder.Services.AddScoped<IDbConnection>(_ => new SqlConnection(
    builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositorios & servicios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// Auth con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Usuario/Login";
        opt.LogoutPath = "/Usuario/Logout";
    });

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
