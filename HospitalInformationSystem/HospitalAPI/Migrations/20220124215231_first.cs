using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalAPI.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Hospital");

            migrationBuilder.EnsureSchema(
                name: "Events");

            migrationBuilder.CreateTable(
                name: "Allergens",
                schema: "Hospital",
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
                schema: "Hospital",
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
                name: "Event",
                schema: "Events",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventApplicationName = table.Column<int>(type: "integer", nullable: false),
                    EventClass = table.Column<int>(type: "integer", nullable: false),
                    OptionalEventNumInfo = table.Column<double>(type: "double precision", nullable: false),
                    ChoosenTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorSpecialization = table.Column<int>(type: "integer", nullable: false),
                    DoctorUsername = table.Column<string>(type: "text", nullable: true),
                    Month = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                schema: "Hospital",
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
                schema: "Hospital",
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
                schema: "Hospital",
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
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergenPatient",
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Allergens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergenPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalSchema: "Hospital",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Hospital",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReports",
                schema: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentId = table.Column<int>(type: "integer", nullable: false),
                    Prescription = table.Column<string>(type: "text", nullable: true),
                    Anamnesis = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalReports_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalSchema: "Hospital",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Surveys_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "Hospital",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                schema: "Hospital",
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
                        principalSchema: "Hospital",
                        principalTable: "Surveys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Events",
                table: "Event",
                columns: new[] { "Id", "ChoosenTime", "DoctorSpecialization", "DoctorUsername", "EventApplicationName", "EventClass", "Month", "OptionalEventNumInfo", "TimeStamp", "UserId" },
                values: new object[,]
                {
<<<<<<< HEAD:HospitalInformationSystem/HospitalAPI/Migrations/20220124215231_first.cs
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 1, 0.0, new DateTime(2022, 1, 24, 22, 52, 30, 822, DateTimeKind.Local).AddTicks(339), "username1" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 1, 2, 0.0, new DateTime(2022, 1, 24, 22, 52, 30, 822, DateTimeKind.Local).AddTicks(1620), "username2" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 1, 0, 1.0, new DateTime(2022, 1, 24, 22, 52, 30, 822, DateTimeKind.Local).AddTicks(1639), "username1" }
=======
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 1, 0.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 21L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 9, 0.0, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 22L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 10, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 11, 0.0, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 25L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 1, 0.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 26L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 2, 0.0, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 27L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 3, 0.0, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 28L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 4, 0.0, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 29L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 5, 0.0, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 30L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 6, 0.0, new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 31L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 7, 0.0, new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 32L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 8, 0.0, new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 33L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 9, 0.0, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 34L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 10, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 35L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 3, 11, 0.0, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 36L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 12, 0.0, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 20L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 8, 0.0, new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 19L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 7, 0.0, new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 24L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 12, 0.0, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 17L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 5, 0.0, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 2, 0.0, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 3, 0.0, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 18L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 6, 0.0, new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 5L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 5, 0.0, new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 6L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 6, 0.0, new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 7L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 7, 0.0, new DateTime(2021, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 8L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 8, 0.0, new DateTime(2021, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 9L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 9, 0.0, new DateTime(2021, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 4, 0.0, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 11L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 11, 0.0, new DateTime(2021, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 12, 0.0, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 13L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 1, 0.0, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 14L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 2, 0.0, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 15L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 3, 0.0, new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 16L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 4, 0.0, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" },
                    { 10L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0, 6, 10, 0.0, new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera" }
>>>>>>> ef11504ec7ea5f4d1713e5934406c2ebf0d15704:HospitalInformationSystem/HospitalAPI/Migrations/20220124223950_first.cs
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Allergens",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Prasina" });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Doctors",
                columns: new[] { "Id", "DoctorSpecialization", "Jmbg", "LastName", "Name", "Password", "Username", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 7, 7, "123756799", "Njegos", "Milomir", "mico", "mico", "Sabac", "Serbia", "Nikole Tesle 15", "milomirnjegos85@gmail.com", "0640000006" },
                    { 6, 2, "123756799", "Despotovic", "Goran", "mico", "mico", "Novi Sad", "Serbia", "Bulevar Oslobodjena 64", "despotovicgoran123@gmail.com", "0640000005" },
                    { 5, 9, "123756799", "Mitic", "Strahinja", "mico", "mico", "Beograd", "Serbia", "Dr. Ilije Ilica 10", "mitic.strahinja@gmail.com", "0640000004" },
                    { 4, 9, "123756799", "Visnjic", "Nikola", "mico", "mico", "Beograd", "Serbia", "Kosovska 13", "nikolanidzo@gmail.com", "0640000003" },
                    { 1, 0, "123456799", "Jovanovic", "Jovan", "jova", "jova", "Novi Sad", "Serbia", "Dr. Ilije Ilica 10", "jovanjova@gmail.com", "0640000000" },
                    { 2, 0, "123756799", "Ilic", "Milan", "mico", "mico", "Novi Sad", "Serbia", "Nikle Tesle 1", "milanilic@gmail.com", "0640000001" },
                    { 3, 8, "123756799", "Markovic", "Stevan", "mico", "mico", "Beograd", "Serbia", "Nikole Tesle 5", "stevanm@gmail.com", "0640000002" }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Managers",
                columns: new[] { "Id", "Jmbg", "LastName", "Name", "Password", "Username", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 2, "1231231238231", "Milovcevic", "Radisa", "radisa", "radisa", "Novi Sad", "Serbia", "Bulevar Patrijaha Pavla 9", "radisaradisa@gmail.com", "0647400000" },
                    { 1, "1231231231231", "Brankovic", "Mitar", "mitar", "mitar", "Novi Sad", "Serbia", "Dr. Sime Milosevica 20", "mitarmitar@gmail.com", "0641230000" }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Medications",
                columns: new[] { "MedicineID", "Name", "Quantity" },
                values: new object[] { 1L, "Synthroid", 2 });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Receipts",
                columns: new[] { "ReceiptID", "Amount", "Date", "Diagnosis", "DoctorId", "MedicineName", "PatientId" },
                values: new object[] { 1L, 1, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Local), "Korona", 1, "Synthroid", 1 });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Patients",
                columns: new[] { "Id", "BloodType", "DateOfBirth", "DoctorId", "Jmbg", "LastName", "Name", "Password", "Picture", "Token", "Username", "IsActivated", "IsBanned", "City", "Country", "Street", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "123456789", "Peric", "Pera", "pera", "iVBORw0KGgoAAAANSUhEUgAAAgAAAAIACAYAAAD0eNT6AAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAAyJpVFh0WE1MOmNvbS5hZG9iZS54bXAAAAAAADw/eHBhY2tldCBiZWdpbj0i77u/IiBpZD0iVzVNME1wQ2VoaUh6cmVTek5UY3prYzlkIj8+IDx4OnhtcG1ldGEgeG1sbnM6eD0iYWRvYmU6bnM6bWV0YS8iIHg6eG1wdGs9IkFkb2JlIFhNUCBDb3JlIDUuMy1jMDExIDY2LjE0NTY2MSwgMjAxMi8wMi8wNi0xNDo1NjoyNyAgICAgICAgIj4gPHJkZjpSREYgeG1sbnM6cmRmPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjIj4gPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9IiIgeG1sbnM6eG1wPSJodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvIiB4bWxuczp4bXBNTT0iaHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wL21tLyIgeG1sbnM6c3RSZWY9Imh0dHA6Ly9ucy5hZG9iZS5jb20veGFwLzEuMC9zVHlwZS9SZXNvdXJjZVJlZiMiIHhtcDpDcmVhdG9yVG9vbD0iQWRvYmUgUGhvdG9zaG9wIENTNiAoV2luZG93cykiIHhtcE1NOkluc3RhbmNlSUQ9InhtcC5paWQ6QzhEMkY2OThDMzhCMTFFMjhEQzU4MzcyQjg3MEQxOTQiIHhtcE1NOkRvY3VtZW50SUQ9InhtcC5kaWQ6QzhEMkY2OTlDMzhCMTFFMjhEQzU4MzcyQjg3MEQxOTQiPiA8eG1wTU06RGVyaXZlZEZyb20gc3RSZWY6aW5zdGFuY2VJRD0ieG1wLmlpZDpDOEQyRjY5NkMzOEIxMUUyOERDNTgzNzJCODcwRDE5NCIgc3RSZWY6ZG9jdW1lbnRJRD0ieG1wLmRpZDpDOEQyRjY5N0MzOEIxMUUyOERDNTgzNzJCODcwRDE5NCIvPiA8L3JkZjpEZXNjcmlwdGlvbj4gPC9yZGY6UkRGPiA8L3g6eG1wbWV0YT4gPD94cGFja2V0IGVuZD0iciI/PjCJwKkAAByqSURBVHja7N0HlCZV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", "ABC123DEF4AAAAC12345", "pera", true, false, "Novi Sad", "Serbia", "Dr. Sime Milosevica 10", "perapera@gmail.com", "0641230000" },
                    { 2, 0, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213456789", "Maric", "Mare", "maric", "", "ABC213DEF4AAAAC12345", "mare", true, false, "Novi Sad", "Serbia", "Bulevar Patrijaha Pavla 19", "maremaric@gmail.com", "0647400000" }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Patients",
                columns: new[] { "Id", "BloodType", "DateOfBirth", "DoctorId", "Jmbg", "LastName", "Name", "Password", "Picture", "Token", "Username" },
                values: new object[,]
                {
                    { 3, 0, new DateTime(2006, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213436789", "Ilic", "Ilija", "ilija", "", "ABC213DEF4AAAAC12345", "ilija" },
                    { 4, 0, new DateTime(1970, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213126789", "Mikic", "Mika", "mika", "", "ABC213DEF4AAAAC12345", "mika" },
                    { 5, 0, new DateTime(1960, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213546789", "Sarenica", "Zika", "zika", "", "ABC213DEF4AAAAC12345", "zika" },
                    { 6, 0, new DateTime(1942, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "213996789", "Goranic", "Goran", "goran", "", "ABC213DEF4AAAAC12345", "goran" }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "IsSurveyed", "PatientId", "StartTime", "State", "Type" },
                values: new object[,]
                {
                    { 1, 1, false, 1, new DateTime(2025, 12, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 24, 1, false, 2, new DateTime(2022, 1, 1, 11, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 25, 1, false, 2, new DateTime(2022, 1, 1, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 26, 1, false, 2, new DateTime(2022, 1, 1, 11, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 27, 1, false, 2, new DateTime(2022, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 28, 1, false, 2, new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 29, 1, false, 2, new DateTime(2022, 1, 1, 12, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 30, 1, false, 2, new DateTime(2022, 1, 1, 12, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 31, 1, false, 2, new DateTime(2022, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 32, 1, false, 2, new DateTime(2022, 1, 1, 13, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 33, 1, false, 2, new DateTime(2022, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 34, 1, false, 2, new DateTime(2022, 1, 1, 13, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 35, 1, false, 2, new DateTime(2022, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 36, 1, false, 2, new DateTime(2022, 1, 1, 14, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 37, 1, false, 2, new DateTime(2022, 1, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 38, 1, false, 2, new DateTime(2022, 1, 1, 14, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 39, 1, false, 2, new DateTime(2022, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 40, 1, false, 2, new DateTime(2022, 1, 1, 15, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 23, 1, false, 2, new DateTime(2022, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 41, 1, false, 2, new DateTime(2022, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 22, 1, false, 2, new DateTime(2022, 1, 1, 10, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 20, 1, false, 2, new DateTime(2022, 1, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 43, 1, false, 1, new DateTime(2021, 12, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 44, 1, false, 1, new DateTime(2021, 12, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
<<<<<<< HEAD:HospitalInformationSystem/HospitalAPI/Migrations/20220124215231_first.cs
                    { 7, 1, false, 2, new DateTime(2022, 1, 24, 22, 52, 30, 817, DateTimeKind.Local).AddTicks(3032), 2, 0 },
                    { 8, 1, false, 2, new DateTime(2022, 1, 24, 22, 52, 30, 817, DateTimeKind.Local).AddTicks(3052), 2, 0 },
                    { 9, 1, false, 2, new DateTime(2022, 1, 24, 22, 52, 30, 817, DateTimeKind.Local).AddTicks(3056), 2, 0 },
                    { 10, 1, false, 2, new DateTime(2022, 1, 24, 22, 52, 30, 817, DateTimeKind.Local).AddTicks(3072), 2, 0 },
=======
                    { 7, 1, false, 2, new DateTime(2022, 1, 24, 23, 39, 48, 725, DateTimeKind.Local).AddTicks(5786), 2, 0 },
                    { 8, 1, false, 2, new DateTime(2022, 1, 24, 23, 39, 48, 725, DateTimeKind.Local).AddTicks(5843), 2, 0 },
                    { 9, 1, false, 2, new DateTime(2022, 1, 24, 23, 39, 48, 725, DateTimeKind.Local).AddTicks(5855), 2, 0 },
                    { 10, 1, false, 2, new DateTime(2022, 1, 24, 23, 39, 48, 725, DateTimeKind.Local).AddTicks(5884), 2, 0 },
>>>>>>> ef11504ec7ea5f4d1713e5934406c2ebf0d15704:HospitalInformationSystem/HospitalAPI/Migrations/20220124223950_first.cs
                    { 21, 1, false, 2, new DateTime(2022, 1, 1, 10, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 11, 1, false, 2, new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 13, 1, false, 2, new DateTime(2022, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 14, 1, false, 2, new DateTime(2022, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 15, 1, false, 2, new DateTime(2022, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 16, 1, false, 2, new DateTime(2022, 1, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 17, 1, false, 2, new DateTime(2022, 1, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 18, 1, false, 2, new DateTime(2022, 1, 1, 9, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 19, 1, false, 2, new DateTime(2022, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 12, 1, false, 2, new DateTime(2022, 1, 1, 8, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 42, 1, false, 2, new DateTime(2022, 1, 1, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "Date", "PatientId", "IsAnonymous", "IsApproved", "IsPublishable" },
                values: new object[,]
                {
<<<<<<< HEAD:HospitalInformationSystem/HospitalAPI/Migrations/20220124215231_first.cs
                    { 2, "Drugi neki", new DateTime(2022, 1, 24, 22, 52, 30, 816, DateTimeKind.Local).AddTicks(9175), 1, false, false, true },
                    { 1, "Tekst neki", new DateTime(2022, 1, 24, 22, 52, 30, 816, DateTimeKind.Local).AddTicks(8436), 1, true, false, true }
=======
                    { 2, "Drugi neki", new DateTime(2022, 1, 24, 23, 39, 48, 724, DateTimeKind.Local).AddTicks(9174), 1, false, false, true },
                    { 1, "Tekst neki", new DateTime(2022, 1, 24, 23, 39, 48, 724, DateTimeKind.Local).AddTicks(8144), 1, true, false, true }
>>>>>>> ef11504ec7ea5f4d1713e5934406c2ebf0d15704:HospitalInformationSystem/HospitalAPI/Migrations/20220124223950_first.cs
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "MedicalReports",
                columns: new[] { "Id", "Anamnesis", "AppointmentId", "Prescription" },
                values: new object[,]
                {
                    { 1, "Covid 19 Omicron", 43, "Brufen 500mg; Hemomicin 30mg" },
                    { 2, "Alergijska Astma", 44, "Berodual 200mg; Alergodil 10mg" }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
                table: "Surveys",
                columns: new[] { "Id", "AppointmentId", "Date", "PatientId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                schema: "Hospital",
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
                schema: "Hospital",
                table: "AllergenPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                schema: "Hospital",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                schema: "Hospital",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                schema: "Hospital",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReports_AppointmentId",
                schema: "Hospital",
                table: "MedicalReports",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DoctorId",
                schema: "Hospital",
                table: "Patients",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_SurveyId",
                schema: "Hospital",
                table: "Questions",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_AppointmentId",
                schema: "Hospital",
                table: "Surveys",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_PatientId",
                schema: "Hospital",
                table: "Surveys",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergenPatient",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Event",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "Feedbacks",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Managers",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "MedicalReports",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Medications",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Questions",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Receipts",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Allergens",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Surveys",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Appointments",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "Hospital");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Hospital");
        }
    }
}
