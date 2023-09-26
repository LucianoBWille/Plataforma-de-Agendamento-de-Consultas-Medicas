using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class withTimeRanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeRange_Doctors_DoctorID",
                table: "TimeRange");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRange",
                table: "TimeRange");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "TimeRange");

            migrationBuilder.RenameTable(
                name: "TimeRange",
                newName: "TimeRanges");

            migrationBuilder.RenameIndex(
                name: "IX_TimeRange_DoctorID",
                table: "TimeRanges",
                newName: "IX_TimeRanges_DoctorID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeRanges",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeRanges",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRanges",
                table: "TimeRanges",
                column: "TimeRangeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRanges_Doctors_DoctorID",
                table: "TimeRanges",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeRanges_Doctors_DoctorID",
                table: "TimeRanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeRanges",
                table: "TimeRanges");

            migrationBuilder.RenameTable(
                name: "TimeRanges",
                newName: "TimeRange");

            migrationBuilder.RenameIndex(
                name: "IX_TimeRanges_DoctorID",
                table: "TimeRange",
                newName: "IX_TimeRange_DoctorID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "TimeRange",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "TimeRange",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "TimeRange",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeRange",
                table: "TimeRange",
                column: "TimeRangeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeRange_Doctors_DoctorID",
                table: "TimeRange",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "DoctorID");
        }
    }
}
