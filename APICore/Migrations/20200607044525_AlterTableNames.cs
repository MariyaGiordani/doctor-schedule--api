using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class AlterTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_M_ADDRESS_ADDRESS_ID",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_M_DOCTOR_DOCTOR_CPF",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_P_PATIENT_PATIENT_CPF",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_M_ADDRESS_M_DOCTOR_Cpf",
                table: "M_ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_M_DAYS_OF_THE_WEEK_M_TIMESHEET_TIME_SHEET_ID",
                table: "M_DAYS_OF_THE_WEEK");

            migrationBuilder.DropForeignKey(
                name: "FK_M_DOCTOR_U_USER_USER_ID",
                table: "M_DOCTOR");

            migrationBuilder.DropForeignKey(
                name: "FK_M_TIMESHEET_M_ADDRESS_ADDRESS_ID",
                table: "M_TIMESHEET");

            migrationBuilder.DropForeignKey(
                name: "FK_M_TIMESHEET_M_DOCTOR_CPF",
                table: "M_TIMESHEET");

            migrationBuilder.DropForeignKey(
                name: "FK_P_PATIENT_U_USER_USER_ID",
                table: "P_PATIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_U_SECURITY_U_USER_USER_ID",
                table: "U_SECURITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_U_USER",
                table: "U_USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_U_SECURITY",
                table: "U_SECURITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_P_PATIENT",
                table: "P_PATIENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_TIMESHEET",
                table: "M_TIMESHEET");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_DOCTOR",
                table: "M_DOCTOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_DAYS_OF_THE_WEEK",
                table: "M_DAYS_OF_THE_WEEK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_M_ADDRESS",
                table: "M_ADDRESS");

            migrationBuilder.RenameTable(
                name: "U_USER",
                newName: "USER");

            migrationBuilder.RenameTable(
                name: "U_SECURITY",
                newName: "SECURITY");

            migrationBuilder.RenameTable(
                name: "P_PATIENT",
                newName: "PATIENT");

            migrationBuilder.RenameTable(
                name: "M_TIMESHEET",
                newName: "TIMESHEET");

            migrationBuilder.RenameTable(
                name: "M_DOCTOR",
                newName: "DOCTOR");

            migrationBuilder.RenameTable(
                name: "M_DAYS_OF_THE_WEEK",
                newName: "DAYS_OF_THE_WEEK");

            migrationBuilder.RenameTable(
                name: "M_ADDRESS",
                newName: "ADDRESS");

            migrationBuilder.RenameIndex(
                name: "IX_P_PATIENT_USER_ID",
                table: "PATIENT",
                newName: "IX_PATIENT_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "TIMESHEET",
                newName: "IX_TIMESHEET_CPF");

            migrationBuilder.RenameIndex(
                name: "IX_M_TIMESHEET_ADDRESS_ID",
                table: "TIMESHEET",
                newName: "IX_TIMESHEET_ADDRESS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_M_DOCTOR_USER_ID",
                table: "DOCTOR",
                newName: "IX_DOCTOR_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_M_DAYS_OF_THE_WEEK_TIME_SHEET_ID",
                table: "DAYS_OF_THE_WEEK",
                newName: "IX_DAYS_OF_THE_WEEK_TIME_SHEET_ID");

            migrationBuilder.RenameIndex(
                name: "IX_M_ADDRESS_Cpf",
                table: "ADDRESS",
                newName: "IX_ADDRESS_Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SECURITY",
                table: "SECURITY",
                column: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PATIENT",
                table: "PATIENT",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TIMESHEET",
                table: "TIMESHEET",
                column: "TIMESHEET_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DOCTOR",
                table: "DOCTOR",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DAYS_OF_THE_WEEK",
                table: "DAYS_OF_THE_WEEK",
                column: "DAYS_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ADDRESS",
                table: "ADDRESS",
                column: "ADDRESS_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ADDRESS_DOCTOR_Cpf",
                table: "ADDRESS",
                column: "Cpf",
                principalTable: "DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_ADDRESS_ADDRESS_ID",
                table: "APPOINTMENT",
                column: "ADDRESS_ID",
                principalTable: "ADDRESS",
                principalColumn: "ADDRESS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_DOCTOR_DOCTOR_CPF",
                table: "APPOINTMENT",
                column: "DOCTOR_CPF",
                principalTable: "DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_PATIENT_PATIENT_CPF",
                table: "APPOINTMENT",
                column: "PATIENT_CPF",
                principalTable: "PATIENT",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DAYS_OF_THE_WEEK_TIMESHEET_TIME_SHEET_ID",
                table: "DAYS_OF_THE_WEEK",
                column: "TIME_SHEET_ID",
                principalTable: "TIMESHEET",
                principalColumn: "TIMESHEET_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DOCTOR_USER_USER_ID",
                table: "DOCTOR",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PATIENT_USER_USER_ID",
                table: "PATIENT",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SECURITY_USER_USER_ID",
                table: "SECURITY",
                column: "USER_ID",
                principalTable: "USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TIMESHEET_ADDRESS_ADDRESS_ID",
                table: "TIMESHEET",
                column: "ADDRESS_ID",
                principalTable: "ADDRESS",
                principalColumn: "ADDRESS_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TIMESHEET_DOCTOR_CPF",
                table: "TIMESHEET",
                column: "CPF",
                principalTable: "DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ADDRESS_DOCTOR_Cpf",
                table: "ADDRESS");

            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_ADDRESS_ADDRESS_ID",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_DOCTOR_DOCTOR_CPF",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_APPOINTMENT_PATIENT_PATIENT_CPF",
                table: "APPOINTMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_DAYS_OF_THE_WEEK_TIMESHEET_TIME_SHEET_ID",
                table: "DAYS_OF_THE_WEEK");

            migrationBuilder.DropForeignKey(
                name: "FK_DOCTOR_USER_USER_ID",
                table: "DOCTOR");

            migrationBuilder.DropForeignKey(
                name: "FK_PATIENT_USER_USER_ID",
                table: "PATIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SECURITY_USER_USER_ID",
                table: "SECURITY");

            migrationBuilder.DropForeignKey(
                name: "FK_TIMESHEET_ADDRESS_ADDRESS_ID",
                table: "TIMESHEET");

            migrationBuilder.DropForeignKey(
                name: "FK_TIMESHEET_DOCTOR_CPF",
                table: "TIMESHEET");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TIMESHEET",
                table: "TIMESHEET");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SECURITY",
                table: "SECURITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PATIENT",
                table: "PATIENT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DOCTOR",
                table: "DOCTOR");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DAYS_OF_THE_WEEK",
                table: "DAYS_OF_THE_WEEK");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ADDRESS",
                table: "ADDRESS");

            migrationBuilder.RenameTable(
                name: "USER",
                newName: "U_USER");

            migrationBuilder.RenameTable(
                name: "TIMESHEET",
                newName: "M_TIMESHEET");

            migrationBuilder.RenameTable(
                name: "SECURITY",
                newName: "U_SECURITY");

            migrationBuilder.RenameTable(
                name: "PATIENT",
                newName: "P_PATIENT");

            migrationBuilder.RenameTable(
                name: "DOCTOR",
                newName: "M_DOCTOR");

            migrationBuilder.RenameTable(
                name: "DAYS_OF_THE_WEEK",
                newName: "M_DAYS_OF_THE_WEEK");

            migrationBuilder.RenameTable(
                name: "ADDRESS",
                newName: "M_ADDRESS");

            migrationBuilder.RenameIndex(
                name: "IX_TIMESHEET_CPF",
                table: "M_TIMESHEET",
                newName: "IX_M_TIMESHEET_CPF");

            migrationBuilder.RenameIndex(
                name: "IX_TIMESHEET_ADDRESS_ID",
                table: "M_TIMESHEET",
                newName: "IX_M_TIMESHEET_ADDRESS_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PATIENT_USER_ID",
                table: "P_PATIENT",
                newName: "IX_P_PATIENT_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_DOCTOR_USER_ID",
                table: "M_DOCTOR",
                newName: "IX_M_DOCTOR_USER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_DAYS_OF_THE_WEEK_TIME_SHEET_ID",
                table: "M_DAYS_OF_THE_WEEK",
                newName: "IX_M_DAYS_OF_THE_WEEK_TIME_SHEET_ID");

            migrationBuilder.RenameIndex(
                name: "IX_ADDRESS_Cpf",
                table: "M_ADDRESS",
                newName: "IX_M_ADDRESS_Cpf");

            migrationBuilder.AddPrimaryKey(
                name: "PK_U_USER",
                table: "U_USER",
                column: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_TIMESHEET",
                table: "M_TIMESHEET",
                column: "TIMESHEET_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_U_SECURITY",
                table: "U_SECURITY",
                column: "USER_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_P_PATIENT",
                table: "P_PATIENT",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_DOCTOR",
                table: "M_DOCTOR",
                column: "CPF");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_DAYS_OF_THE_WEEK",
                table: "M_DAYS_OF_THE_WEEK",
                column: "DAYS_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_M_ADDRESS",
                table: "M_ADDRESS",
                column: "ADDRESS_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_M_ADDRESS_ADDRESS_ID",
                table: "APPOINTMENT",
                column: "ADDRESS_ID",
                principalTable: "M_ADDRESS",
                principalColumn: "ADDRESS_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_M_DOCTOR_DOCTOR_CPF",
                table: "APPOINTMENT",
                column: "DOCTOR_CPF",
                principalTable: "M_DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_APPOINTMENT_P_PATIENT_PATIENT_CPF",
                table: "APPOINTMENT",
                column: "PATIENT_CPF",
                principalTable: "P_PATIENT",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_M_ADDRESS_M_DOCTOR_Cpf",
                table: "M_ADDRESS",
                column: "Cpf",
                principalTable: "M_DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_DAYS_OF_THE_WEEK_M_TIMESHEET_TIME_SHEET_ID",
                table: "M_DAYS_OF_THE_WEEK",
                column: "TIME_SHEET_ID",
                principalTable: "M_TIMESHEET",
                principalColumn: "TIMESHEET_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_DOCTOR_U_USER_USER_ID",
                table: "M_DOCTOR",
                column: "USER_ID",
                principalTable: "U_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_TIMESHEET_M_ADDRESS_ADDRESS_ID",
                table: "M_TIMESHEET",
                column: "ADDRESS_ID",
                principalTable: "M_ADDRESS",
                principalColumn: "ADDRESS_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_M_TIMESHEET_M_DOCTOR_CPF",
                table: "M_TIMESHEET",
                column: "CPF",
                principalTable: "M_DOCTOR",
                principalColumn: "CPF",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_P_PATIENT_U_USER_USER_ID",
                table: "P_PATIENT",
                column: "USER_ID",
                principalTable: "U_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_U_SECURITY_U_USER_USER_ID",
                table: "U_SECURITY",
                column: "USER_ID",
                principalTable: "U_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
