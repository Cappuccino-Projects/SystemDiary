
using Models.Abstract;

public sealed class UserListItemModel : ModelAbstract {
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Fathername { get; set; }
    public string? Role { get; set; }
}