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
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }

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
                new Allergen { Id = 1, Name = "Prasina", Patients = new List<Patient>() }
                );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Jovan", LastName = "Jovanovic", Jmbg = "123456799", Username = "jova", Password = "jova", DoctorSpecialization = Specialization.FamilyPhysician , Patients = new List<Patient>(), Appointments = new List<Appointment>()},
                new Doctor { Id = 2, Name = "Milan", LastName = "Ilic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.FamilyPhysician, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 3, Name = "Stevan", LastName = "Markovic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Gynecologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 4, Name = "Nikola", LastName = "Visnjic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Neurologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 5, Name = "Strahinja", LastName = "Mitic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Neurologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 6, Name = "Goran", LastName = "Despotovic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Internist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 7, Name = "Milomir", LastName = "Njegos", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Urologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() }
                );
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Pera", LastName = "Peric", Jmbg = "123456789", Username = "pera", Password = "pera", Email = "pera.peric@gmail.com", Phone = "054987332", DateOfBirth = new DateTime(1999, 10, 11), Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), IsActivated = true, Token = "ABC123DEF4AAAAC12345", Appointments = new List<Appointment>() }
                );
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, Content = "Tekst neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false },
                new Feedback { Id = 2, Content = "Drugi neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, StartTime = DateTime.Now, Type = AppointmentType.examination, DoctorId = 1, PatientId = 1}
             );


            modelBuilder.Entity<Survey>().HasData(
                new Survey { Id = 1, PatientId = 1, AppointmentId = 1 },
                new Survey { Id = 2, PatientId = 1, AppointmentId = 1 }
            );


            modelBuilder.Entity<Question>().HasKey(q => new { q.Id, q.SurveyId });

            modelBuilder.Entity<Question>().HasData(
            new Question { Id = 1, Text = "How would you rate doctors professionalism?", Value = 1, Category = QuestionCategory.doctor, SurveyId=1 },
            new Question { Id = 2, Text = "How would you rate doctors politeness?", Value = 2, Category = QuestionCategory.doctor, SurveyId = 1 },
            new Question { Id = 3, Text = "How would you rate doctors technicality?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 1 },
            new Question { Id = 4, Text = "How would you rate doctors skill?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 1 },
            new Question { Id = 5, Text = "How would you rate doctors knowledge?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 1 },
            new Question { Id = 6, Text = "How would you rate hospital environment?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 1 },
            new Question { Id = 7, Text = "How would you rate hospital equipment?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 1 },
            new Question { Id = 8, Text = "How would you rate hospital hygiene?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 1 },
            new Question { Id = 9, Text = "How would you rate hospital prices?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 1 },
            new Question { Id = 10, Text = "How would you rate hospital waiting time?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 1 },
            new Question { Id = 11, Text = "How would you rate medical staffs professionalism?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 1 },
            new Question { Id = 12, Text = "How would you rate medical staffs politeness?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 1 },
            new Question { Id = 13, Text = "How would you rate medical staffs technicality?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 1 },
            new Question { Id = 14, Text = "How would you rate medical staffs skill?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 1 },
            new Question { Id = 15, Text = "How would you rate medical staffs knowledge?", Value = 4, Category = QuestionCategory.medicalStuff, SurveyId = 1 },
                                                            
            new Question { Id = 1,  Text = "How would you rate doctors professionalism?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 2 },
            new Question { Id = 2,  Text = "How would you rate doctors politeness?", Value = 3, Category = QuestionCategory.doctor, SurveyId = 2 },
            new Question { Id = 3,  Text = "How would you rate doctors technicality?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 2 },
            new Question { Id = 4,  Text = "How would you rate doctors skill?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 2 },
            new Question { Id = 5,  Text = "How would you rate doctors knowledge?", Value = 1, Category = QuestionCategory.doctor, SurveyId = 2 },
            new Question { Id = 6,  Text = "How would you rate hospital environment?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 2 },
            new Question { Id = 7,  Text = "How would you rate hospital equipment?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 2 },
            new Question { Id = 8,  Text = "How would you rate hospital hygiene?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 2 },
            new Question { Id = 9,  Text = "How would you rate hospital prices?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 2 },
            new Question { Id = 10, Text = "How would you rate hospital waiting time?", Value = 1, Category = QuestionCategory.hospital, SurveyId = 2 },
            new Question { Id = 11, Text = "How would you rate medical staffs professionalism?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 2 },
            new Question { Id = 12, Text = "How would you rate medical staffs politeness?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 2 },
            new Question { Id = 13, Text = "How would you rate medical staffs technicality?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 2 },
            new Question { Id = 14, Text = "How would you rate medical staffs skill?", Value = 1, Category = QuestionCategory.medicalStuff, SurveyId = 2 },
            new Question { Id = 15, Text = "How would you rate medical staffs knowledge?", Value = 5, Category = QuestionCategory.medicalStuff, SurveyId = 2 }
            );
        }
    }
}
