using System.Security;
using Microsoft.AspNetCore.Identity;

namespace Api.Models.Entities
{
    public partial class User : IdentityUser<Guid>
    {
      
        public string Login { get; set; }
    }
}
