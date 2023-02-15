using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Users;

namespace WebAPI.Controllers.Users
{
    [Route("api/auth/user")]
    [ApiController]
    [AllowAnonymous]
    public class UserDataController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public UserDataController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("get/list")]
        public IActionResult GetAllUsers() 
        {
            IActionResult result = BadRequest("Что-то пошло не так!");

            var userList = _context
                .GetUsers()
                .ToList();

            var roleList = _context
                .GetUserRoles()
                .ToList();

            var readyList = new List<UserListItemModel>();

            //TODO: Заменить на LINQ 
            foreach (var user in userList) 
            {
                readyList.Add(new()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Fathername = user.Fathername,
                    Role = roleList.Where(role => role.Id == user.RoleId).First().Name
                });
            }

            Console.WriteLine(userList.Count);

            if (readyList == null)
                return NotFound("Пользователей не найдено!");
            
            return Ok(readyList);
        }

        [HttpGet("get/{publicId}")]
        public UserModel? GetUserDataByPublicId(string publicId)
        {
            Guid id = Guid.Parse(publicId);

            return _context.GetUsers()?
                .Where(user => user.PublicId == id)
                .FirstOrDefault() ?? null;
        }

        [HttpPost("get/state/list")]
        public IActionResult GetUserStates()
        {
            IActionResult result = BadRequest("Что-то пошло не так!");

            var users = _context.GetUserStates()?
                .ToList();

            if (users == null)
                return BadRequest("Пользователи не найдены!");

            return Ok(users);
        }

        [HttpGet("get/state/{publicId}")]
        public IActionResult GetUserStateByPublicId(string publicId)
        {
            IActionResult result = BadRequest("Что-то пошло не так!");

            Guid id = Guid.Parse(publicId);

            var userStateId = _context.GetUsers()?
                .Where(user => user.PublicId == id)?
                .Select(user => user.StateId).FirstOrDefault();

            var data = _context.GetUserStates()?
                .Where(state => state.Id == userStateId)
                .FirstOrDefault();

            result = Ok(data);

            return result;
        }

        [HttpGet("Get/UserState/{publicId}/Name")]
        public string? GetUserStateNameByPublicId(string publicId) 
        {
            var userId = Guid.Parse(publicId);

            var userStateId = _context.GetUsers()?
                .Where(user => user.PublicId == userId)
                .Select(user => user.StateId)
                .FirstOrDefault();

            var result = _context.GetUserStates()?
                .Where(state => state.Id == userStateId)
                .FirstOrDefault()?.Name;

            return result ?? null;

        }

        [HttpGet("Get/UserRole/{publicId}")]
        public UserRoleModel? GetUserRoleByPublicId(string publicId)
        {
            Guid userId = Guid.Parse(publicId);

            var userRoleId = _context.GetUsers()?
                .Where(user => user.PublicId == userId)
                .Select(user => user.RoleId).FirstOrDefault();

            var result = _context.GetUserRoles()?
                .Where(role => role.Id == userRoleId)
                .FirstOrDefault();

            return result ?? null;
        }

        [HttpGet("Get/UserRole/{publicId}/Name")]
        public string? GetUserRoleNameByPublicId(string publicId)
        {
            Guid userId = Guid.Parse(publicId);

            var userRoleId = _context.GetUsers()?
                .Where(user => user.PublicId == userId)
                .Select(user => user.RoleId)
                .FirstOrDefault();

            var result = _context.GetUserRoles()?
                .Where(role => role.Id == userRoleId)
                .FirstOrDefault()?.Name;

            return result ?? null;
        }
    }
}
