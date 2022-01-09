using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoctorSpecialization = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicineID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicineID);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ReceiptID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineName = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ReceiptID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    IsBanned = table.Column<bool>(type: "boolean", nullable: true),
                    IsActivated = table.Column<bool>(type: "boolean", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergenPatient",
                columns: table => new
                {
                    AllergensId = table.Column<int>(type: "integer", nullable: false),
                    PatientsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergenPatient", x => new { x.AllergensId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Allergens_AllergensId",
                        column: x => x.AllergensId,
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    IsSurveyed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: true),
                    IsPublishable = table.Column<bool>(type: "boolean", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Surveys_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    SurveyId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => new { x.Id, x.SurveyId });
                    table.ForeignKey(
                        name: "FK_Questions_Surveys_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Prasina" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DoctorSpecialization", "Jmbg", "LastName", "Name", "Password", "Username", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, 0, "123456799", "Jovanovic", "Jovan", "jova", "jova", "Novi Sad", "Serbia", "Dr. Ilije Ilica 10", "jovanjova@gmail.com", "0640000000" },
                    { 2, 0, "123756799", "Ilic", "Milan", "mico", "mico", "Novi Sad", "Serbia", "Nikle Tesle 1", "milanilic@gmail.com", "0640000001" },
                    { 3, 8, "123756799", "Markovic", "Stevan", "mico", "mico", "Beograd", "Serbia", "Nikole Tesle 5", "stevanm@gmail.com", "0640000002" },
                    { 4, 9, "123756799", "Visnjic", "Nikola", "mico", "mico", "Beograd", "Serbia", "Kosovska 13", "nikolanidzo@gmail.com", "0640000003" },
                    { 5, 9, "123756799", "Mitic", "Strahinja", "mico", "mico", "Beograd", "Serbia", "Dr. Ilije Ilica 10", "mitic.strahinja@gmail.com", "0640000004" },
                    { 6, 2, "123756799", "Despotovic", "Goran", "mico", "mico", "Novi Sad", "Serbia", "Bulevar Oslobodjena 64", "despotovicgoran123@gmail.com", "0640000005" },
                    { 7, 7, "123756799", "Njegos", "Milomir", "mico", "mico", "Sabac", "Serbia", "Nikole Tesle 15", "milomirnjegos85@gmail.com", "0640000006" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Jmbg", "LastName", "Name", "Password", "Username", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, "1231231231231", "Brankovic", "Mitar", "mitar", "mitar", "Novi Sad", "Serbia", "Dr. Sime Milosevica 20", "mitarmitar@gmail.com", "0641230000" },
                    { 2, "1231231238231", "Milovcevic", "Radisa", "radisa", "radisa", "Novi Sad", "Serbia", "Bulevar Patrijaha Pavla 9", "radisaradisa@gmail.com", "0647400000" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicineID", "Name", "Quantity" },
                values: new object[] { 1L, "Synthroid", 2 });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "ReceiptID", "Amount", "Date", "Diagnosis", "DoctorId", "MedicineName", "PatientId" },
                values: new object[] { 1L, 1, new DateTime(2022, 1, 9, 0, 0, 0, 0, DateTimeKind.Local), "Korona", 1, "Synthroid", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "BloodType", "DateOfBirth", "DoctorId", "Jmbg", "LastName", "Name", "Password", "Picture", "Token", "Username", "IsActivated", "IsBanned", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "123456789", "Peric", "Pera", "pera", "", "ABC123DEF4AAAAC12345", "pera", false, false, "Novi Sad", "Serbia", "Dr. Sime Milosevica 10", "perapera@gmail.com", "0641230000" },
                    { 2, 0, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213456789", "Maric", "Mare", "maric", "", "ABC213DEF4AAAAC12345", "mare", false, false, "Novi Sad", "Serbia", "Bulevar Patrijaha Pavla 19", "maremaric@gmail.com", "0647400000" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "IsSurveyed", "PatientId", "StartTime", "State", "Type" },
                values: new object[,]
                {
                    { 1, 1, false, 1, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(3224), 0, 0 },
                    { 23, 1, false, 2, new DateTime(2022, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 24, 1, false, 2, new DateTime(2022, 1, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 25, 1, false, 2, new DateTime(2022, 1, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 26, 1, false, 2, new DateTime(2022, 1, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 27, 1, false, 2, new DateTime(2022, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 28, 1, false, 2, new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 29, 1, false, 2, new DateTime(2022, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 30, 1, false, 2, new DateTime(2022, 1, 1, 12, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 22, 1, false, 2, new DateTime(2022, 1, 1, 10, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 31, 1, false, 2, new DateTime(2022, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 33, 1, false, 2, new DateTime(2022, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 34, 1, false, 2, new DateTime(2022, 1, 1, 13, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 35, 1, false, 2, new DateTime(2022, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 36, 1, false, 2, new DateTime(2022, 1, 1, 14, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 37, 1, false, 2, new DateTime(2022, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 38, 1, false, 2, new DateTime(2022, 1, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 39, 1, false, 2, new DateTime(2022, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 40, 1, false, 2, new DateTime(2022, 1, 1, 15, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 32, 1, false, 2, new DateTime(2022, 1, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 21, 1, false, 2, new DateTime(2022, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 20, 1, false, 2, new DateTime(2022, 1, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 19, 1, false, 2, new DateTime(2022, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 2, 6, false, 1, new DateTime(2025, 12, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 3, 6, false, 1, new DateTime(2021, 12, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 4, 6, false, 1, new DateTime(2021, 12, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 5, 1, false, 1, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7195), 2, 0 },
                    { 6, 1, false, 1, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7235), 1, 0 },
                    { 7, 1, false, 2, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7252), 2, 0 },
                    { 8, 1, false, 2, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7262), 2, 0 },
                    { 41, 1, false, 2, new DateTime(2022, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 9, 1, false, 2, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7272), 2, 0 },
                    { 11, 1, false, 2, new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 12, 1, false, 2, new DateTime(2022, 1, 1, 8, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 13, 1, false, 2, new DateTime(2022, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 14, 1, false, 2, new DateTime(2022, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 15, 1, false, 2, new DateTime(2022, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 16, 1, false, 2, new DateTime(2022, 1, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 17, 1, false, 2, new DateTime(2022, 1, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 18, 1, false, 2, new DateTime(2022, 1, 1, 9, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 10, 1, false, 2, new DateTime(2022, 1, 9, 21, 16, 24, 807, DateTimeKind.Local).AddTicks(7281), 2, 0 },
                    { 42, 1, false, 2, new DateTime(2022, 1, 1, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "Date", "PatientId", "IsAnonymous", "IsApproved", "IsPublishable" },
                values: new object[,]
                {
                    { 2, "Drugi neki", new DateTime(2022, 1, 9, 21, 16, 24, 806, DateTimeKind.Local).AddTicks(6617), 1, false, true, true },
                    { 1, "Tekst neki", new DateTime(2022, 1, 9, 21, 16, 24, 796, DateTimeKind.Local).AddTicks(6699), 1, true, true, true }
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Date", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "SurveyId", "Category", "Text", "Value" },
                values: new object[,]
                {
                    { 1, 1, 0, "How would you rate doctors professionalism?", 1 },
                    { 13, 2, 2, "How would you rate medical staffs technicality?", 1 },
                    { 12, 2, 2, "How would you rate medical staffs politeness?", 1 },
                    { 11, 2, 2, "How would you rate medical staffs professionalism?", 1 },
                    { 10, 2, 1, "How would you rate hospital waiting time?", 1 },
                    { 9, 2, 1, "How would you rate hospital prices?", 1 },
                    { 8, 2, 1, "How would you rate hospital hygiene?", 1 },
                    { 7, 2, 1, "How would you rate hospital equipment?", 1 },
                    { 6, 2, 1, "How would you rate hospital environment?", 1 },
                    { 5, 2, 0, "How would you rate doctors knowledge?", 1 },
                    { 4, 2, 0, "How would you rate doctors skill?", 1 },
                    { 3, 2, 0, "How would you rate doctors technicality?", 1 },
                    { 2, 2, 0, "How would you rate doctors politeness?", 3 },
                    { 1, 2, 0, "How would you rate doctors professionalism?", 1 },
                    { 15, 1, 2, "How would you rate medical staffs knowledge?", 4 },
                    { 14, 1, 2, "How would you rate medical staffs skill?", 1 },
                    { 13, 1, 2, "How would you rate medical staffs technicality?", 1 },
                    { 12, 1, 2, "How would you rate medical staffs politeness?", 1 },
                    { 11, 1, 2, "How would you rate medical staffs professionalism?", 1 },
                    { 10, 1, 1, "How would you rate hospital waiting time?", 1 },
                    { 9, 1, 1, "How would you rate hospital prices?", 1 },
                    { 8, 1, 1, "How would you rate hospital hygiene?", 1 },
                    { 7, 1, 1, "How would you rate hospital equipment?", 1 },
                    { 6, 1, 1, "How would you rate hospital environment?", 1 },
                    { 5, 1, 0, "How would you rate doctors knowledge?", 1 },
                    { 4, 1, 0, "How would you rate doctors skill?", 1 },
                    { 3, 1, 0, "How would you rate doctors technicality?", 1 },
                    { 2, 1, 0, "How would you rate doctors politeness?", 2 },
                    { 14, 2, 2, "How would you rate medical staffs skill?", 1 },
                    { 15, 2, 2, "How would you rate medical staffs knowledge?", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergenPatient_PatientsId",
                table: "AllergenPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppointmentId",
                table: "Surveys",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PatientId",
                table: "Surveys",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenPatient");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Allergens");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
