using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemDiaryClient.Pages
{
    public class JurnalModel : PageModel
    {
        public List<string> Subjects { get; set; }

        private List<string> _subjects;

        public JurnalModel() 
        {
            _subjects = new();

            _subjects.Add("Разработка мобильных приложений");
            _subjects.Add("Программные модули");
            _subjects.Add("Математика");
            _subjects.Add("Физ-ра");
        }


        public void OnGet()
        {

        }
    }
}
