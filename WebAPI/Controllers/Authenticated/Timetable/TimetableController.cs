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

        //TODO: Дописать
        public List<>

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
        ///<summary>
        /// 
        ///</summary>
        [HttpGet("add/{timeTableId}/items")]
        public IActionResult AddItemsInTimeTable(string timeTableId, List<LessonForm> lessons) 
        {
            Guid id = Guid.Parse(timeTableId);

            TimeTableModel? timeTable = _context.GetTimeTable()
                .Where(g => g.Id == id)
                .First();

            if (timeTable == null)
                return BadRequest("Расписание не создано!");

            lessons.ForEach(item => _context.GetTimeTableLessonModel().Add(item));

            _context.Save();

            return Ok("Пары добавлены в расписание!");
        }

        [HttpGet("edit/{timeTableId}")]
        public IActionResult EditTimeTable(string id, List<LessonForm> data) 
        {
            Guid id = Guid.Parse(id);

            var day = _context
                .GetTimeTableLessonModel()
                .Where(i => i.TimetableId == id)
                .ToList();
            
            if (!day)
                return BadRequest("Расписание не найдено!");

            for (int i = 0; i < day.Lenght(); i++) {
                day[i].DisciplineId = data[i].DisciplineId;
                day[i].EducatorId = data[i].EducatorId;
                day[i].CabinetNumber = data[i].CabinetNumber;
            }

            _context.Save();

            return Ok("Изменения успешно внесены!");
        }

    }
}
