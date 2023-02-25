using System.Security.Cryptography.X509Certificates;
using Cappuccino.SystemDiary.DataBaseInMemory.Mssql;
using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Users;
using NUnit.Framework;

namespace Cappuccino.SystemDiary.Core.Test;

public class Tests
{
    private WebApplicationBuilder _builder;
    private WebApplication _app;
    
    [SetUp]
    public void Setup()
    {
        _builder = WebApplication.CreateBuilder();
        _builder.Services.AddDbContext<IDataBaseContext, InMemoryContext>(
            options =>
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()),
            ServiceLifetime.Singleton,
            ServiceLifetime.Singleton
            );
        
        _app = _builder.Build();
    }

    [Test]
    public void DataBaseContextIsReally()
    {
        Assert.NotNull(_app.Services.GetService<IDataBaseContext>());
    }

    [Test]
    public void AccessInUsers()
    {
        var context = _app.Services.GetService<IDataBaseContext>();
        Assert.NotNull(context.Users);
    }

    [Test]
    public void TryAddNewUser()
    {
        var context = _app.Services.GetService<IDataBaseContext>();
        
        context.Users.Add(new UserModel
        {
            Id = Guid.NewGuid(),
            Name = "Алексей",
            Surname = "Волков",
            Fathername = "Викторович",
            Password = "1111",
            Login = "login1"
        });
        
        context.Save();

        Assert.AreEqual(1, context.Users.Count());
    }
}