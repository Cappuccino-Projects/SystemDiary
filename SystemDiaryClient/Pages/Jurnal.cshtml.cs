using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SystemDiaryClient.Pages
{
    public class JurnalModel : PageModel
    {
        public List<string> Subjects { get => _subjects; set => _subjects = value; }
        public int DaysInThisMonth { get => _daysInThisMonth; set => _daysInThisMonth = value; }

        private List<string> _subjects;
        private int _daysInThisMonth;

        public JurnalModel()
        {
            _subjects = new();

            _subjects.Add("���������� ��������� ����������");
            _subjects.Add("����������� ������");
            _subjects.Add("����������");
            _subjects.Add("���-��");
        }

        public void OnGetAsync()
        {
            _daysInThisMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        }
    }
}


/*
 *  Shut you month!
 */