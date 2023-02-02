using Models.Abstract;

namespace Models.Groups
{
    public sealed class GroupFormModel : FormAbstract
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
