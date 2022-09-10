using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Disciplines;

namespace WebAPI.Controllers.Disciplines
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class DisciplineController : ControllerBase
    {

        private readonly IDataBaseContext _context;

        public DisciplineController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("Get/All")]
        public List<DisciplineModel> GetAllDisciplines()
        {
            return _context.GetDisciplines()?.ToList() ?? new List<DisciplineModel>();
        }

        [HttpPost("Add")]
        public IActionResult Create([FromForm] DisciplineCreateModel discipline) 
        {
            if (discipline == null)
                return BadRequest("Ошибка объекта! IS_NULL");

            DisciplineModel model = new DisciplineModel()
            {
                Id = Guid.NewGuid(),
                StateId = GetActiveState(),
                Name = discipline.Name,
                Description = discipline.Description
            };

            var disciplines = _context.GetDisciplines()?
                .Add(model);

            _context.Save();

            return Ok();
        }

        [NonAction]
        public Guid GetActiveState() 
        {
            return _context.GetDisciplineStates().ToList()[0].Id;
        }

    }
}