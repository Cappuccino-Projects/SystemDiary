using Models.Abstract;

namespace Models.Auth
{
    public sealed class Registration : AbstractModel
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string FatherName { get; set; } = "";
        public string Login { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordOriginal { get; set; } = "";
        public string PasswordDublicate { get; set; } = "";
    }
}
