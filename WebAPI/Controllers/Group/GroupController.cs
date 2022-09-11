using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Associations;
using Models.Groups;
using Models.Users;

namespace WebAPI.Controllers.Group
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
        public void AddGroup([FromForm] GroupFormModel groupForm) 
        {
            GroupModel group = new GroupModel() 
            {
                Id = Guid.NewGuid(),
                GroupStateId = _context.GetGroupStates().ToList()[0].Id,
                Name = groupForm.Name,
                Description = groupForm.Description
            };

            _context.GetGroups()?.Add(group);

            _context.Save();
        }

        [HttpPost("Get/All")]
        public List<GroupModel> GetAllGroupModels() 
        {
            return _context.GetGroups().ToList() ?? new List<GroupModel>();
        }

        [HttpPost("Add/User")]
        public IActionResult AddUserToGroupByPublicID([FromForm] GroupAddFormModel model) 
        {

            Guid? userId = _context?
                .GetUsers()?
                .Where(user => user.PublicId == model.UserPublicId)?
                .FirstOrDefault()?
                .Id;

            if (userId == null)
                return BadRequest("Пользователь не найден!");

            GroupAndUserAssociate associate = new GroupAndUserAssociate() 
            {
                Id = Guid.NewGuid(),
                UserId = userId ?? Guid.NewGuid(),
                GroupId = model.GroupId,
                AssociateStateId = _context.GetAssociateStates().ToList()[0].Id
            };

            _context.GetGroupsAndUsers()?.Add(associate);
            _context.Save();

            return Ok();
        }

    }
}
