using Forms.Abstract;

namespace Forms.Groups
{
    public sealed class GroupAddUserForm : FormAbstract
    {
        public Guid UserPublicId { get; set; }
        public Guid GroupId { get; set; }
    }
}
