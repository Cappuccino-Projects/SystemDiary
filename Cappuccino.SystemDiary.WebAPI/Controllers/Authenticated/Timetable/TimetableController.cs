using DataBaseContext.Interfaces;
using Forms.Timetable;
using Microsoft.AspNetCore.Mvc;
using Models.Timetable;

namespace Cappuccino.SystemDiary.WebAPI.Controllers.Authenticated.Timetable
{
    /// <summary>
    /// Контроллер отвечающий за работу с расписанием
    /// </summary>
    [Route("api/auth/timetable")]
    [ApiController]
    public class TimetableController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public TimetableController(IDataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Создание расписания<br/>
        /// <remarks>
        /// POST: api/auth/timetable/add
        /// </remarks>
        /// </summary>
        [HttpPost("add")]
        public IActionResult AddTimetable(AddTimetableForm form) 
        {
            // Добавление данных в таблицу БД
            _context.GetTimeTables().Add(new TimetableModel() 
            {
                Id = Guid.NewGuid(),
                GroupId = form.GroupId,
                Date = form.Date,
                Week = form.Week
            });

            // Сохранение данных
            _context.Save();
            // Отправка ответа
            return Ok("Расписание добавлено!");
        }

        /// <summary>
        /// Добавление записей в расписание<br/>
        /// <remarks>
        /// POST: api/auth/timetable/add
        /// </remarks>
        /// </summary>
        [HttpGet("add/{timeTableId}/items")]
        public IActionResult AddItemsInTimeTable(string timeTableId, List<AddLessonForm> lessons) 
        {
            // Парсим ID расписания
            Guid id = Guid.Parse(timeTableId);

            // Ищем расписание
            TimetableModel? timeTable = _context.GetTimeTables()
                .Where(g => g.Id == id)
                .First();

            // Если расписания не найдено вернём ошибку
            if (timeTable == null)
                return BadRequest("Расписание не создано!");

            // Добавляем пары в расписание
            lessons.ForEach(item => _context
                .GetTimeTableLessons()
                .Add(new TimeTableLessonModel() 
                {
                    Id = Guid.NewGuid(),
                    TimetableId = timeTable.Id,
                    DisciplineId = item.DisciplineId,
                    RoomId = item.CabinetId,
                    EndLesson = item.End,
                    StartLesson = item.Start
                }));

            // Сохраняем данные
            _context.Save();

            // Возвращаем ответ
            return Ok("Пары добавлены в расписание!");
        }

        /// <summary>
        /// Редактирование записей в расписании<br/>
        /// <remarks>
        /// POST: api/auth/timetable/add
        /// </remarks>
        /// </summary>
        [HttpGet("edit/{timeTableId}")]
        public IActionResult EditTimeTable(string id, List<AddLessonForm> data) 
        {
            // Парсим ID расписания
            Guid timeTableId = Guid.Parse(id);

            // Получаем день расписания
            var day = _context
                .GetTimeTableLessons()
                .Where(i => i.TimetableId == timeTableId)
                .ToList();
            
            // Если расписания не найдено вернём ошибку
            if (day is null)
                return BadRequest("Расписание не найдено!");

            // Обновляем данные
            for (int i = 0; i < day?.Count; i++) {
                day[i].DisciplineId = data[i].DisciplineId;
                day[i].EducatorId = data[i].EducatorId;
                day[i].RoomId = data[i].CabinetId;
            }

            // Созраняем данные
            _context.Save();

            // Возвращаем ответ
            return Ok("Изменения успешно внесены!");
        }

        /// <summary>
        /// Контроллер добавления кабинетов
        /// </summary>
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
