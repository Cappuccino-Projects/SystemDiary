using Cappuccino.SystemDiary.Factories.Connectors;
using Cappuccino.SystemDiary.Factories.Factories;
using Cappuccino.SystemDiary.Factories.Others;
using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Users;

namespace Cappuccino.SystemDiary.DataBaseInMemory.Factories;

public sealed class FactoryData
{
    private readonly IDataBaseContext _context;

    public FactoryData(IDataBaseContext context) 
        => (_context) = (context);

    public void InitializeData()
    {
        var roles = InitializeUserRoles();
        var states = InitializeUserStates();

        var userConnector =  new UserConnector(
            _context.Users.First(),
            roles.First(role => role.Name == ConstantName.Administrator), 
            states.First(state => state.Name == ConstantName.ActiveUserStateName));
        
        userConnector.Connect();
        
        _context.Save();
    }

    private IReadOnlyCollection<UserStateModel> InitializeUserStates()
    {
        var factory = new UserStateFactory();
        factory.Create();
        return factory.UserStates;
    }

    private IReadOnlyCollection<UserRoleModel> InitializeUserRoles()
    {
        var factory = new UserRoleFactory();
        factory.Create();
        return factory.UserRoleModels;
    }
}