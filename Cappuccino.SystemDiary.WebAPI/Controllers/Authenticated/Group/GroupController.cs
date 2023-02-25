using DataBaseContext.Interfaces;
using Forms.Groups;
using Microsoft.AspNetCore.Mvc;
using Models.Groups;

namespace Cappuccino.SystemDiary.WebAPI.Controllers.Authenticated.Group
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class GroupController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public GroupController(IDataBaseContext context) 
        {
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddGroup([FromForm] GroupAddForm groupForm) 
        {
            GroupModel group = new GroupModel() 
            {
                Id = Guid.NewGuid(),
                GroupStateId = _context.GetGroupStates()
                    .Where(g => g.Name == "Активная группа")
                    .First().Id,
                NumberCourse = groupForm.Course,
                Name = groupForm.Name,
                Description = groupForm.Description
            };

            _context.GetGroups()?.Add(group);

            _context.Save();

            return Ok("Группа успешно добавлена!");
        }

        [HttpPost("Get/All")]
        public List<GroupModel> GetAllGroupModels() 
        {
            return _context.GetGroups().ToList() ?? new List<GroupModel>();
        }

        [HttpPost("Get/{id}")]
        public GroupModel GetGroupById(string id) 
        {
            Guid groupId = Guid.Parse(id);

            return _context.GetGroups().First(g => g.Id == groupId);
        }

        //[HttpPost("Add/User")]
        //public IActionResult AddUserToGroupByPublicID([FromForm] GroupAddUserForm model) 
        //{

        //    Guid? userId = _context?
        //        .GetUsers()?
        //        .Where(user => user.PublicId == model.UserPublicId)?
        //        .FirstOrDefault()?
        //        .Id;

        //    if (userId == null)
        //        return BadRequest("Пользователь не найден!");

        //    GroupAndUserAssociateModel associate = new GroupAndUserAssociateModel() 
        //    {
        //        Id = Guid.NewGuid(),
        //        UserId = userId ?? Guid.NewGuid(),
        //        GroupId = model.GroupId,
        //        AssociateStateId = _context.GetAssociateStates().ToList()[0].Id
        //    };

        //    _context.GetGroupsAndUsers()?.Add(associate);
        //    _context.Save();

        //    return Ok("Пользователь успешно добавлен в группу!");
        //}

        //[HttpPost("Get/{id}/Users")]
        //public List<UserModel> GetAllUsersInGroup(string id)
        //{
        //    Guid groupId = Guid.Parse(id);

        //    var users = _context.GetUsers();

        //    var s = users
        //        .Select(u => u.Id)
        //        .Intersect(_context
        //            .GetGroupsAndUsers()
        //            .Where(gr => gr.GroupId == groupId)
        //            .Select(g => g.UserId));

        //    return s.SelectMany(i => users.Where(o => o.Id == i)).ToList();

        //}

    }
}
