using DataBaseContext.Interfaces;
using Forms.Jurnals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Jurnal;

namespace WebAPI.Controllers.Jurnals
{
    [Route("api/auth/journal")]
    [ApiController]
    public class JournalController : ControllerBase
    {
        private readonly IDataBaseContext _context;

        public JournalController(IDataBaseContext context)
        {
            _context = context;
        }

        [HttpPost("get/{id}")]
        public JournalModel GetJurnalById(string id) 
        {
            Guid jurnalId = Guid.Parse(id);

            return _context
                .GetJournals()
                .First(j => j.Id == jurnalId);
        }

        [HttpPost("add")]
        public IActionResult AddNewJurnal([FromForm] AddJurnalForm jurnalForm) 
        {
            _context.GetJournals().Add(new()
            {
                Id = Guid.NewGuid(),
                StateId = _context.GetJournalStates().First(s => s.Name == "Активное состояние").Id,
                GroupId = jurnalForm.GroupId,
                Start = jurnalForm.PeriodStart,
                End = jurnalForm.PeriodEnd
            });

            _context.Save();

            return Ok("Журнал успешно добавлен!");
        }
    }
}
