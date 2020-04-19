using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APICore.Migrations
{
    public partial class InitiliazeCreate : Migration
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
                    CPF = table.Column<decimal>(type: "NUMERIC(11,0)", nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 70, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 70, nullable: false),
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
                    CPF = table.Column<decimal>(type: "NUMERIC(11,0)", nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 30, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 70, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 70, nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_M_DOCTOR_USER_ID",
                table: "M_DOCTOR",
                column: "USER_ID",
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
                name: "M_DOCTOR");

            migrationBuilder.DropTable(
                name: "P_PATIENT");

            migrationBuilder.DropTable(
                name: "U_USER");
        }
    }
}
