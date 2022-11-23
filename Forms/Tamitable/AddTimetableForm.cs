using Forms.Abstract;
using Models.Enums;

namespace Forms.Tamitable
{
    public sealed class AddTimetableForm : FormAbstract
    {
        public string? Group { get; set; }
        public Weeks Week { get; set; }
        public DateTime Date { get; set; }
    }
}
