using Forms.Abstract;

namespace Forms.Disciplines
{
    public sealed class AssignDisciplineEducatorForm : FormAbstract
    {
        public Guid DisciplineId { get; set; }
        public Guid EducatorId { get; set; }
    }
}
