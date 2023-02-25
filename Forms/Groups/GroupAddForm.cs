using Forms.Abstract;

namespace Forms.Groups
{
    public sealed class GroupAddForm : FormAbstract
    {
        public string? Name { get; set; }
        public uint Course { get; set; }
        public string? Description { get; set; }
    }
}
