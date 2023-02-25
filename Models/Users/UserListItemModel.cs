
using Models.Abstract;

namespace Models.Users;

public sealed class UserListItemModel : ModelAbstract {
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Fathername { get; set; }
    public string? Role { get; set; }
}