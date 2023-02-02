using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Jurnal;
using Models.Marks;
using Forms.Jurnal;

namespace WebAPI.Controllers.Marks
{
    [Route("api/auth/marks")]
    [ApiController]
    public class MarksController : Controller
    {
        private readonly IDataBaseContext _context;

        public MarksController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("get")]
        public List<MarkModel> GetAllMarks()
        {
            return _context.GetMarks()?.ToList() ?? new List<MarkModel>();
        }

        [HttpPost("get/states")]
        public List<MarkStateModel> GetAllMarkStates() 
        {
            return _context.GetMarkStates()?.ToList() ?? new List<MarkStateModel>();
        }

        [HttpGet("get/{publicId}")]
        public List<JournalMarkModel> GetJurnalMarksByPublicId(string publicId) 
        {
            Guid userPublicId = Guid.Parse(publicId);

            Guid? privateId = _context.GetUsers()?
                .Where(user => user.PublicId == userPublicId)?
                .FirstOrDefault()?.Id;

            var marksCollection = _context.GetJournalMarks()?
                .Where(mark => mark.UserId == privateId)
                .ToList();

            return marksCollection ?? new List<JournalMarkModel>();
        }

        [HttpPost("set")]
        public IActionResult SetJurnalMark(SetJurnalMarkForm jurnalMarkFormModel)
        {

            if (jurnalMarkFormModel.Date > DateTime.Now)
                return BadRequest("Нельзя поставить оценку заранее");

            _context.GetJournalMarks()?
                .Add(new JournalMarkModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = jurnalMarkFormModel.PublicUserId,
                    EducatorId = jurnalMarkFormModel.PublicEducatorId,
                    MarkId = jurnalMarkFormModel.MarkId,
                    Date = jurnalMarkFormModel.Date
                });

            _context.Save();

            return Ok();
        }
    }
}
