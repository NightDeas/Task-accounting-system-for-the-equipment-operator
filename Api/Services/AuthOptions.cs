using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class AuthOptions
    {
        private const string KEY = "secterik123";
        public const int LIFETIME = 10;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
