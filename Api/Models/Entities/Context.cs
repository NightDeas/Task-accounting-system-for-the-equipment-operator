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
            //var users = new List<User>();
            //var employees = new List<Employee>();
            //for (int i = 0; i < 10; i++)
            //{
            //    users.Add(new User()
            //    {
            //        Id = Guid.NewGuid(),
            //        Login = $"login{i}",
            //        UserName = $"userName{i}",
            //        AccessFailedCount = 5,
            //    });
            //    employees.Add(new Employee()
            //    {
            //        Id = Guid.NewGuid(),
            //        FirstName = $"firstName{i}",
            //        LastName = $"lastName{i}",
            //        Patronymic = $"patronymic{i}",
            //        UserId = users[i].Id,
            //    });
            //}

            //builder.Entity<User>().HasData(users);
            //builder.Entity<User>().HasData(employees);

            //builder.Entity<Task>().HasData(new List<Task>()
            //{
            //    new()
            //    {
            //        Id = Guid.NewGuid(),
            //        Created = DateTime.Now,
            //        DeadLine = DateTime.Now.AddDays(Random.Shared.Next(1,15)),
            //        Description = "Description",
            //        IsCompleted = false,
            //        EmployeeId = employees[0].Id
            //    },
            //      new()
            //    {
            //        Id = Guid.NewGuid(),
            //        Created = DateTime.Now,
            //        DeadLine = DateTime.Now.AddDays(Random.Shared.Next(1,15)),
            //        Description = "Description 2",
            //        IsCompleted = false,
            //        EmployeeId = employees[0].Id
            //    },
            //         new()
            //    {
            //        Id = Guid.NewGuid(),
            //        Created = DateTime.Now,
            //        DeadLine = DateTime.Now.AddDays(Random.Shared.Next(1,15)),
            //        Description = "Description 3",
            //        IsCompleted = false,
            //        EmployeeId = employees[0].Id
            //    },
            //});

            base.OnModelCreating(builder);
        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }  

    }
}
