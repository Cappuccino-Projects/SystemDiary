using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.News;

namespace WebAPI.Controllers.News
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IDataBaseContext _context;
        private const int activeIndex = 0;

        public NewsController(IDataBaseContext context) 
        {
            _context = context;
        }

        [HttpPost("Create")]
        public IActionResult CreateNewRecord([FromForm] NewsModel news) 
        {
            IActionResult result = BadRequest("Неизвестная ошибка!");

            var count = _context.GetNews()?.Count();

            if (count == 0) 
            {
                SetStartValues(_context.GetNewsStates());
                _context.Save();
            }

            var record = new NewsModel()
            {
                Id = Guid.NewGuid(),
                PublicId = Guid.NewGuid(),
                Title = "",
                Content = ""
            };

            return Ok();
        }

        [HttpGet("Edit/{newsId}")]
        public IActionResult EditRecord(string newsId) 
        {
            return Ok();
        }

        [HttpGet("Remove/{newsId}")]
        public IActionResult RemoveRecorn(string newsId) 
        {
            return Ok();
        }

        [HttpPost("Get/All")]
        public List<NewsModel> GetAllNews() 
        {
            return new List<NewsModel>();
        }

        private void SetStartValues(DbSet<NewsState> states) 
        {
            var activeState = new NewsState() 
            {
                Id = Guid.NewGuid(), 
                Name = "Активная", 
                Description = "Активная новостная запись"
            };

            var deletedState = new NewsState() 
            {
                Id = Guid.NewGuid(),
                Name = "Удалена",
                Description = "Удалённая новостная запись"
            };

            var archivedState = new NewsState() 
            {
                Id = Guid.NewGuid(),
                Name = "Заархивирована",
                Description = "Заархивированая новостная запись"
            };

            states.Add(activeState);
            states.Add(deletedState);
            states.Add(archivedState);
        }
    }
}
