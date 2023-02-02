using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI.Options
{
    public class JWTOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenLifeTime { get; set; }
        public int RefreshLifetime { get; set; }

        public SymmetricSecurityKey GetSymmericSecurityToken() => 
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}
