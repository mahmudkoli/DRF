using DRF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRF.Repository.Context
{
    public class DRFDbContext : DbContext
    {
        public DRFDbContext() : base("DRFDbContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Chamber> Chambers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ConsultationFees> ConsultationFeeses { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<BloodGroup> BloodGroups { get; set; }
        public DbSet<DoctorChamberRelation> DoctorChamberRelations { get; set; }
        public DbSet<DoctorDegreeRelation> DoctorDegreeRelations { get; set; }
        public DbSet<DoctorSpecialtyRelation> DoctorSpecialtyRelations { get; set; }
    }
}
