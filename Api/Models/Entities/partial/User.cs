using Microsoft.AspNetCore.Identity;

namespace Api.Models.Entities
{
    public partial class User : IdentityUser<Guid>
    {
        public string FullName => string.IsNullOrEmpty(Patronymic) ? $"{LastName} {FirstName}" : $"{LastName} {FirstName} {Patronymic}";
    }
}
