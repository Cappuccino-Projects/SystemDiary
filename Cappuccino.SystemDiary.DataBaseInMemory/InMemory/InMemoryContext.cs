using Cappuccino.SystemDiary.Factories.Factories;
using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models.Auth;
using Models.Disciplines;
using Models.Groups;
using Models.Journal;
using Models.Marks;
using Models.News;
using Models.Timetable;
using Models.Users;

namespace Cappuccino.SystemDiary.DataBaseInMemory.Mssql
{
	public sealed class InMemoryContext : DbContext, IDataBaseContext
	{

		private readonly ILogger<InMemoryContext> _logger;

		public InMemoryContext(
			ILogger<InMemoryContext> logger, 
			DbContextOptions<InMemoryContext> options) : base(options)
		{
			_logger = logger;
			Database.EnsureCreated();
		}

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

		public void CreateDefaultValues()
		{
			_logger.LogInformation("Start creating new data");

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
				.ToList()
				.ForEach(i => UserRoles.Add(i));


			UserStateFactory userStateFactory = new();
			userStateFactory.Create();
			userStateFactory.UserStates
				.ToList()
				.ForEach(i => UserStates.Add(i));

			JurnalStateFactory journalStateFactory = new();
			journalStateFactory.Create();
			journalStateFactory.JurnalStateModels
				.ForEach(i => JournalStates.Add(i));

			SaveChanges();
			
			_logger.LogInformation("Data is created!");
		}

		public DbSet<CabinetModel>? GetCabinets() => Cabinets;

		public DbSet<DisciplineModel>? GetDisciplines() => Disciplines;

		public DbSet<DisciplineStateModel>? GetDisciplineStates() => DisciplineStates;

		public DbSet<GroupModel>? GetGroups() => Groups;

		public DbSet<GroupStateModel>? GetGroupStates() => GroupStates;

		public DbSet<JournalMarkModel>? GetJournalMarks() => JournalMarks;

		public DbSet<JournalModel>? GetJournals() => Journals;

		public DbSet<JournalStateModel>? GetJournalStates() => JournalStates;

		public DbSet<MarkModel>? GetMarks() => Marks;

		public DbSet<MarkStateModel>? GetMarkStates() => MarkStates;

		public DbSet<NewsModel>? GetNews() => News;

		public DbSet<NewsState>? GetNewsStates() => NewsStates;

		public DbSet<RefreshTokensModels>? GetRefreshTokens() => RefreshTokens;

		public DbSet<TimeTableLessonModel>? GetTimeTableLessons() => TimeTableLessons;

		public DbSet<TimetableModel>? GetTimeTables() => Timetables;

		public DbSet<UserContactModel>? GetUserContacts() => UserContacts;

		public DbSet<UserRoleModel>? GetUserRoles() => UserRoles;

		public DbSet<UserModel>? GetUsers() => Users;

		public DbSet<UserStateModel>? GetUserStates() => UserStates;

		public void Save()
		{
			SaveChanges();
		}
	}
}
