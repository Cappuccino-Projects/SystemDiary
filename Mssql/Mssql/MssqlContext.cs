using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Disciplines;
using Models.Groups;
using Models.Marks;
using Models.News;
using Models.Users;

namespace DataBaseContext.Mssql
{
    public sealed class MssqlContext : DbContext, IDataBaseContext
    {
        #region Fields

        public DbSet<UserModel>? Users { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<UserState>? UserStates { get; set; }
        public DbSet<UserPermission>? UserPermissions { get; set; }
        public DbSet<GroupModel>? Groups { get; set; }
        public DbSet<GroupState>? GroupStates { get; set; }
        public DbSet<GroupAndUserAssociate>? GroupAndUsers { get; set; }
        public DbSet<GlobalAssociateState>? AssociateStates { get; set; }
        public DbSet<PermissionAndRoleAssociate>? PermissionsAndRoles { get; set; }
        public DbSet<NewsModel>? News { get; set; }
        public DbSet<NewsState>? NewsStates { get; set; }
        public DbSet<DisciplineModel>? Disciplines { get; set; }
        public DbSet<DisciplineState>? DisciplineStates { get; set; }
        public DbSet<MarkModel>? Marks { get; set; }
        public DbSet<MarkStateModel>? MarkStates { get; set; }

        #endregion

        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region Implementation

        public DbSet<UserModel>? GetUsers() => Users;

        public DbSet<UserState>? GetUserStates() => UserStates;

        public DbSet<UserRole>? GetUserRoles() => UserRoles;

        public DbSet<UserPermission>? GetUserPermissions() => UserPermissions;

        public void CreateDefaultValues()
        {
            UserRole userRoleAdmin = new UserRole()
            {
                Id = Guid.NewGuid(),
                Name = "Администратор",
                Description = "Администратор системы SystemDiary",
                BackendName = "backend_admin"
            };

            UserRole userRoleTeacher = new UserRole()
            {
                Id = Guid.NewGuid(),
                Name = "Преподаватель",
                Description = "Препадаёт",
                BackendName = "backend_teacher"
            };

            UserRole userRoleStudent = new UserRole()
            {
                Id = Guid.NewGuid(),
                Name = "Студент",
                Description = "Тот кто обучается",
                BackendName = "backend_student"
            };

            UserPermission userAdminPermission = new UserPermission()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleAdmin.Id,
                Name = "canEditUsers",
                IsEnabled = true,
                Description = "Может ли пользователь редактировать данные других пользователей"
            };

            UserPermission userStudentPermission = new UserPermission()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleStudent.Id,
                Name = "canUserSetMarks",
                IsEnabled = true,
                Description = "Может ли пользователь устанавливать значения оценок"
            };

            UserState userActiveState = new UserState()
            {
                Id = Guid.NewGuid(),
                Name = "Активный",
                Description = "Работоспособный аккаунт"
            };

            UserState userDisabledState = new UserState()
            {
                Id = Guid.NewGuid(),
                Name = "Не активный",
                Description = "Аккаунт не активный"
            };

            PermissionAndRoleAssociate permissionAndRole1 = new PermissionAndRoleAssociate()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleAdmin.Id,
                PermissionId = userAdminPermission.Id
            };

            PermissionAndRoleAssociate permissionAndRole2 = new PermissionAndRoleAssociate()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleStudent.Id,
                PermissionId = userStudentPermission.Id
            };

            PermissionAndRoleAssociate permissionAndRole3 = new PermissionAndRoleAssociate()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleAdmin.Id,
                PermissionId = userStudentPermission.Id
            };

            PermissionAndRoleAssociate permissionAndRole4 = new PermissionAndRoleAssociate()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleTeacher.Id,
                PermissionId = userStudentPermission.Id
            };

            DisciplineState disciplineActive = new DisciplineState() 
            {
                Id = Guid.NewGuid(),
                Name = "Активная",
                Description = "Дисциплина активная"
            };

            DisciplineState disciplineRemoved = new DisciplineState()
            {
                Id = Guid.NewGuid(),
                Name = "Удалена",
                Description = "Дисциплина удалена"
            };

            GroupState groupStateActive = new GroupState() 
            {
                Id = Guid.NewGuid(),
                Name = "Активная группа",
                Description = "Эта группа активная"
            };

            GroupState groupStateDeleted = new GroupState() 
            {
                Id = Guid.NewGuid(),
                Name = "Удалённая группа",
                Description = "Эта группа удалена"
            };

            GlobalAssociateState globalAssociateStateActive = new GlobalAssociateState()
            {
                Id = Guid.NewGuid(),
                Name = "Ассоциация активна",
                Description = "Эта ассоциация активна"
            };

            GlobalAssociateState globalAssociateStateDeleted = new GlobalAssociateState() 
            {
                Id = Guid.NewGuid(), 
                Name = "Ассоциация удалена",
                Description = "Этой ассоциации не существует"
            };

            MarkStateModel markStateActive = new MarkStateModel() 
            {
                Id = Guid.NewGuid(),
                Name = "Активная",
                Description = "Оценка активная"
            };

            MarkStateModel markStateDeleted = new MarkStateModel()
            {
                Id = Guid.NewGuid(),
                Name = "Удалена",
                Description = "Оценка удалена, её использование не возможно"
            };

            MarkModel excellentGrade = new MarkModel() 
            {
                Id = Guid.NewGuid(),
                Markup = "5",
                Value = 5,
                Description = "Оценка отлично",
                StateId = markStateActive.Id
            };

            MarkModel ratingOfGood = new MarkModel() 
            {
                Id = Guid.NewGuid(),
                Markup = "4",
                Value = 4,
                Description = "Оценка хорошо",
                StateId = markStateActive.Id
            };

            MarkModel fairRating = new MarkModel() 
            {
                Id = Guid.NewGuid(),
                Markup = "3",
                Value = 3,
                Description = "Оценка удовлетворительно",
                StateId = markStateActive.Id
            };

            MarkModel poorGrade = new MarkModel()
            {
                Id = Guid.NewGuid(),
                Markup = "2",
                Value = 2,
                Description = "Оценка плохо",
                StateId = markStateActive.Id
            };

            MarkStates?.Add(markStateActive);
            MarkStates?.Add(markStateDeleted);

            Marks?.Add(excellentGrade);
            Marks?.Add(ratingOfGood);
            Marks?.Add(fairRating);
            Marks?.Add(poorGrade);

            AssociateStates?.Add(globalAssociateStateActive);
            AssociateStates?.Add(globalAssociateStateDeleted);

            GroupStates?.Add(groupStateActive);
            GroupStates?.Add(groupStateDeleted);

            DisciplineStates?.Add(disciplineActive);
            DisciplineStates?.Add(disciplineRemoved);

            UserPermissions?.Add(userAdminPermission);
            UserPermissions?.Add(userStudentPermission);

            UserRoles?.Add(userRoleAdmin);
            UserRoles?.Add(userRoleTeacher);
            UserRoles?.Add(userRoleStudent);

            UserStates?.Add(userDisabledState);
            UserStates?.Add(userActiveState);

            PermissionsAndRoles?.Add(permissionAndRole1);
            PermissionsAndRoles?.Add(permissionAndRole2);
            PermissionsAndRoles?.Add(permissionAndRole3);
            PermissionsAndRoles?.Add(permissionAndRole4);

            SaveChanges();
        }

        public void Save()
        {
            SaveChanges();
        }

        public DbSet<GroupModel>? GetGroups() => Groups;

        public DbSet<GroupState>? GetGroupStates() => GroupStates;

        public DbSet<GlobalAssociateState>? GetAssociateStates() => AssociateStates;

        public DbSet<GroupAndUserAssociate>? GetGroupsAndUsers() => GroupAndUsers;

        public DbSet<PermissionAndRoleAssociate>? GetPermissionsAndRoles() => PermissionsAndRoles;

        public DbSet<NewsModel>? GetNews() => News;

        public DbSet<NewsState>? GetNewsStates() => NewsStates;

        public DbSet<DisciplineModel>? GetDisciplines() => Disciplines;

        public DbSet<DisciplineState>? GetDisciplineStates() => DisciplineStates;

        public DbSet<MarkModel>? GetMarks() => Marks;

        public DbSet<MarkStateModel>? GetMarkStates() => MarkStates;

        #endregion

    }
}