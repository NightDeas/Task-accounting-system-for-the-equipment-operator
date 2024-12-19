using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class AuthOptions
    {
        private const string KEY = "secterik123456122345@@@@12312551sdfgfgsreeg";
        public const int LIFETIME = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
