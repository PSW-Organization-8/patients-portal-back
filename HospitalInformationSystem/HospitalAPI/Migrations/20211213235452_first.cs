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
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
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
                    IsBanned = table.Column<bool>(type: "boolean", nullable: false),
                    Lbo = table.Column<string>(type: "text", nullable: true),
                    Guest = table.Column<bool>(type: "boolean", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    IsActivated = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Jmbg = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
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
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublishable = table.Column<bool>(type: "boolean", nullable: false),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false)
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
                columns: new[] { "Id", "Address", "City", "Country", "DoctorSpecialization", "Email", "Jmbg", "LastName", "Name", "Password", "Phone", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, 0, null, "123456799", "Jovanovic", "Jovan", "jova", null, "jova" },
                    { 2, null, null, null, 0, null, "123756799", "Ilic", "Milan", "mico", null, "mico" },
                    { 3, null, null, null, 8, null, "123756799", "Markovic", "Stevan", "mico", null, "mico" },
                    { 4, null, null, null, 9, null, "123756799", "Visnjic", "Nikola", "mico", null, "mico" },
                    { 5, null, null, null, 9, null, "123756799", "Mitic", "Strahinja", "mico", null, "mico" },
                    { 6, null, null, null, 2, null, "123756799", "Despotovic", "Goran", "mico", null, "mico" },
                    { 7, null, null, null, 7, null, "123756799", "Njegos", "Milomir", "mico", null, "mico" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicineID", "Name", "Quantity" },
                values: new object[] { 1L, "Synthroid", 2 });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "ReceiptID", "Amount", "Date", "Diagnosis", "DoctorId", "MedicineName", "PatientId" },
                values: new object[] { 1L, 1, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), "Korona", 1, "Synthroid", 1 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "BloodType", "City", "Country", "DateOfBirth", "DoctorId", "Email", "Guest", "IsActivated", "IsBanned", "Jmbg", "LastName", "Lbo", "Name", "Password", "Phone", "Token", "Username" },
                values: new object[,]
                {
                    { 1, null, 0, null, null, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "pera.peric@gmail.com", false, true, false, "123456789", "Peric", null, "Pera", "pera", "054987332", "ABC123DEF4AAAAC12345", "pera" },
                    { 2, null, 0, null, null, new DateTime(1999, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "pera2.peric@gmail.com", false, true, false, "213456789", "Maric", null, "Mare", "maric", "054987332", "ABC213DEF4AAAAC12345", "mare" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DoctorId", "IsSurveyed", "PatientId", "StartTime", "State", "Type" },
                values: new object[,]
                {
                    { 1, 1, false, 1, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(2926), 0, 0 },
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
                    { 2, 6, false, 1, new DateTime(2021, 12, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 3, 6, false, 1, new DateTime(2021, 12, 15, 13, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 4, 6, false, 1, new DateTime(2021, 12, 15, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 5, 1, false, 1, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5391), 2, 0 },
                    { 6, 1, false, 1, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5405), 1, 0 },
                    { 7, 1, false, 2, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5409), 2, 0 },
                    { 8, 1, false, 2, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5412), 2, 0 },
                    { 41, 1, false, 2, new DateTime(2022, 1, 1, 15, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 9, 1, false, 2, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5416), 2, 0 },
                    { 11, 1, false, 2, new DateTime(2022, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 12, 1, false, 2, new DateTime(2022, 1, 1, 8, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 13, 1, false, 2, new DateTime(2022, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 14, 1, false, 2, new DateTime(2022, 1, 1, 8, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 15, 1, false, 2, new DateTime(2022, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 16, 1, false, 2, new DateTime(2022, 1, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 17, 1, false, 2, new DateTime(2022, 1, 1, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 18, 1, false, 2, new DateTime(2022, 1, 1, 9, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 10, 1, false, 2, new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5418), 2, 0 },
                    { 42, 1, false, 2, new DateTime(2022, 1, 1, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Content", "Date", "IsAnonymous", "IsApproved", "IsPublishable", "PatientId" },
                values: new object[,]
                {
                    { 2, "Drugi neki", new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(1453), false, true, true, 1 },
                    { 1, "Tekst neki", new DateTime(2021, 12, 14, 0, 54, 51, 541, DateTimeKind.Local).AddTicks(398), false, true, true, 1 }
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
