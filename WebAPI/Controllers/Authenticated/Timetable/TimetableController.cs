using DataBaseContext.Interfaces;
using Forms.Tamitable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;
using Models.Timetable;

namespace WebAPI.Controllers.Authenticated.Timetable
{
    [Route("api/auth/timetable")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public TimetableController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("add")]
        public IActionResult AddTimetable(AddTimetableForm form) 
        {

            var groupId = _context
                .GetGroups()
                .Where(g => g.Name == form.Group)
                .First().Id;

            _context.GetTimetable().Add(new TimeTableModel() 
            {
                Id = Guid.NewGuid(),
                GroupId = groupId,
                Date = form.Date,
                Week = form.Week
            });


            _context.Save();
            return Ok("Расписание добавлено!");
        }

        [HttpGet("add/{timeTableId}/items")]
        public IActionResult AddItemsInTimeTable(string timeTableId, List<LessonForm> lessons) 
        {



            return Ok("Пары добавлены в расписание!");
        }

    }
}
