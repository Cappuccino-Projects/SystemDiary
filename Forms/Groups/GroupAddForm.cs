using Forms.Abstract;

namespace Models.Groups
{
    public sealed class GroupAddForm : FormAbstract
    {
        public string? Name { get; set; }
        public uint Course { get; set; }
        public string? Description { get; set; }
    }
}
