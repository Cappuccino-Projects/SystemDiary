using Forms.Abstract;
using Models.Enums;

namespace Forms.Timetable
{
    public sealed class AddTimetableForm : FormAbstract
    {
        public Guid GroupId { get; set; }
        public DateTime Date { get; set; }
        public Weeks Week { get; set; }
    }
}
