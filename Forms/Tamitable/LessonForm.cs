using Forms.Abstract;

namespace Forms.Tamitable
{
    public sealed class LessonForm : FormAbstract
    {
        public string? StartLesson { get; set; }
        public string? EndLesson { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid EducatorId { get; set; }
        public int CabinetNumber { get; set; }
    }
}
