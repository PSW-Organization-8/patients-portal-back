using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAPI.Migrations
{
    public partial class Shifts1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_VacationPeriod_VacationID",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VacationPeriod",
                table: "VacationPeriod");

            migrationBuilder.RenameTable(
                name: "VacationPeriod",
                newName: "Vacations");

            migrationBuilder.RenameColumn(
                name: "VacationID",
                table: "Doctors",
                newName: "VacationIDID");

            migrationBuilder.RenameColumn(
                name: "DoctorShiftID",
                table: "Doctors",
                newName: "DoctorShiftIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VacationID",
                table: "Doctors",
                newName: "IX_Doctors_VacationIDID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_DoctorShiftID",
                table: "Doctors",
                newName: "IX_Doctors_DoctorShiftIDID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vacations",
                table: "Vacations",
                column: "ID");

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

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "ReceiptID",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "ID", "EndTime", "StartTime", "VacationDescription" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Vacation" },
                    { 2L, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Winter Vacation" },
                    { 3L, new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ski Trip" },
                    { 4L, new DateTime(2022, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Vacation" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Shifts_DoctorShiftIDID",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Vacations_VacationIDID",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vacations",
                table: "Vacations");

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "ID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "ID",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "ID",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Vacations",
                keyColumn: "ID",
                keyValue: 4L);

            migrationBuilder.RenameTable(
                name: "Vacations",
                newName: "VacationPeriod");

            migrationBuilder.RenameColumn(
                name: "VacationIDID",
                table: "Doctors",
                newName: "VacationID");

            migrationBuilder.RenameColumn(
                name: "DoctorShiftIDID",
                table: "Doctors",
                newName: "DoctorShiftID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_VacationIDID",
                table: "Doctors",
                newName: "IX_Doctors_VacationID");

            migrationBuilder.RenameIndex(
                name: "IX_Doctors_DoctorShiftIDID",
                table: "Doctors",
                newName: "IX_Doctors_DoctorShiftID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VacationPeriod",
                table: "VacationPeriod",
                column: "ID");

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
    }
}
