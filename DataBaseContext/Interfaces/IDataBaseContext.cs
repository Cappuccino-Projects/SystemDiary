using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Auth;
using Models.Disciplines;
using Models.Groups;
using Models.Jurnal;
using Models.Marks;
using Models.News;
using Models.Timetable;
using Models.Users;

namespace DataBaseContext.Interfaces
{
    /// <summary>
    /// Интерфейс контекста базы данных, используется для 
    /// работы с EntityFramework
    /// </summary>
    public interface IDataBaseContext
    {
        public void Save();
        public void CreateDefaultValues();
        public DbSet<UserModel>? GetUsers();
        public DbSet<UserStateModel>? GetUserStates();
        public DbSet<UserRoleModel>? GetUserRoles();
        public DbSet<GroupModel>? GetGroups();
        public DbSet<GroupStateModel>? GetGroupStates();
        public DbSet<NewsModel>? GetNews();
        public DbSet<NewsState>? GetNewsStates();
        public DbSet<DisciplineModel>? GetDisciplines();
        public DbSet<DisciplineStateModel>? GetDisciplineStates();
        public DbSet<MarkModel>? GetMarks();
        public DbSet<MarkStateModel>? GetMarkStates();
        public DbSet<TimetableModel>? GetTimeTables();
        public DbSet<TimeTableLessonModel>? GetTimeTableLessons();
        public DbSet<CabinetModel>? GetCabinets();
        public DbSet<JournalModel>? GetJournals();
        public DbSet<JournalMarkModel>? GetJournalMarks();
        public DbSet<JournalStateModel>? GetJournalStates();
        public DbSet<RefreshTokensModels>? GetRefreshTokens();
        public DbSet<UserContactModel>? GetUserContacts();
    }
}
