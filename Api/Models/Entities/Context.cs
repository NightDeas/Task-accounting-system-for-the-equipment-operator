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
<<<<<<< HEAD
            builder.Entity<Role>().HasData(new List<Role>()
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Operator",
                    NormalizedName = "OPERATOR"
                },
                   new()
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
            });

=======
>>>>>>> origin/TaskController

            base.OnModelCreating(builder);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }  

    }
}
