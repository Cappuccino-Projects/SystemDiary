using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserDataController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public UserDataController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("Get/All")]
        public List<User> GetAllUsers() 
        {
            return _context
                .GetUsers()?
                .ToList() ?? new List<User>();
        }

        [HttpGet("Get/{publicId}")]
        public User? GetUserDataByPublicId(string publicId)
        {
            Guid id = Guid.Parse(publicId);

            return _context.GetUsers()?
                .Where(user => user.PublicId == id)
                .FirstOrDefault() ?? null;
        }

        [HttpPost("Get/States")]
        public List<UserState> GetUserStates()
        {
            return _context.GetUserStates()?
                .ToList() ?? new List<UserState>();
        }

        [HttpGet("Get/UserState/{publicId}")]
        public UserState? GetUserStateByPublicId(string publicId)
        {
            Guid id = Guid.Parse(publicId);

            var userStateId = _context.GetUsers()?
                .Where(user => user.PublicId == id)?
                .Select(user => user.StateId).FirstOrDefault();

            var result = _context.GetUserStates()?
                .Where(state => state.Id == userStateId)
                .FirstOrDefault();

            return result ?? null;
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
        public UserRole? GetUserRoleByPublicId(string publicId)
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
