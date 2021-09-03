using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace StoreWebAPI.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "StoreWebAPI"; 
        public const string AUDIENCE = "Client"; 
        const string KEY = "mysupersecret_secretkey!123";   
        public const int LIFETIME = 10; 

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
