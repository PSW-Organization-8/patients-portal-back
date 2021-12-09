﻿// <auto-generated />
using System;
using HospitalClassLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211206161814_firstMigrtion")]
    partial class firstMigrtion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AllergenPatient", b =>
                {
                    b.Property<int>("AllergensId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientsId")
                        .HasColumnType("integer");

                    b.HasKey("AllergensId", "PatientsId");

                    b.HasIndex("PatientsId");

                    b.ToTable("AllergenPatient");
                });

            modelBuilder.Entity("HospitalClassLib.MedicalRecords.Model.Medication", b =>
                {
                    b.Property<long>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("MedicineID");

                    b.ToTable("Medications");

                    b.HasData(
                        new
                        {
                            MedicineID = 1L,
                            Name = "Synthroid",
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 1,
                            PatientId = 1,
                            StartTime = new DateTime(2021, 12, 6, 17, 18, 13, 536, DateTimeKind.Local).AddTicks(6838),
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 6,
                            PatientId = 1,
                            StartTime = new DateTime(2021, 12, 15, 10, 15, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 6,
                            PatientId = 1,
                            StartTime = new DateTime(2021, 12, 15, 13, 15, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            DoctorId = 6,
                            PatientId = 1,
                            StartTime = new DateTime(2021, 12, 15, 15, 45, 0, 0, DateTimeKind.Unspecified),
                            Type = 0
                        });
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublishable")
                        .HasColumnType("boolean");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Feedbacks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Tekst neki",
                            Date = new DateTime(2021, 12, 6, 17, 18, 13, 533, DateTimeKind.Local).AddTicks(625),
                            IsAnonymous = false,
                            IsApproved = true,
                            IsPublishable = true,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Drugi neki",
                            Date = new DateTime(2021, 12, 6, 17, 18, 13, 536, DateTimeKind.Local).AddTicks(5767),
                            IsAnonymous = false,
                            IsApproved = true,
                            IsPublishable = true,
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Guest")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBanned")
                        .HasColumnType("boolean");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Lbo")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BloodType = 0,
                            DateOfBirth = new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = 1,
                            Email = "pera.peric@gmail.com",
                            Guest = false,
                            IsActivated = true,
                            IsBanned = false,
                            Jmbg = "123456789",
                            LastName = "Peric",
                            Name = "Pera",
                            Password = "pera",
                            Phone = "054987332",
                            Token = "ABC123DEF4AAAAC12345",
                            Username = "pera"
                        });
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Question", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("SurveyId")
                        .HasColumnType("integer");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id", "SurveyId");

                    b.HasIndex("SurveyId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SurveyId = 1,
                            Category = 0,
                            Text = "How would you rate doctors professionalism?",
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            SurveyId = 1,
                            Category = 0,
                            Text = "How would you rate doctors politeness?",
                            Value = 2
                        },
                        new
                        {
                            Id = 3,
                            SurveyId = 1,
                            Category = 0,
                            Text = "How would you rate doctors technicality?",
                            Value = 1
                        },
                        new
                        {
                            Id = 4,
                            SurveyId = 1,
                            Category = 0,
                            Text = "How would you rate doctors skill?",
                            Value = 1
                        },
                        new
                        {
                            Id = 5,
                            SurveyId = 1,
                            Category = 0,
                            Text = "How would you rate doctors knowledge?",
                            Value = 1
                        },
                        new
                        {
                            Id = 6,
                            SurveyId = 1,
                            Category = 1,
                            Text = "How would you rate hospital environment?",
                            Value = 1
                        },
                        new
                        {
                            Id = 7,
                            SurveyId = 1,
                            Category = 1,
                            Text = "How would you rate hospital equipment?",
                            Value = 1
                        },
                        new
                        {
                            Id = 8,
                            SurveyId = 1,
                            Category = 1,
                            Text = "How would you rate hospital hygiene?",
                            Value = 1
                        },
                        new
                        {
                            Id = 9,
                            SurveyId = 1,
                            Category = 1,
                            Text = "How would you rate hospital prices?",
                            Value = 1
                        },
                        new
                        {
                            Id = 10,
                            SurveyId = 1,
                            Category = 1,
                            Text = "How would you rate hospital waiting time?",
                            Value = 1
                        },
                        new
                        {
                            Id = 11,
                            SurveyId = 1,
                            Category = 2,
                            Text = "How would you rate medical staffs professionalism?",
                            Value = 1
                        },
                        new
                        {
                            Id = 12,
                            SurveyId = 1,
                            Category = 2,
                            Text = "How would you rate medical staffs politeness?",
                            Value = 1
                        },
                        new
                        {
                            Id = 13,
                            SurveyId = 1,
                            Category = 2,
                            Text = "How would you rate medical staffs technicality?",
                            Value = 1
                        },
                        new
                        {
                            Id = 14,
                            SurveyId = 1,
                            Category = 2,
                            Text = "How would you rate medical staffs skill?",
                            Value = 1
                        },
                        new
                        {
                            Id = 15,
                            SurveyId = 1,
                            Category = 2,
                            Text = "How would you rate medical staffs knowledge?",
                            Value = 4
                        },
                        new
                        {
                            Id = 1,
                            SurveyId = 2,
                            Category = 0,
                            Text = "How would you rate doctors professionalism?",
                            Value = 1
                        },
                        new
                        {
                            Id = 2,
                            SurveyId = 2,
                            Category = 0,
                            Text = "How would you rate doctors politeness?",
                            Value = 3
                        },
                        new
                        {
                            Id = 3,
                            SurveyId = 2,
                            Category = 0,
                            Text = "How would you rate doctors technicality?",
                            Value = 1
                        },
                        new
                        {
                            Id = 4,
                            SurveyId = 2,
                            Category = 0,
                            Text = "How would you rate doctors skill?",
                            Value = 1
                        },
                        new
                        {
                            Id = 5,
                            SurveyId = 2,
                            Category = 0,
                            Text = "How would you rate doctors knowledge?",
                            Value = 1
                        },
                        new
                        {
                            Id = 6,
                            SurveyId = 2,
                            Category = 1,
                            Text = "How would you rate hospital environment?",
                            Value = 1
                        },
                        new
                        {
                            Id = 7,
                            SurveyId = 2,
                            Category = 1,
                            Text = "How would you rate hospital equipment?",
                            Value = 1
                        },
                        new
                        {
                            Id = 8,
                            SurveyId = 2,
                            Category = 1,
                            Text = "How would you rate hospital hygiene?",
                            Value = 1
                        },
                        new
                        {
                            Id = 9,
                            SurveyId = 2,
                            Category = 1,
                            Text = "How would you rate hospital prices?",
                            Value = 1
                        },
                        new
                        {
                            Id = 10,
                            SurveyId = 2,
                            Category = 1,
                            Text = "How would you rate hospital waiting time?",
                            Value = 1
                        },
                        new
                        {
                            Id = 11,
                            SurveyId = 2,
                            Category = 2,
                            Text = "How would you rate medical staffs professionalism?",
                            Value = 1
                        },
                        new
                        {
                            Id = 12,
                            SurveyId = 2,
                            Category = 2,
                            Text = "How would you rate medical staffs politeness?",
                            Value = 1
                        },
                        new
                        {
                            Id = 13,
                            SurveyId = 2,
                            Category = 2,
                            Text = "How would you rate medical staffs technicality?",
                            Value = 1
                        },
                        new
                        {
                            Id = 14,
                            SurveyId = 2,
                            Category = 2,
                            Text = "How would you rate medical staffs skill?",
                            Value = 1
                        },
                        new
                        {
                            Id = 15,
                            SurveyId = 2,
                            Category = 2,
                            Text = "How would you rate medical staffs knowledge?",
                            Value = 5
                        });
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Survey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("PatientId");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppointmentId = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            AppointmentId = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("HospitalClassLib.SharedModel.Allergen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Allergens");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Prasina"
                        });
                });

            modelBuilder.Entity("HospitalClassLib.SharedModel.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<int>("DoctorSpecialization")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorSpecialization = 0,
                            Jmbg = "123456799",
                            LastName = "Jovanovic",
                            Name = "Jovan",
                            Password = "jova",
                            Username = "jova"
                        },
                        new
                        {
                            Id = 2,
                            DoctorSpecialization = 0,
                            Jmbg = "123756799",
                            LastName = "Ilic",
                            Name = "Milan",
                            Password = "mico",
                            Username = "mico"
                        },
                        new
                        {
                            Id = 3,
                            DoctorSpecialization = 8,
                            Jmbg = "123756799",
                            LastName = "Markovic",
                            Name = "Stevan",
                            Password = "mico",
                            Username = "mico"
                        },
                        new
                        {
                            Id = 4,
                            DoctorSpecialization = 9,
                            Jmbg = "123756799",
                            LastName = "Visnjic",
                            Name = "Nikola",
                            Password = "mico",
                            Username = "mico"
                        },
                        new
                        {
                            Id = 5,
                            DoctorSpecialization = 9,
                            Jmbg = "123756799",
                            LastName = "Mitic",
                            Name = "Strahinja",
                            Password = "mico",
                            Username = "mico"
                        },
                        new
                        {
                            Id = 6,
                            DoctorSpecialization = 2,
                            Jmbg = "123756799",
                            LastName = "Despotovic",
                            Name = "Goran",
                            Password = "mico",
                            Username = "mico"
                        },
                        new
                        {
                            Id = 7,
                            DoctorSpecialization = 7,
                            Jmbg = "123756799",
                            LastName = "Njegos",
                            Name = "Milomir",
                            Password = "mico",
                            Username = "mico"
                        });
                });

            modelBuilder.Entity("HospitalClassLib.SharedModel.Receipt", b =>
                {
                    b.Property<long>("ReceiptID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("text");

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<string>("MedicineName")
                        .HasColumnType("text");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.HasKey("ReceiptID");

                    b.ToTable("Receipts");

                    b.HasData(
                        new
                        {
                            ReceiptID = 1L,
                            Amount = 1,
                            Date = new DateTime(2021, 12, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            Diagnosis = "Korona",
                            DoctorId = 1,
                            MedicineName = "Synthroid",
                            PatientId = 1
                        });
                });

            modelBuilder.Entity("AllergenPatient", b =>
                {
                    b.HasOne("HospitalClassLib.SharedModel.Allergen", null)
                        .WithMany()
                        .HasForeignKey("AllergensId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalClassLib.Schedule.Model.Patient", null)
                        .WithMany()
                        .HasForeignKey("PatientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Appointment", b =>
                {
                    b.HasOne("HospitalClassLib.SharedModel.Doctor", "Doctor")
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalClassLib.Schedule.Model.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Feedback", b =>
                {
                    b.HasOne("HospitalClassLib.Schedule.Model.Patient", "Patient")
                        .WithMany("Feedbacks")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Patient", b =>
                {
                    b.HasOne("HospitalClassLib.SharedModel.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Question", b =>
                {
                    b.HasOne("HospitalClassLib.Schedule.Model.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Survey", b =>
                {
                    b.HasOne("HospitalClassLib.Schedule.Model.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalClassLib.Schedule.Model.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("HospitalClassLib.Schedule.Model.Survey", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("HospitalClassLib.SharedModel.Doctor", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
