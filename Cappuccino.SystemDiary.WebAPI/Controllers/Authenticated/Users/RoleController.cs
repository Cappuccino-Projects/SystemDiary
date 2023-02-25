using DataBaseContext.Interfaces;
using Forms.Users;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace Cappuccino.SystemDiary.WebAPI.Controllers.Authenticated.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class RoleController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public RoleController(IDataBaseContext context) 
        {
            _context = context;
        }

        [HttpPost("Add")]
        public void AddRole(UserRoleForm role)
        { 
            _context.GetUserRoles()?
                .Add(new() 
                {
                    Id = Guid.NewGuid(),
                    Name = role.Name,
                    BackendName = role.BackendName,
                    Description = role.Description
                });

            _context.Save();
        }

        [HttpPost("Get/All")]
        public List<UserRoleModel> GetUserRoles()
        {
            return _context.GetUserRoles()?
                .ToList() ?? new List<UserRoleModel>();
        }

        [HttpPost("Get/{roleId}")]
        public List<UserModel> GetUsersWithRole(string roleId)
        {
            Guid id = Guid.Parse(roleId);

            return _context
                .GetUsers()
                .Where(u => u.RoleId == id)
                .ToList();
        }

        [HttpPost("Get/Safe")]
        public List<UserRoleModel> GetSafeRoles() 
        {
            return _context
                .GetUserRoles()
                .Where(r => r.BackendName != "backend_admin")
                .ToList();
        }

    }
}
