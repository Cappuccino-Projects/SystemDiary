using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Groups;
using Models.Users;

namespace DataBaseContext.Interfaces
{
    public interface IDataBaseContext
    {
        public void CreateDefaultValues();
        public DbSet<User>? GetUsers();
        public DbSet<UserState>? GetUserStates();
        public DbSet<UserRole>? GetUserRoles();
        public DbSet<UserPermission>? GetUserPermissions();
        public DbSet<Group>? GetGroups();
        public DbSet<GroupState>? GetGroupStates();
        public DbSet<AssociateState>? GetAssociateStates();
        public DbSet<GroupAndUser>? GetGroupsAndUsers();
        public DbSet<PermissionAndRole>? GetPermissionsAndRoles();
    }
}
