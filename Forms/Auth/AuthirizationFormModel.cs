using Forms.Abstract;

namespace Forms.Authirization
{
    public sealed class AuthirizationFormModel : FormAbstract
    {
        public string Login { get; set; } = "";
        
        public string Password { get; set; } = "";
    }
}
