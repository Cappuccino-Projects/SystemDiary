/*
 * Разработчик LetNull19A или Xarlein или Ein
 */

using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Auth;
using Models.Disciplines;
using Models.Groups;
using Models.Journal;
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

		public void Save();

        // Старьё от которого нужно будет избавиться
        // Вместо него лучше свойства использовать
        
        [Obsolete("Не рекомендуется к использованию", false)]
        public void CreateDefaultValues();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<UserModel>? GetUsers();

        [Obsolete("Не рекомендуется к использованию", false)]
        public DbSet<UserStateModel>? GetUserStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<UserRoleModel>? GetUserRoles();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<GroupModel>? GetGroups();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<GroupStateModel>? GetGroupStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<NewsModel>? GetNews();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<NewsState>? GetNewsStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<DisciplineModel>? GetDisciplines();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<DisciplineStateModel>? GetDisciplineStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<MarkModel>? GetMarks();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<MarkStateModel>? GetMarkStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<TimetableModel>? GetTimeTables();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<TimeTableLessonModel>? GetTimeTableLessons();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<CabinetModel>? GetCabinets();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<JournalModel>? GetJournals();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<JournalMarkModel>? GetJournalMarks();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<JournalStateModel>? GetJournalStates();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<RefreshTokensModels>? GetRefreshTokens();

		[Obsolete("Не рекомендуется к использованию", false)]
		public DbSet<UserContactModel>? GetUserContacts();
    }
}
