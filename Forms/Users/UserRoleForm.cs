using Forms.Abstract;

namespace Forms.Users
{
    public sealed class UserRoleForm : FormAbstract
    {
        public string? Name { get; set; }
        public string? BackendName { get; set; }
        public string? Description { get; set; }
    }
}
