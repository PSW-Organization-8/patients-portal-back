using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAPI.Migrations
{
    public partial class Shifts3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 435, DateTimeKind.Local).AddTicks(8245));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(340));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 436, DateTimeKind.Local).AddTicks(347));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 431, DateTimeKind.Local).AddTicks(4473));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 24, 16, 51, 11, 435, DateTimeKind.Local).AddTicks(6530));

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "ReceiptID",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "ReceiptID",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
