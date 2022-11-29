using DataBaseContext.Interfaces;
using Forms.Timetable;
using Microsoft.AspNetCore.Mvc;
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

        /// <summary>
        /// Добавляет расписание
        /// </summary>
        [HttpPost("add")]
        public IActionResult AddTimetable(AddTimetableForm form) 
        {
            _context.GetTimeTables().Add(new TimetableModel() 
            {
                Id = Guid.NewGuid(),
                GroupId = form.GroupId,
                Date = form.Date,
                Week = form.Week
            });

            _context.Save();
            return Ok("Расписание добавлено!");
        }

        ///<summary>
        /// Добавление записей в расписание
        ///</summary>
        [HttpGet("add/{timeTableId}/items")]
        public IActionResult AddItemsInTimeTable(string timeTableId, List<AddLessonForm> lessons) 
        {
            //Guid id = Guid.Parse(timeTableId);

            //TimetableModel? timeTable = _context.GetTimeTables()
            //    .Where(g => g.Id == id)
            //    .First();

            //if (timeTable == null)
            //    return BadRequest("Расписание не создано!");

            //lessons.ForEach(item => _context
            //    .GetTableLessons()
            //    .Add(new TimeTableLessonModel() 
            //    {
            //        Id = Guid.NewGuid(),
            //        TimetableId = timeTable.Id,
            //        DisciplineId = item.
            //    }));

            //_context.Save();

            return Ok("Пары добавлены в расписание!");
        }

        /// <summary>
        /// Редактировать 
        /// </summary>
        [HttpGet("edit/{timeTableId}")]
        public IActionResult EditTimeTable(string id, List<AddLessonForm> data) 
        {
            //Guid timeTableId = Guid.Parse(id);

            //var day = _context
            //    .GetTableLessons()
            //    .Where(i => i.TimetableId == timeTableId)
            //    .ToList();
            
            //if (day is null)
            //    return BadRequest("Расписание не найдено!");

            //for (int i = 0; i < day?.Count; i++) {
            //    day[i].DisciplineId = data[i].DisciplineId;
            //    day[i].EducatorId = data[i].EducatorId;
            //    day[i].RoomNumber = data[i].CabinetNumber;
            //}

            //_context.Save();

            return Ok("Изменения успешно внесены!");
        }

        [HttpPost("cabinet/add")]
        public IActionResult AddCabinet(AddCabinetForm addCabinetForm) 
        {
            var isExist = _context.GetCabinets()
                .Where(r => r.Label.Equals(addCabinetForm.Label))
                .Count() > 0;

            if (isExist)
                return BadRequest("Кабинет уже существует!");

            _context.GetCabinets().Add(new() 
            {
                Id = Guid.NewGuid(),
                Label = addCabinetForm.Label,
                Description = addCabinetForm.Description
            });

            _context.Save();

            return Ok("Кабинет добавлен");
        }
    }
}
