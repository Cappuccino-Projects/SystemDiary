﻿using Models.Abstract;
using Models.Enums;

namespace Models.Auth
{
    public sealed class RegistrationFormModel : FormAbstract
    {
        public string Name { get; set; } = "";
        public string Surname { get; set; } = "";
        public string FatherName { get; set; } = "";
        public string Login { get; set; } = "";
        public int Age { get; set; } = 12;
        public Genders Gender { get; set; }
        public string Email { get; set; } = "";
        public string PasswordOriginal { get; set; } = "";
        public string PasswordDoublicate { get; set; } = "";
    }
}
