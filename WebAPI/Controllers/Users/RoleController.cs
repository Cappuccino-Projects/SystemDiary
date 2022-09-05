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
        public IActionResult AddRole(UserRole role)
        { 
            _context.GetUserRoles()?.Add(role);
            return Ok();
        }
    }
}
