using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class RenameUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOCTOR_USER_USER_ID",
                table: "DOCTOR");

            migrationBuilder.DropForeignKey(
                name: "FK_PATIENT_USER_USER_ID",
                table: "PATIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SECURITY_USER_USER_ID",
                table: "SECURITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK_USER",
                table: "USER");

            migrationBuilder.RenameTable(
                name: "USER",
                newName: "_USER");

            migrationBuilder.AddPrimaryKey(
                name: "PK__USER",
                table: "_USER",
                column: "USER_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DOCTOR__USER_USER_ID",
                table: "DOCTOR",
                column: "USER_ID",
                principalTable: "_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PATIENT__USER_USER_ID",
                table: "PATIENT",
                column: "USER_ID",
                principalTable: "_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SECURITY__USER_USER_ID",
                table: "SECURITY",
                column: "USER_ID",
                principalTable: "_USER",
                principalColumn: "USER_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DOCTOR__USER_USER_ID",
                table: "DOCTOR");

            migrationBuilder.DropForeignKey(
                name: "FK_PATIENT__USER_USER_ID",
                table: "PATIENT");

            migrationBuilder.DropForeignKey(
                name: "FK_SECURITY__USER_USER_ID",
                table: "SECURITY");

            migrationBuilder.DropPrimaryKey(
                name: "PK__USER",
                table: "_USER");

            migrationBuilder.RenameTable(
                name: "_USER",
                newName: "USER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_USER",
                table: "USER",
                column: "USER_ID");

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
        }
    }
}
