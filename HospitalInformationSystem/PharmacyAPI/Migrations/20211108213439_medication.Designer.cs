﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyClassLib;

namespace PharmacyAPI.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20211108213439_medication")]
    partial class medication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PharmacyClassLib.Model.IngredientQuantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<long>("MedicationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicationId");

                    b.ToTable("IngredientQuantity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 35.399999999999999,
                            MedicationId = 1L
                        },
                        new
                        {
                            Id = 2,
                            Amount = 48.700000000000003,
                            MedicationId = 2L
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.Medication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Medication");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Paracetamol",
                            Quantity = 150,
                            Status = 0
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Analgin",
                            Quantity = 50,
                            Status = 0
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.MedicationIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MedicationIngredient");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Vitamin C"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Fosfor"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Kalcijum"
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.Objection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HopsitalName")
                        .HasColumnType("text");

                    b.Property<long>("ObjectionIdFromHospitalDatabase")
                        .HasColumnType("bigint");

                    b.Property<string>("TextObjection")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Objection");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            HopsitalName = "Ne valja nista",
                            ObjectionIdFromHospitalDatabase = 0L,
                            TextObjection = "Bolnica1"
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.Pharmacy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("text");

                    b.Property<string>("AdressNumber")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Adress = "Rumenačka",
                            AdressNumber = "15",
                            City = "Novi Sad",
                            Name = "Jankovic"
                        },
                        new
                        {
                            Id = 2L,
                            Adress = "Bulevar oslobođenja",
                            AdressNumber = "135",
                            City = "Novi Sad",
                            Name = "Jankovic"
                        },
                        new
                        {
                            Id = 3L,
                            Adress = "Olge Jovanović",
                            AdressNumber = "18a",
                            City = "Beograd",
                            Name = "Jankovic"
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.RegistratedHospital", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.ToTable("RegistratedHospitals");

                    b.HasData(
                        new
                        {
                            Name = "Bolnica1",
                            ApiKey = "fds15d4fs6",
                            Url = "http:localhost:7313"
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.Response", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("HospitalName")
                        .HasColumnType("text");

                    b.Property<long>("ObjectionIdFromHospitalDatabase")
                        .HasColumnType("bigint");

                    b.Property<string>("TextResponse")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Response");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            HospitalName = "Kleveta",
                            ObjectionIdFromHospitalDatabase = 0L,
                            TextResponse = "Bolnica1"
                        });
                });

            modelBuilder.Entity("PharmacyClassLib.Model.IngredientQuantity", b =>
                {
                    b.HasOne("PharmacyClassLib.Model.Medication", null)
                        .WithMany("IngredientQuantities")
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyClassLib.Model.Medication", b =>
                {
                    b.Navigation("IngredientQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}