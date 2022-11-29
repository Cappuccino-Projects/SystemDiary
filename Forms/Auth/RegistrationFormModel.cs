using Forms.Abstract;
using Models.Enums;

namespace Forms.Auth
{
    public sealed class RegistrationFormModel : FormAbstract
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string FatherName { get; set; } = "";
        public string Login { get; set; } = "";
        public DateTime Birth { get; set; }
        public Genders Gender { get; set; }
        public string Email { get; set; } = "";
        public string PasswordOriginal { get; set; } = "";
        public string PasswordDoublicate { get; set; } = "";
    }
}
