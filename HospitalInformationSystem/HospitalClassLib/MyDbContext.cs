using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib
{
    public class MyDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            String connectionString = "Server=localhost; Port =8080; Database =psw_database; User Id = postgres; Password =wasd;";
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Allergen>().HasData(
                new Allergen { Id = 1, Name = "Prasina" }
                );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Jovan", LastName = "Jovanovic", Jmbg = "123456799", Username = "jova", Password = "jova", DoctorSpecialization = Specialization.FamilyPhysician },
                new Doctor { Id = 2, Name = "Milan", LastName = "Ilic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.FamilyPhysician }
                );
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Pera", LastName = "Peric", Jmbg = "123456789", Username = "pera", Password = "pera", DateOfBirth = DateTime.Now, Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), IsActivated = false, Token = "ABC123DEF4AAAAC" }
                );
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, Content = "Tekst neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false },
                new Feedback { Id = 2, Content = "Drugi neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false }
            );
        }

    }
}
