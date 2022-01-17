using HospitalClassLib.MedicalRecords.Model;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.SharedModel;
using HospitalClassLib.SharedModel.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassLib
{
    public class MyDbContext : DbContext
    {
        #region image
        public String ConvertImageURLToBase64(String url)
        {
            StringBuilder _sb = new StringBuilder();

            Byte[] _byte = this.GetImage(url);

            _sb.Append(Convert.ToBase64String(_byte, 0, _byte.Length));

            return _sb.ToString();
        }

        private byte[] GetImage(string url)
        {
            Stream stream = null;
            byte[] buf;

            try
            {
                WebProxy myProxy = new WebProxy();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                stream = response.GetResponseStream();

                using (BinaryReader br = new BinaryReader(stream))
                {
                    int len = (int)(response.ContentLength);
                    buf = br.ReadBytes(len);
                    br.Close();
                }

                stream.Close();
                response.Close();
            }
            catch (Exception exp)
            {
                buf = null;
            }

            return (buf);
        }
        #endregion image
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Allergen> Allergens { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String server = Environment.GetEnvironmentVariable("SERVER") ?? "localhost";
            String port = Environment.GetEnvironmentVariable("DB_PORT") ?? "8080";
            String databaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? "psw_database";
            String username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
            String password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "wasd";

            String connectionString = $"Server={server}; Port ={port}; Database ={databaseName}; User Id = {username}; Password ={password};";
            optionsBuilder.UseNpgsql(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Address)
                            .Property(p => p.Country).HasColumnName("Country");
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Address)
                            .Property(p => p.City).HasColumnName("City");
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Address)
                            .Property(p => p.Street).HasColumnName("Street");

            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Address)
                            .Property(p => p.Country).HasColumnName("Country");
            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Address)
                            .Property(p => p.City).HasColumnName("City");
            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Address)
                            .Property(p => p.Street).HasColumnName("Street");

            modelBuilder.Entity<Manager>().OwnsOne(p => p.Address)
                            .Property(p => p.Country).HasColumnName("Country");
            modelBuilder.Entity<Manager>().OwnsOne(p => p.Address)
                            .Property(p => p.City).HasColumnName("City");
            modelBuilder.Entity<Manager>().OwnsOne(p => p.Address)
                            .Property(p => p.Street).HasColumnName("Street");

            modelBuilder.Entity<Patient>().OwnsOne(p => p.Contact)
                            .Property(p => p.Email).HasColumnName("Email");
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Contact)
                            .Property(p => p.Phone).HasColumnName("Phone");

            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Contact)
                            .Property(p => p.Email).HasColumnName("Email");
            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Contact)
                            .Property(p => p.Phone).HasColumnName("Phone");

            modelBuilder.Entity<Manager>().OwnsOne(p => p.Contact)
                            .Property(p => p.Email).HasColumnName("Email");
            modelBuilder.Entity<Manager>().OwnsOne(p => p.Contact)
                            .Property(p => p.Phone).HasColumnName("Phone");

            modelBuilder.Entity<Feedback>().OwnsOne(p => p.FeedbackProperties)
                            .Property(p => p.IsAnonymous).HasColumnName("IsAnonymous");
            modelBuilder.Entity<Feedback>().OwnsOne(p => p.FeedbackProperties)
                            .Property(p => p.IsApproved).HasColumnName("IsApproved");
            modelBuilder.Entity<Feedback>().OwnsOne(p => p.FeedbackProperties)
                            .Property(p => p.IsPublishable).HasColumnName("IsPublishable");

            modelBuilder.Entity<Patient>().OwnsOne(p => p.PatientAccountStatus)
                            .Property(p => p.IsBanned).HasColumnName("IsBanned");
            modelBuilder.Entity<Patient>().OwnsOne(p => p.PatientAccountStatus)
                            .Property(p => p.IsActivated).HasColumnName("IsActivated");

            modelBuilder.Entity<Allergen>().HasData(
                new Allergen { Id = 1, Name = "Prasina", Patients = new List<Patient>() }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Jovan", LastName = "Jovanovic", Jmbg = "123456799", Username = "jova", Password = "jova", DoctorSpecialization = Specialization.FamilyPhysician , Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 2, Name = "Milan", LastName = "Ilic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.FamilyPhysician, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 3, Name = "Stevan", LastName = "Markovic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Gynecologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 4, Name = "Nikola", LastName = "Visnjic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Neurologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 5, Name = "Strahinja", LastName = "Mitic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Neurologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 6, Name = "Goran", LastName = "Despotovic", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Internist, Patients = new List<Patient>(), Appointments = new List<Appointment>() },
                new Doctor { Id = 7, Name = "Milomir", LastName = "Njegos", Jmbg = "123756799", Username = "mico", Password = "mico", DoctorSpecialization = Specialization.Urologist, Patients = new List<Patient>(), Appointments = new List<Appointment>() }
                );
            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Address).HasData(
                new { DoctorId = 1, Country = "Serbia", City = "Novi Sad", Street = "Dr. Ilije Ilica 10" },
                new { DoctorId = 2, Country = "Serbia", City = "Novi Sad", Street = "Nikle Tesle 1" },
                new { DoctorId = 3, Country = "Serbia", City = "Beograd", Street = "Nikole Tesle 5" },
                new { DoctorId = 4, Country = "Serbia", City = "Beograd", Street = "Kosovska 13" },
                new { DoctorId = 5, Country = "Serbia", City = "Beograd", Street = "Dr. Ilije Ilica 10" },
                new { DoctorId = 6, Country = "Serbia", City = "Novi Sad", Street = "Bulevar Oslobodjena 64" },
                new { DoctorId = 7, Country = "Serbia", City = "Sabac", Street = "Nikole Tesle 15" });
            modelBuilder.Entity<Doctor>().OwnsOne(p => p.Contact).HasData(
                new { DoctorId = 1, Email = "jovanjova@gmail.com", Phone = "0640000000" },
                new { DoctorId = 2, Email = "milanilic@gmail.com", Phone = "0640000001" },
                new { DoctorId = 3, Email = "stevanm@gmail.com", Phone = "0640000002" },
                new { DoctorId = 4, Email = "nikolanidzo@gmail.com", Phone = "0640000003" },
                new { DoctorId = 5, Email = "mitic.strahinja@gmail.com", Phone = "0640000004" },
                new { DoctorId = 6, Email = "despotovicgoran123@gmail.com", Phone = "0640000005" },
                new { DoctorId = 7, Email = "milomirnjegos85@gmail.com", Phone = "0640000006" });

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, Name = "Pera", LastName = "Peric", Jmbg = "123456789", Username = "pera", Password = "pera", DateOfBirth = new DateTime(1999, 10, 11), Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), Token = "ABC123DEF4AAAAC12345", Picture=ConvertImageURLToBase64("https://drive.google.com/uc?id=152-ydGEqYAVa3NPav0N-XN6MtK2fwo0Y") },
                new Patient { Id = 2, Name = "Mare", LastName = "Maric", Jmbg = "213456789", Username = "mare", Password = "maric", DateOfBirth = new DateTime(1999, 10, 11), Feedbacks = new List<Feedback>(), DoctorId = 1, Allergens = new List<Allergen>(), Token = "ABC213DEF4AAAAC12345", Picture=""}
                );
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Address).HasData(
                new { PatientId = 1, Country = "Serbia", City = "Novi Sad", Street = "Dr. Sime Milosevica 10" },
                new { PatientId = 2, Country = "Serbia", City = "Novi Sad", Street = "Bulevar Patrijaha Pavla 19" });
            modelBuilder.Entity<Patient>().OwnsOne(p => p.Contact).HasData(
                new { PatientId = 1, Email = "perapera@gmail.com", Phone = "0641230000" },
                new { PatientId = 2, Email = "maremaric@gmail.com", Phone = "0647400000" });
            modelBuilder.Entity<Patient>().OwnsOne(p => p.PatientAccountStatus).HasData(
                new { PatientId = 1, IsActivated = true, IsBanned = false},
                new { PatientId = 2, IsActivated = true, IsBanned = false});

            modelBuilder.Entity<Feedback>().HasData(
                new Feedback { Id = 1, Content = "Tekst neki", Date = DateTime.Now, PatientId = 1},
                new Feedback { Id = 2, Content = "Drugi neki", Date = DateTime.Now, PatientId = 1}
            );
            modelBuilder.Entity<Feedback>().OwnsOne(p => p.FeedbackProperties).HasData(
                new { FeedbackId = 1, IsAnonymous = true, IsPublishable = true, IsApproved = false },
                new { FeedbackId = 2, IsAnonymous = false, IsPublishable = true, IsApproved = false });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, StartTime = new DateTime(2025, 12, 15, 10, 15, 0), State = AppointmentState.pending, Type = AppointmentType.examination, DoctorId = 1, PatientId = 1, IsSurveyed = false },

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

            modelBuilder.Entity<Manager>().HasData(
                            new Manager { Id = 1, Name = "Mitar", LastName = "Brankovic", Username = "mitar", Password = "mitar", Jmbg = "1231231231231"},
                            new Manager { Id = 2, Name = "Radisa", LastName = "Milovcevic", Username = "radisa", Password = "radisa", Jmbg = "1231231238231"}
                        );
            modelBuilder.Entity<Manager>().OwnsOne(p => p.Address).HasData(
                new { ManagerId = 1, Country = "Serbia", City = "Novi Sad", Street = "Dr. Sime Milosevica 20" },
                new { ManagerId = 2, Country = "Serbia", City = "Novi Sad", Street = "Bulevar Patrijaha Pavla 9" });
            modelBuilder.Entity<Manager>().OwnsOne(p => p.Contact).HasData(
                new { ManagerId = 1, Email = "mitarmitar@gmail.com", Phone = "0641230000" },
                new { ManagerId = 2, Email = "radisaradisa@gmail.com", Phone = "0647400000" });

            modelBuilder.Entity<Medication>().HasData(new Medication { MedicineID = 1, Name = "Synthroid", Quantity = 2 });

            modelBuilder.Entity<Receipt>().HasData(
                new Receipt { ReceiptID = 1, MedicineName = "Synthroid", Amount = 1, Diagnosis = "Korona", Date = DateTime.Today, PatientId = 1, DoctorId = 1}
            );

        }
    }
}
