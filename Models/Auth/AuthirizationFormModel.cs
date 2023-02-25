using Models.Abstract;

namespace Models.Auth
{
    public sealed class AuthirizationFormModel : FormAbstract
    {
        public string Login { get; set; } = "";
        
        public string Password { get; set; } = "";
    }
}
