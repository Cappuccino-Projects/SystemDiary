using DataBaseContext.Mssql;
using Models.Users;
using NUnit.Framework;
using System;

namespace DataBaseContextTest
{
    public class UserTest
    {
        private MssqlContext _context;
        private User _user;
        private UserRole _userRole;
        private UserPermission _userPermission;
        private UserState _userState;

        [SetUp]
        public void Setup()
        {
            _context = new MssqlContext(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;DataBase=SystemDiary;Trusted_Connection=True;"));

            _userPermission = new UserPermission()
            {
                Id = Guid.NewGuid(),
                Name = "can_edit_another_users",
                IsEnabled = true,
                Description = "Some..."
            };

            _userRole = new UserRole()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Description = "This is Admin",
                PermissionId = _userPermission.Id
            };

            _userState = new UserState()
            {
                Id = Guid.NewGuid(),
                Name = "Active",
                Description = "User is active"
            };

            _user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Alex",
                Surname = "Wolkoff",
                Fathername = "Woktorovich",
                Email = "email@email.com",
                Password = "11111111111",
                Age = 18,
                LastSession = DateTime.Now,
                StateId = _userState.Id,
                RoleId = _userRole.Id,
            };
        }

        [Test, Order(1)]
        public void ContextIsNotNull()
        {
            Assert.IsNotNull(_context);
        }

        [Test, Order(2)]
        public void CreateDefaultValues() 
        {
            CreatePermission();
            CreateRole();
            CreateState();
            CreateUser();
        }

        public void CreatePermission() 
        {
            _context.Permissions?.Add(_userPermission);
            _context.SaveChanges();
        }

        public void CreateRole() 
        {
            _context.UserRoles?.Add(_userRole);
            _context.SaveChanges();
        }

        public void CreateState() 
        {
            _context.UserStates?.Add(_userState);
            _context.SaveChanges();
        }

        public void CreateUser() 
        {
            _context.Users?.Add(_user);
            _context.SaveChanges();
        }
    }
}