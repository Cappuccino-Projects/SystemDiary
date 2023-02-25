using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cappuccino.SystemDiary.WebAPI.Controllers.Authenticated.Associations
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupAndStudentAssociateController : ControllerBase
    {
        private readonly IDataBaseContext _databaseContext;

        public GroupAndStudentAssociateController(IDataBaseContext dataBaseContext)
        {
            _databaseContext = dataBaseContext;
        }

        //[HttpPost("Get/All")]
        //public List<GroupAndStudentAssociateModel> GetAllGroupAndStudents() 
        //{
        //    return _databaseContext
        //        .GetGroupsAndUsers()
        //        .ToList();
        //}

        //HttpGet("Get/{id}")]
        //ublic List<GroupAndStudentAssociateModel> GetGroupAndStudentsByGroupId(string id)
        //
        //   Guid associateId = Guid.Parse(id);
        //
        //   return _databaseContext
        //       .GetGroupsAndUsers()
        //       .Where(a => a.Id == associateId)
        //       .ToList();
        //
    }
}
