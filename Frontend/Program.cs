using DataBaseContext.Interfaces;
using DataBaseContext.Mssql;
using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions;
using WebAPI.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddCors(p => p.AddDefaultPolicy(build => 
{
    build
        .WithOrigins("https://localhost:44458")
        .AllowAnyHeader()
        .AllowAnyMethod();
}));

var _connectionConfig =
    builder.Configuration.GetSection("DataBase").Value;

builder.Services.AddDbContext<IDataBaseContext, MssqlContext>(
    options => options.UseSqlServer(_connectionConfig));

var jwtOptions = builder.Configuration.GetSection("JWT").Get<JWTOptions>();

builder.Services.AddWebAPI(builder, jwtOptions);


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.UseWebApi();

app.UseRouting();
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.UseCors();

app.UseCookiePolicy();

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
