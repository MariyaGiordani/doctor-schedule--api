using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "U_USER",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_NAME = table.Column<string>(maxLength: 100, nullable: false),
                    USER_PASSWORD = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_U_USER", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "M_DOCTOR",
                columns: table => new
                {
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 70, nullable: false),
                    CRM = table.Column<int>(maxLength: 6, nullable: false),
                    SPECIALITY = table.Column<string>(maxLength: 39, nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_DOCTOR", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_M_DOCTOR_U_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "U_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "P_PATIENT",
                columns: table => new
                {
                    CPF = table.Column<string>(maxLength: 30, nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 70, nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_P_PATIENT", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_P_PATIENT_U_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "U_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "U_SECURITY",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false),
                    SALT_PASSWORD = table.Column<byte[]>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_U_SECURITY", x => x.USER_ID);
                    table.ForeignKey(
                        name: "FK_U_SECURITY_U_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "U_USER",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_ADDRESS",
                columns: table => new
                {
                    ADDRESS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ROAD_TYPE = table.Column<string>(maxLength: 30, nullable: false),
                    STREET = table.Column<string>(maxLength: 100, nullable: false),
                    NUMBER = table.Column<int>(nullable: false),
                    NEIGHBORHOOD = table.Column<string>(maxLength: 100, nullable: false),
                    COMPLEMENT = table.Column<string>(maxLength: 200, nullable: true),
                    POSTAL_CODE = table.Column<string>(maxLength: 10, nullable: false),
                    CITY = table.Column<string>(nullable: false),
                    UF = table.Column<string>(nullable: false),
                    INFORMATION = table.Column<string>(maxLength: 4000, nullable: true),
                    Cpf = table.Column<string>(nullable: false),
                    TELEPHONE = table.Column<string>(nullable: false),
                    HEALTHCARE = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_ADDRESS", x => x.ADDRESS_ID);
                    table.ForeignKey(
                        name: "FK_M_ADDRESS_M_DOCTOR_Cpf",
                        column: x => x.Cpf,
                        principalTable: "M_DOCTOR",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "M_TIMESHEET",
                columns: table => new
                {
                    TIMESHEET_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    START_DATE = table.Column<DateTime>(nullable: false),
                    END_DATE = table.Column<DateTime>(nullable: false),
                    LUNCH_START_DATE = table.Column<DateTime>(nullable: false),
                    LUNCH_END_DATE = table.Column<DateTime>(nullable: false),
                    APPOINTMENT_DURATION = table.Column<DateTime>(nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    ADDRESS_ID = table.Column<int>(nullable: false),
                    APPOINTMENT_CANCEL_TIME = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_TIMESHEET", x => x.TIMESHEET_ID);
                    table.ForeignKey(
                        name: "FK_M_TIMESHEET_M_ADDRESS_ADDRESS_ID",
                        column: x => x.ADDRESS_ID,
                        principalTable: "M_ADDRESS",
                        principalColumn: "ADDRESS_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_M_TIMESHEET_M_DOCTOR_CPF",
                        column: x => x.CPF,
                        principalTable: "M_DOCTOR",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "M_DAYS_OF_THE_WEEK",
                columns: table => new
                {
                    DAYS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<int>(nullable: false),
                    TIME_SHEET_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_DAYS_OF_THE_WEEK", x => x.DAYS_ID);
                    table.ForeignKey(
                        name: "FK_M_DAYS_OF_THE_WEEK_M_TIMESHEET_TIME_SHEET_ID",
                        column: x => x.TIME_SHEET_ID,
                        principalTable: "M_TIMESHEET",
                        principalColumn: "TIMESHEET_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_M_ADDRESS_Cpf",
                table: "M_ADDRESS",
                column: "Cpf");

            migrationBuilder.CreateIndex(
                name: "IX_M_DAYS_OF_THE_WEEK_TIME_SHEET_ID",
                table: "M_DAYS_OF_THE_WEEK",
                column: "TIME_SHEET_ID");

            migrationBuilder.CreateIndex(
                name: "IX_M_DOCTOR_USER_ID",
                table: "M_DOCTOR",
                column: "USER_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_TIMESHEET_ADDRESS_ID",
                table: "M_TIMESHEET",
                column: "ADDRESS_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_M_TIMESHEET_CPF",
                table: "M_TIMESHEET",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_P_PATIENT_USER_ID",
                table: "P_PATIENT",
                column: "USER_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_DAYS_OF_THE_WEEK");

            migrationBuilder.DropTable(
                name: "P_PATIENT");

            migrationBuilder.DropTable(
                name: "U_SECURITY");

            migrationBuilder.DropTable(
                name: "M_TIMESHEET");

            migrationBuilder.DropTable(
                name: "M_ADDRESS");

            migrationBuilder.DropTable(
                name: "M_DOCTOR");

            migrationBuilder.DropTable(
                name: "U_USER");
        }
    }
}
