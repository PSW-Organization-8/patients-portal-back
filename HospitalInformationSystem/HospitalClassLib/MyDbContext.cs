using HospitalClassLib.MedicalRecords.Model;
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
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<SharedModel.Equipment> Equipments { get; set; }
        public DbSet<MoveEquipment> MoveEquipments { get; set; }

        public DbSet<SharedModel.Shift> Shifts { get; set; }

        public DbSet<VacationPeriod> Vacations { get; set; }






        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? "integration";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "root";

            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
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
                new Patient { Id = 1, Name = "Pera", LastName = "Peric", Jmbg = "123456789", Username = "pera", Password = "pera", Email = "pera.peric@gmail.com", Phone = "054987332", DateOfBirth = new DateTime(1999, 10, 11), Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), IsActivated = true, Token = "ABC123DEF4AAAAC12345" },
                new Patient { Id = 2, Name = "Mare", LastName = "Maric", Jmbg = "213456789", Username = "mare", Password = "maric", Email = "pera2.peric@gmail.com", Phone = "054987332", DateOfBirth = new DateTime(1999, 10, 11), Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), IsActivated = true, Token = "ABC213DEF4AAAAC12345" }
                );

            modelBuilder.Entity<SharedModel.Shift>().HasData(
                new SharedModel.Shift { ID = 1, ShiftType="Morning shift", ShiftStart = "7:00", ShiftEnd = "13:00"},
                new SharedModel.Shift { ID = 2, ShiftType = "Afternoon shift", ShiftStart = "13:00", ShiftEnd = "20:00" },
                new SharedModel.Shift { ID = 3, ShiftType = "Night shift", ShiftStart = "20:00", ShiftEnd = "7:00" }
                 );

            modelBuilder.Entity<VacationPeriod>().HasData(
               new VacationPeriod { ID = 1, VacationDescription = "Summer Vacation", StartTime = new DateTime(2022, 6, 6), EndTime = new DateTime(2022, 16, 6) },
               new VacationPeriod { ID = 2, VacationDescription = "Winter Vacation", StartTime = new DateTime(2022, 1, 12), EndTime = new DateTime(2022, 10, 12) },
               new VacationPeriod { ID = 3, VacationDescription = "Ski Trip", StartTime = new DateTime(2022, 5, 1), EndTime = new DateTime(2022, 15, 1) },
               new VacationPeriod { ID = 4, VacationDescription = "Summer Vacation", StartTime = new DateTime(2022, 10, 8), EndTime = new DateTime(2022, 20, 8) }
                );
            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, Content = "Tekst neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false },
                new Feedback { Id = 2, Content = "Drugi neki", IsApproved = true, Date = DateTime.Now, PatientId = 1, IsPublishable = true, IsAnonymous = false }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, StartTime = DateTime.Now, State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 1, IsSurveyed = false },
                new Appointment { Id = 2, StartTime = new DateTime(2021, 12, 15, 10, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 6, PatientId = 1, IsSurveyed = false },
                new Appointment { Id = 3, StartTime = new DateTime(2021, 12, 15, 13, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 6, PatientId = 1, IsSurveyed = false },
                new Appointment { Id = 4, StartTime = new DateTime(2021, 12, 15, 15, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 6, PatientId = 1, IsSurveyed = false },

                new Appointment { Id = 5, StartTime = DateTime.Now, State = AppointmentState.cancelled, Type = AppointmentType.examination, DoctorId = 1, PatientId = 1, IsSurveyed = false },
                new Appointment { Id = 6, StartTime = DateTime.Now, State = AppointmentState.finished, Type = AppointmentType.examination, DoctorId = 1, PatientId = 1, IsSurveyed = false },

                new Appointment { Id = 7, StartTime = DateTime.Now, State = AppointmentState.cancelled, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 8, StartTime = DateTime.Now, State = AppointmentState.cancelled, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 9, StartTime = DateTime.Now, State = AppointmentState.cancelled, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 10, StartTime = DateTime.Now, State = AppointmentState.cancelled, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },

                new Appointment { Id = 11, StartTime = new DateTime(2022, 1, 1, 8, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 12, StartTime = new DateTime(2022, 1, 1, 8, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 13, StartTime = new DateTime(2022, 1, 1, 8, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 14, StartTime = new DateTime(2022, 1, 1, 8, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 15, StartTime = new DateTime(2022, 1, 1, 9, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 16, StartTime = new DateTime(2022, 1, 1, 9, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 17, StartTime = new DateTime(2022, 1, 1, 9, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 18, StartTime = new DateTime(2022, 1, 1, 9, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 19, StartTime = new DateTime(2022, 1, 1, 10, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 20, StartTime = new DateTime(2022, 1, 1, 10, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 21, StartTime = new DateTime(2022, 1, 1, 10, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 22, StartTime = new DateTime(2022, 1, 1, 10, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 23, StartTime = new DateTime(2022, 1, 1, 11, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 24, StartTime = new DateTime(2022, 1, 1, 11, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 25, StartTime = new DateTime(2022, 1, 1, 11, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 26, StartTime = new DateTime(2022, 1, 1, 11, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 27, StartTime = new DateTime(2022, 1, 1, 12, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 28, StartTime = new DateTime(2022, 1, 1, 12, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 29, StartTime = new DateTime(2022, 1, 1, 12, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 30, StartTime = new DateTime(2022, 1, 1, 12, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 31, StartTime = new DateTime(2022, 1, 1, 13, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 32, StartTime = new DateTime(2022, 1, 1, 13, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 33, StartTime = new DateTime(2022, 1, 1, 13, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 34, StartTime = new DateTime(2022, 1, 1, 13, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 35, StartTime = new DateTime(2022, 1, 1, 14, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 36, StartTime = new DateTime(2022, 1, 1, 14, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 37, StartTime = new DateTime(2022, 1, 1, 14, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 38, StartTime = new DateTime(2022, 1, 1, 14, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 39, StartTime = new DateTime(2022, 1, 1, 15, 0, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 40, StartTime = new DateTime(2022, 1, 1, 15, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 41, StartTime = new DateTime(2022, 1, 1, 15, 30, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false },
                new Appointment { Id = 42, StartTime = new DateTime(2022, 1, 1, 15, 45, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 2, IsSurveyed = false }
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
            modelBuilder.Entity<Medication>().HasData(new Medication { MedicineID = 1, Name = "Synthroid", Quantity = 2 });

            modelBuilder.Entity<Receipt>().HasData(
                new Receipt { ReceiptID = 1, MedicineName = "Synthroid", Amount = 1, Diagnosis = "Korona", Date = DateTime.Today, PatientId = 1, DoctorId = 1}
            );

        }
    }
}
