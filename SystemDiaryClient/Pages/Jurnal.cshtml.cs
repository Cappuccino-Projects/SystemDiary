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

            _subjects.Add("���������� ��������� ����������");
            _subjects.Add("����������� ������");
            _subjects.Add("����������");
            _subjects.Add("���-��");
        }


        public void OnGet()
        {

        }
    }
}
