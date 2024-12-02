using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Entities
{
    public class Context : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
