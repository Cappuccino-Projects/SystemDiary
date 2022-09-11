using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Disciplines;
using Models.Groups;
using Models.Marks;
using Models.News;
using Models.Users;

namespace DataBaseContext.Interfaces
{
    public interface IDataBaseContext
    {
        public void CreateDefaultValues();
        public DbSet<UserModel>? GetUsers();
        public DbSet<UserState>? GetUserStates();
        public DbSet<UserRole>? GetUserRoles();
        public void Save();
        public DbSet<UserPermission>? GetUserPermissions();
        public DbSet<GroupModel>? GetGroups();
        public DbSet<GroupState>? GetGroupStates();
        public DbSet<GlobalAssociateState>? GetAssociateStates();
        public DbSet<GroupAndUserAssociate>? GetGroupsAndUsers();
        public DbSet<PermissionAndRoleAssociate>? GetPermissionsAndRoles();
        public DbSet<NewsModel>? GetNews();
        public DbSet<NewsState>? GetNewsStates();
        public DbSet<DisciplineModel>? GetDisciplines();
        public DbSet<DisciplineState>? GetDisciplineStates();
        public DbSet<MarkModel>? GetMarks();
        public DbSet<MarkStateModel>? GetMarkStates();
    }
}
