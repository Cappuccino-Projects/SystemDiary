using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Users;

namespace WebAPI.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class PermissonController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public PermissonController(IDataBaseContext context) 
        {
            _context = context;
        }

        [HttpPost("Add")]
        public IActionResult AddPermission(UserPermission userPermission) 
        {
            _context.GetUserPermissions()?.Add(userPermission);
            return Ok();
        }

        [HttpPost("Test")]
        public IActionResult Test() 
        {
            return Ok();
        }
    }
}
