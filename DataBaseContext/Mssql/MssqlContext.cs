using DataBaseContext.Factories;
using DataBaseContext.Interfaces;
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

namespace DataBaseContext.Mssql
{
    public sealed class MssqlContext : DbContext, IDataBaseContext
    {
        #region Fields

        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<UserStateModel> UserStates { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<GroupStateModel> GroupStates { get; set; }
        public DbSet<NewsModel> News { get; set; }
        public DbSet<NewsState> NewsStates { get; set; }
        public DbSet<DisciplineModel> Disciplines { get; set; }
        public DbSet<DisciplineStateModel> DisciplineStates { get; set; }
        public DbSet<MarkModel> Marks { get; set; }
        public DbSet<MarkStateModel> MarkStates { get; set; }
        public DbSet<JournalMarkModel> JournalMarks { get; set; }
        public DbSet<JournalStateModel> JournalStates { get; set; }
        public DbSet<JournalModel> Journals { get; set; }
        public DbSet<TimetableModel> Timetables { get; set; }
        public DbSet<TimeTableLessonModel> TimeTableLessons { get; set; }
        public DbSet<CabinetModel> Cabinets { get; set; }
        public DbSet<RefreshTokensModels> RefreshTokens { get; set; }
        public DbSet<UserContactModel> UserContacts { get; set; }
        #endregion

        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region Implementation

        public DbSet<UserModel> GetUsers() => Users;

        public DbSet<UserStateModel> GetUserStates() => UserStates;

        public DbSet<UserRoleModel> GetUserRoles() => UserRoles;


        public void CreateDefaultValues()
        {
            MarkStateFactory markStateFactory = new();
            markStateFactory.Create();
            markStateFactory.MarkStateModels
                .ForEach(i => MarkStates.Add(i));

            MarkFactory markFactory = new(markStateFactory.MarkStateModels);
            markFactory.Create();
            markFactory.MarkModels
                .ForEach(i => Marks.Add(i));

            GroupStateFactory groupStateFactory = new();
            groupStateFactory.Create();
            groupStateFactory.GroupStateModels
                .ForEach(i => GroupStates.Add(i));

            DisciplineStateFactory disciplineStateFactory = new();
            disciplineStateFactory.Create();
            disciplineStateFactory.DisciplineStates
                .ForEach(i => DisciplineStates.Add(i));

            UserRoleFactory userRoleFactory = new();
            userRoleFactory.Create();
            userRoleFactory.UserRoleModels
                .ForEach(i => UserRoles.Add(i));


            UserStateFactory userStateFactory = new();
            userStateFactory.Create();
            userStateFactory.UserStates
                .ForEach(i => UserStates.Add(i));

            JurnalStateFactory jurnalStateFactory = new();
            jurnalStateFactory.Create();
            jurnalStateFactory.JurnalStateModels
                .ForEach(i => JournalStates.Add(i));

            SaveChanges();
        }

        public void Save() => SaveChanges();

        public DbSet<GroupModel>? GetGroups() => Groups;

        public DbSet<GroupStateModel>? GetGroupStates() => GroupStates;

        public DbSet<NewsModel>? GetNews() => News;

        public DbSet<NewsState>? GetNewsStates() => NewsStates;

        public DbSet<DisciplineModel>? GetDisciplines() => Disciplines;

        public DbSet<DisciplineStateModel>? GetDisciplineStates() => DisciplineStates;

        public DbSet<MarkModel>? GetMarks() => Marks;

        public DbSet<MarkStateModel>? GetMarkStates() => MarkStates;
        
        public DbSet<TimetableModel>? GetTimeTables() => Timetables;
        
        public DbSet<TimeTableLessonModel>? GetTimeTableLessons() => TimeTableLessons;
        
        public DbSet<CabinetModel>? GetCabinets() => Cabinets;

        public DbSet<JournalModel>? GetJournals() => Journals;

        public DbSet<JournalStateModel>? GetJournalStates() => JournalStates;

        public DbSet<RefreshTokensModels>? GetRefreshTokens() => RefreshTokens;

        public DbSet<JournalMarkModel>? GetJournalMarks() => JournalMarks;

        public DbSet<UserContactModel>? GetUserContacts() => UserContacts;

        #endregion

    }
}