using DataBaseContext.Mssql;
using Models.Associations;
using Models.Groups;
using Models.Users;
using NUnit.Framework;
using System;

namespace DataBaseContextTest
{
    public class GroupTest
    {
        private MssqlContext _context;
        private Group _group;
        private GroupState _state;
        private GroupAndUser _associate;
        private AssociateState _associateState;
        private string _userId = "102ef818-9e54-49ba-8893-311449f34359";

        [SetUp]
        public void Setup()
        {
            _context = new MssqlContext("Server=(localdb)\\MSSQLLocalDB;DataBase=SystemDiary;Trusted_Connection=True;");
            _context.Database.EnsureCreated();

            _associateState = new AssociateState()
            {
                Id = Guid.NewGuid(),
                Name = "Active",
                Description = ""
            };

            _state = new GroupState() 
            {
                Id = Guid.NewGuid(),
                Name = "Active",
                Description = "Is Active"
            };

            _group = new Group()
            {
                Id = Guid.NewGuid(),
                Name = "Group #1",
                Description = "331 group",
                GroupStateId = _state.Id
            };

            _associate = new GroupAndUser()
            {
                Id = Guid.NewGuid(),
                UserId = Guid.Parse(_userId),
                GroupId = _group.Id,
                AssociateStateId = _associateState.Id
            };
        }

        [Test, Order(3)]
        public void ContextIsNotNull()
        {
            Assert.IsNotNull(_context);
        }

        [Test, Order(4)]
        public void CreateDefaultValues()
        {
            CreateAssociateState();
            CreateGroupState();
            CreateGroup();
            CreateAssociate();
        }

        public void CreateAssociateState() 
        {
            _context.AssociateStates?.Add(_associateState);
            _context.SaveChanges();
        }

        public void CreateGroupState() 
        {
            _context.GroupStates?.Add(_state);
            _context.SaveChanges();
        }

        public void CreateGroup() 
        {
            _context.Groups?.Add(_group);
            _context.SaveChanges();
        }

        public void CreateAssociate()
        {
            _context.GroupAndUsers?.Add(_associate);
            _context.SaveChanges();
        }
    }
}