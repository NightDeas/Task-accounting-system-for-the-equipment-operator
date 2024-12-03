using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api.Models.Entities
{
    public class Context : IdentityDbContext<User, Role, Guid>
    {


        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(new List<Role>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Operator"
                },
                   new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator"
                },
            });


            base.OnModelCreating(builder);
        }

    }
}
