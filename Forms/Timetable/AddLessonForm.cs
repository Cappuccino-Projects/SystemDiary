using Forms.Abstract;

namespace Forms.Timetable
{
    public sealed class AddLessonForm : FormAbstract
    {
        public Guid DisciplineId { get; set; }
        public Guid CabinetId { get; set; }
        public string Start { get; set; } = "00:00";
        public string End { get; set; } = "00:00";
    }
}
