using DataBaseContext.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Associations;
using Models.Groups;
using Models.Users;

namespace DataBaseContext.Mssql
{
    public sealed class MssqlContext : DbContext, IDataBaseContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<UserState>? UserStates { get; set; }
        public DbSet<UserPermission>? UserPermissions { get; set; }
        public DbSet<PermissionAndRole>? PermissionsAndRoles  { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<GroupState>? GroupStates { get; set; }
        public DbSet<GroupAndUser>? GroupAndUsers { get; set; }
        public DbSet<AssociateState>? AssociateStates { get; set; }

        public MssqlContext(DbContextOptions<MssqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

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
                Description = "Администратор системы SystemDiary"
            };
            
            UserRole userRoleStudent = new UserRole() 
            {
                Id = Guid.NewGuid(),
                Name = "Студент",
                Description = "Тот кого эта ситема юзает"
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
                RoleId= userRoleStudent.Id,
                Name = "canUserViewPages",
                IsEnabled = true,
                Description = "Может ли пользователь просматривать страницы"
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
                Description = "Что закибербулили тебя?"
            };

            User user = new User()
            {
                Id = Guid.NewGuid(),
                PublicId = Guid.NewGuid(),
                Name = "Алексей",
                Surname = "Волков",
                Fathername = "Викторович",
                Login = "lo4gen73",
                Gender = Genders.Male,
                Email = "alex.volkovdd@gmail.com",
                Password = "А_зАчЕм7",
                Age = 18,
                LastSession = DateTime.Now,
                StateId = userActiveState.Id,
                RoleId = userRoleAdmin.Id,
            };

            PermissionAndRole permissionAndRole1 = new PermissionAndRole()
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleAdmin.Id,
                PermissionId = userAdminPermission.Id
            };

            PermissionAndRole permissionAndRole2 = new PermissionAndRole() 
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleStudent.Id,
                PermissionId= userStudentPermission.Id
            };

            PermissionAndRole permissionAndRole3 = new PermissionAndRole() 
            {
                Id = Guid.NewGuid(),
                RoleId = userRoleAdmin.Id,
                PermissionId = userStudentPermission.Id
            };

            UserPermissions?.Add(userAdminPermission);
            UserPermissions?.Add(userStudentPermission);
            UserRoles?.Add(userRoleAdmin);
            UserRoles?.Add(userRoleStudent);
            UserStates?.Add(userDisabledState);
            UserStates?.Add(userActiveState);
            Users?.Add(user);
            PermissionsAndRoles?.Add(permissionAndRole1);
            PermissionsAndRoles?.Add(permissionAndRole2);
            PermissionsAndRoles?.Add(permissionAndRole3);

            SaveChanges();
        }

        public DbSet<Group>? GetGroups() => Groups;

        public DbSet<GroupState>? GetGroupStates() => GroupStates;

        public DbSet<AssociateState>? GetAssociateStates() => AssociateStates;

        public DbSet<GroupAndUser>? GetGroupsAndUsers() => GroupAndUsers;

        public DbSet<PermissionAndRole>? GetPermissionsAndRoles() => PermissionsAndRoles;
    }
}