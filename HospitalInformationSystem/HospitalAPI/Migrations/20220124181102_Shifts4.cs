using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalAPI.Migrations
{
    public partial class Shifts4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Shifts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(3672));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5860));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5865));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5876));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10,
                column: "StartTime",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 359, DateTimeKind.Local).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 1, 24, 19, 11, 1, 364, DateTimeKind.Local).AddTicks(1777));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Shifts");

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
        }
    }
}
