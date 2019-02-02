namespace DRF.Repository.Migrations
{
    using DRF.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DRF.Repository.Context.DRFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DRF.Repository.Context.DRFDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.UserRoles.AddOrUpdate(x => x.Id,
                new UserRole() { Id = 1, Role = "Admin" },
                new UserRole() { Id = 2, Role = "Doctor" },
                new UserRole() { Id = 3, Role = "Patient" }
                );

            context.Users.AddOrUpdate(x => x.Id,
                new User()
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    Password = "eTKy4RawdqVPRShI6qvVhX9hvZV/6KIY+vIW8kyYhbs=", //admin@gmail.com
                    IsEmailVerified = true,
                    UserRoleId = 1,
                    Status = 1,
                    CreatedAt = DateTime.Now
                }
                );
        }
    }
}
