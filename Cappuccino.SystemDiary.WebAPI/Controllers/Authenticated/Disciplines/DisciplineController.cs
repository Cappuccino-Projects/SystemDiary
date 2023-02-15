using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Disciplines;
using Forms.Disciplines;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers.Disciplines
{
    /// <summary> 
    /// Контроллер отвечающий за работу с дисциплинами
    /// </summary>
    [ApiController]
    [Route("api/auth/discipline")]
    public sealed class DisciplineController : ControllerBase
    {

        private readonly IDataBaseContext _context;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public DisciplineController(IDataBaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Порлучение списка дисциплин<br/>
        /// <remarks>
        /// POST: api/auth/discipline/get/all
        /// </remarks>
        /// </summary>
        [HttpPost("get/all"), Authorize]
        public IActionResult GetAllDisciplines()
        {
            // Если пользователь не авторизован, возвращать ошибку
            if (!User.Identity.IsAuthenticated)
                return BadRequest();

            // Получение списка дисциплин
            var list = _context.GetDisciplines()?.ToList() ?? new List<DisciplineModel>();

            // Возвращение результата
            return Ok(list);
        }

        /// <summary>
        /// Создание дисциплины<br/>
        /// <remarks>
        /// POST: api/auth/discipline/add
        /// </remarks>
        /// </summary>
        [HttpPost("add"), Authorize(Roles = "Администратор")]
        public IActionResult Create([FromForm] DisciplineAddForm discipline) 
        {
            // если аргумент пустой вернуть ошибку
            if (discipline == null)
                return BadRequest("Ошибка объекта! IS_NULL");

            // Создание модели для БД
            DisciplineModel model = new DisciplineModel()
            {
                Id = Guid.NewGuid(),
                StateId = GetActiveState(),
                Name = discipline.Name,
                Description = discipline.Description
            };

            // Добавление дисциплины
            var disciplines = _context.GetDisciplines()?
                .Add(model);

            // Сохранение данных
            _context.Save();

            // Возвращение результата
            return Ok("Дисциплина успешно добавлена!");
        }

        /// <summary>
        /// Получение активного состояния<br/>
        /// </summary>
        [NonAction]
        private Guid GetActiveState() 
        {
            // Поиск состояния
            return _context.GetDisciplineStates()
                .Where(d => d.Name == "Активная")
                .First().Id;
        }

    }
}