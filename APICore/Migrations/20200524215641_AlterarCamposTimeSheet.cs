using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class AlterarCamposTimeSheet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "APPOINTMENT_DURATION",
                table: "M_TIMESHEET",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "APPOINTMENT_CANCEL_TIME",
                table: "M_TIMESHEET",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "APPOINTMENT_DURATION",
                table: "M_TIMESHEET",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "APPOINTMENT_CANCEL_TIME",
                table: "M_TIMESHEET",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
