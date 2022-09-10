using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace WebAPI.Controllers.Users
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
        public void AddRole(UserRole role)
        { 
            _context.GetUserRoles()?
                .Add(role);

            _context.Save();
        }

        [HttpPost("Get/All")]
        public List<UserRole> GetUserRoles()
        {
            return _context.GetUserRoles()?
                .ToList() ?? new List<UserRole>();
        }

    }
}
