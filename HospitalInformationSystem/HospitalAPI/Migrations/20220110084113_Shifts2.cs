using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAPI.Migrations
{
    public partial class Shifts2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftIDID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vacations_VacationIDID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorShiftIDID",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_VacationIDID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "DoctorShiftIDID",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "VacationIDID",
                table: "Doctors");

            migrationBuilder.AddColumn<long>(
                name: "DoctorShiftID",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VacationID",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 737, DateTimeKind.Local).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 1L, 1L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 1L, 2L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 2L, 3L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 2L, 4L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 3L, 1L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 3L, 3L });

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DoctorShiftID", "VacationID" },
                values: new object[] { 1L, 2L });

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 733, DateTimeKind.Local).AddTicks(7224));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 10, 9, 41, 12, 736, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorShiftID",
                table: "Doctors",
                column: "DoctorShiftID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VacationID",
                table: "Doctors",
                column: "VacationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftID",
                table: "Doctors",
                column: "DoctorShiftID",
                principalTable: "Shifts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Vacations_VacationID",
                table: "Doctors",
                column: "VacationID",
                principalTable: "Vacations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vacations_VacationID",
                table: "Doctors");

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

            migrationBuilder.AddColumn<long>(
                name: "DoctorShiftIDID",
                table: "Doctors",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VacationIDID",
                table: "Doctors",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 588, DateTimeKind.Local).AddTicks(9116));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(437));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(449));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(453));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(456));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(459));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 589, DateTimeKind.Local).AddTicks(462));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 585, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 10, 7, 57, 36, 588, DateTimeKind.Local).AddTicks(7911));

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorShiftIDID",
                table: "Doctors",
                column: "DoctorShiftIDID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_VacationIDID",
                table: "Doctors",
                column: "VacationIDID");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftIDID",
                table: "Doctors",
                column: "DoctorShiftIDID",
                principalTable: "Shifts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Vacations_VacationIDID",
                table: "Doctors",
                column: "VacationIDID",
                principalTable: "Vacations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
