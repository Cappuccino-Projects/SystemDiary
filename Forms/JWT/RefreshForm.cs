using Forms.Abstract;

namespace Forms.JWT
{
    public sealed class RefreshForm : FormAbstract
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
