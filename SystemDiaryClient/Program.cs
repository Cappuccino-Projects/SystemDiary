using DataBaseContext.Interfaces;
using DataBaseContext.Mssql;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

var _connectionConfig =
    builder.Configuration.GetSection("DataBase").Value;

builder.Services.AddRazorPages();

builder.Services.AddDbContext<IDataBaseContext, MssqlContext>(
    options => options.UseSqlServer(_connectionConfig));

builder.Services.AddWebAPI();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Authiticate");

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseWebApi();

app.UseCookiePolicy();

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithRedirects("/Error");

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
