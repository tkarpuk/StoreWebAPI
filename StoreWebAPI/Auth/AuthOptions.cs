using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StoreWebAPI.Auth
{
    public class AuthOptions
    {
        public const string Issuer = "StoreWebAPI"; 
        public const string Audience = "Client"; 
        public const int LifeTime = 10; 
        const string _key = "mysupersecret_secretkey!123";   

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key));
        }
    }
}
