using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class CreateAppointmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "M_TIMESHEET");

            migrationBuilder.CreateTable(
                name: "APPOINTMENT",
                columns: table => new
                {
                    APPOINTMENT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    APPOINTMENT_TIME = table.Column<DateTime>(nullable: false),
                    STATUS = table.Column<int>(nullable: false),
                    RE_SCHEDULED_APPOINTMENT_ID = table.Column<int>(nullable: false),
                    DOCTOR_CPF = table.Column<string>(nullable: false),
                    PATIENT_CPF = table.Column<string>(nullable: false),
                    ADDRESS_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENT", x => x.APPOINTMENT_ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_M_ADDRESS_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalTable: "M_ADDRESS",
                        principalColumn: "ADDRESS_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_M_DOCTOR_DOCTOR_CPF",
                        column: x => x.DOCTOR_CPF,
                        principalTable: "M_DOCTOR",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_APPOINTMENT_P_PATIENT_PATIENT_CPF",
                        column: x => x.PATIENT_CPF,
                        principalTable: "P_PATIENT",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "M_TIMESHEET",
                column: "CPF");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_ADDRESS_ID",
                table: "APPOINTMENT",
                column: "ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_DOCTOR_CPF",
                table: "APPOINTMENT",
                column: "DOCTOR_CPF");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENT_PATIENT_CPF",
                table: "APPOINTMENT",
                column: "PATIENT_CPF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPOINTMENT");

            migrationBuilder.DropIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "M_TIMESHEET");

            migrationBuilder.CreateIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "M_TIMESHEET",
                column: "CPF",
                unique: true);
        }
    }
}
