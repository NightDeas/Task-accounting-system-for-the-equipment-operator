using System.Security;
using Microsoft.AspNetCore.Identity;

namespace Api.Models.Entities
{
    public partial class User : IdentityUser<Guid>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Patronymic { get; set; }
        public string Login { get; set; }
    }
}
