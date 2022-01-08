using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalAPI.Migrations
{
    public partial class Shifts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DoctorShiftID",
                table: "Doctors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VacationID",
                table: "Doctors",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShiftType = table.Column<string>(type: "text", nullable: true),
                    ShiftStart = table.Column<string>(type: "text", nullable: true),
                    ShiftEnd = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VacationPeriod",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VacationDescription = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPeriod", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BuildingID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Floors_Buildings_BuildingID",
                        column: x => x.BuildingID,
                        principalTable: "Buildings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FloorID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Floors_FloorID",
                        column: x => x.FloorID,
                        principalTable: "Floors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    RoomID = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoveEquipments",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EquipmentID = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    DestinationRoomID = table.Column<long>(type: "bigint", nullable: true),
                    RelocationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Duration = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveEquipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoveEquipments_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoveEquipments_Rooms_DestinationRoomID",
                        column: x => x.DestinationRoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 194, DateTimeKind.Local).AddTicks(6563));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1043));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1048));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1052));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1057));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 195, DateTimeKind.Local).AddTicks(1062));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 190, DateTimeKind.Local).AddTicks(8182));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 5, 8, 45, 29, 194, DateTimeKind.Local).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "ReceiptID",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "ID", "ShiftEnd", "ShiftStart", "ShiftType" },
                values: new object[,]
                {
                    { 1L, "13:00", "7:00", "Morning shift" },
                    { 2L, "20:00", "13:00", "Afternoon shift" },
                    { 3L, "7:00", "20:00", "Night shift" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorShiftID",
                table: "Doctors",
                column: "DoctorShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VacationID",
                table: "Doctors",
                column: "VacationID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomID",
                table: "Equipments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingID",
                table: "Floors",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveEquipments_DestinationRoomID",
                table: "MoveEquipments",
                column: "DestinationRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_MoveEquipments_EquipmentID",
                table: "MoveEquipments",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorID",
                table: "Rooms",
                column: "FloorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftID",
                table: "Doctors",
                column: "DoctorShiftID",
                principalTable: "Shifts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_VacationPeriod_VacationID",
                table: "Doctors",
                column: "VacationID",
                principalTable: "VacationPeriod",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VacationPeriod_VacationID",
                table: "Doctors");

            migrationBuilder.DropTable(
                name: "MoveEquipments");

            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "VacationPeriod");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorShiftID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_VacationID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorShiftID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VacationID",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(2926));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5412));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(5418));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 541, DateTimeKind.Local).AddTicks(398));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 12, 14, 0, 54, 51, 544, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "ReceiptID",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
