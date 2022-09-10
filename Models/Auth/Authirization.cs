using Models.Abstract;

namespace Models.Authirization
{
    public sealed class Authirization : AbstractModel
    {
        public string Login { get; set; } = "";
        
        public string Password { get; set; } = "";
    }
}
