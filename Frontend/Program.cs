using Cappuccino.SystemDiary.DataBaseInMemory.Factories;
using Cappuccino.SystemDiary.DataBaseInMemory.Mssql;
using Cappuccino.SystemDiary.WebAPI.Extensions;
using Cappuccino.SystemDiary.WebAPI.Options;
using DataBaseContext.Interfaces;
using DataBaseContext.Mssql;
using Microsoft.EntityFrameworkCore;

namespace Frontend;

public sealed class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        builder.Services.AddControllersWithViews();

        builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
        {
            build
                .WithOrigins("https://localhost:44458")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }));


#if !MOCKED
		var _connectionConfig =
			builder.Configuration.GetSection("DataBase").Value;

		builder.Services.AddDbContext<IDataBaseContext, MssqlContext>(
			options => options.UseSqlServer(_connectionConfig));

#endif

#if MOCKED

        builder.Services.AddDbContext<IDataBaseContext, InMemoryContext>(
            options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

#endif

        var jwtOptions = builder.Configuration.GetSection("JWT").Get<JWTOptions>();

        builder.Services.AddWebAPI(builder, jwtOptions);


        var app = builder.Build();

#if MOCKED

        var factoryData = new FactoryData(app.Services.GetService<IDataBaseContext>());

#endif

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
        // app.UseStaticFiles();

        // app.MapControllerRoute(
        //     name: "default",
        //     pattern: "{controller}/{action=Index}/{id?}");

        // app.MapFallbackToFile("index.html");

        app.Run();
    }
}