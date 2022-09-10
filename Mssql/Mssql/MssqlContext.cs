using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Disciplines;
using Models.Groups;
using Models.News;
using Models.Users;

namespace DataBaseContext.Mssql
{
    public sealed class MssqlContext : DbContext, IDataBaseContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<UserState>? UserStates { get; set; }
        public DbSet<UserPermission>? UserPermissions { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<GroupState>? GroupStates { get; set; }
        public DbSet<GroupAndUserAssociate>? GroupAndUsers { get; set; }
        public DbSet<GlobalAssociateState>? AssociateStates { get; set; }
        public DbSet<PermissionAndRoleAssociate>? PermissionsAndRoles { get; set; }
        public DbSet<NewsModel>? News { get; set; }
        public DbSet<NewsState>? NewsStates { get; set; }
        public DbSet<DisciplineModel>? Disciplines { get; set; }
        public DbSet<DisciplineState>? DisciplineStates { get; set; }

        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        #region Implementation

        public DbSet<User>? GetUsers() => Users;

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

        public DbSet<Group>? GetGroups() => Groups;

        public DbSet<GroupState>? GetGroupStates() => GroupStates;

        public DbSet<GlobalAssociateState>? GetAssociateStates() => AssociateStates;

        public DbSet<GroupAndUserAssociate>? GetGroupsAndUsers() => GroupAndUsers;

        public DbSet<PermissionAndRoleAssociate>? GetPermissionsAndRoles() => PermissionsAndRoles;

        public DbSet<NewsModel>? GetNews() => News;

        public DbSet<NewsState>? GetNewsStates() => NewsStates;

        public DbSet<DisciplineModel>? GetDisciplines() => Disciplines;

        public DbSet<DisciplineState>? GetDisciplineStates() => DisciplineStates;

        #endregion

    }
}