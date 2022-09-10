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
        public void AddPermission(UserPermission userPermission)
        {
            _context.GetUserPermissions()?
                .Add(userPermission);

            _context.Save();
        }

        [HttpPost("Get/All")]
        public List<UserPermission> GetAllPermissions()
        {
            return _context.GetUserPermissions()?
                .ToList() ?? new List<UserPermission>();
        }
    }
}
