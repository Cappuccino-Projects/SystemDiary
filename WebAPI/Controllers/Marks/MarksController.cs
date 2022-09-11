using DataBaseContext.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Marks;

namespace WebAPI.Controllers.Marks
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : Controller
    {
        private readonly IDataBaseContext _context;

        public MarksController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("Get/All")]
        public List<MarkModel> GetAllMarks()
        {
            return _context.GetMarks()?.ToList() ?? new List<MarkModel>();
        }

        [HttpPost("Get/States/All")]
        public List<MarkStateModel> GetAllMarkStates() 
        {
            return _context.GetMarkStates()?.ToList() ?? new List<MarkStateModel>();
        }
    }
}
