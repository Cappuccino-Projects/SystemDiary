using Models.Users;

namespace Cappuccino.SystemDiary.Factories.Connectors;

public sealed class UserConnector
{
    private readonly UserModel _user;
    private readonly UserRoleModel _role;
    private readonly UserStateModel _state;

    public UserConnector(UserModel user, UserRoleModel role, UserStateModel state)
        => (_user, _role, _state) = (user, role, _state);

    public void Connect()
        => (_user.StateId, _user.RoleId) = (_state.Id, _role.Id);

    public UserModel GetReadyModel() 
        => _user;
}