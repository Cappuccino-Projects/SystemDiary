using ClientAPI;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Disciplines;

namespace SystemDiaryClient.Pages
{
    public class Disciplines : PageModel
    {
        public List<DisciplineModel> DisciplinesModels { get; set; }

        private readonly Client _client;

        public Disciplines() 
        {
            _client = new Client();
        }

        public void OnGetAsync()
        {
            DisciplinesModels = _client.GetAllDisciplines().Result ?? new List<DisciplineModel>();
        }
    }
}
