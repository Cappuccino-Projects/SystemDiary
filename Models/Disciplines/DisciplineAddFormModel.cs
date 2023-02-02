using Models.Abstract;

namespace Models.Disciplines
{
    public sealed class DisciplineAddFormModel : FormAbstract
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
