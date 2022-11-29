using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Disciplines;
using Models.Groups;
using Models.Marks;
using Models.News;
using Models.Timetable;
using Models.Users;

namespace DataBaseContext.Interfaces
{
    public interface IDataBaseContext
    {
        public void Save();
        public void CreateDefaultValues();
        public DbSet<UserModel>? GetUsers();
        public DbSet<UserState>? GetUserStates();
        public DbSet<UserRole>? GetUserRoles();
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
        public DbSet<TimetableModel>? GetTimeTables();
        public DbSet<TimeTableLessonModel>? GetTableLessons();
        public DbSet<CabinetModel>? GetCabinets();
    }
}
