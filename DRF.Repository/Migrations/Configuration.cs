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

            context.Genders.AddOrUpdate(x => x.Id, 
                new Gender() { Id = 1, Name = "Male" },
                new Gender() { Id = 2, Name = "Female" },
                new Gender() { Id = 3, Name = "Others" }
                );

            context.BloodGroups.AddOrUpdate(x => x.Id, 
                new BloodGroup(){ Id = 1, Name = "A+" },
                new BloodGroup(){ Id = 2, Name = "B+" },
                new BloodGroup(){ Id = 3, Name = "O+" },
                new BloodGroup(){ Id = 4, Name = "A-" },
                new BloodGroup(){ Id = 5, Name = "B-" },
                new BloodGroup(){ Id = 6, Name = "O-" },
                new BloodGroup(){ Id = 7, Name = "AB+" },
                new BloodGroup(){ Id = 8, Name = "AB-" }
                );

            #region temporary data add
            //context.Degrees.AddOrUpdate(x => x.Id, 
            //    new Degree(){ Id = 1, Name = "MBBS", Details = "Bachelor of Medicine, Bachelor of Surgery", Status = 1, CreatedAt = DateTime.Now }
            //    );
            //context.Specialties.AddOrUpdate(x => x.Id,
            //    new Specialty(){ Id = 1, Name = "Cardiologist", Disease = "Coronary artery, Heart attack, Heart failure, Heart valve, Congenital heart, Heart muscle",
            //        Details = "Cardiologists are doctors who specialize in diagnosing and treating diseases or conditions of the heart and blood vessels", Status = 1, CreatedAt = DateTime.Now }
            //    );
            //context.Cities.AddOrUpdate(x => x.Id, 
            //    new City(){ Id = 1, Name = "Dhaka North City", Status = 1, CreatedAt = DateTime.Now }
            //    );
            //context.Areas.AddOrUpdate(x => x.Id,
            //    new Area(){ Id = 1,Name = "Panthapath", CityId = 1, Status = 1, CreatedAt = DateTime.Now }
            //    );
            //context.Maps.AddOrUpdate(x => x.Id,
            //    new Map(){ Id = 1, Lat = "23.752921", Long = "90.3816716", Status = 1, CreatedAt = DateTime.Now }
            //    );
            //context.Chambers.AddOrUpdate(x => x.Id, 
            //    new Chamber(){ Id = 1, Name = "Square Hospitals Ltd.",
            //        Address = "18/F, Bir Uttam Qazi Nuruzzaman Sarak West, Panthapath, Dhaka 1205",
            //        AreaId = 1, MapId = 1, Status = 1, CreatedAt = DateTime.Now }
            //    );
            #endregion

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
