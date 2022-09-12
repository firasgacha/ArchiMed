using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fisrtName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    adress = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    departmentName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFolder",
                columns: table => new
                {
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientFk = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFolder", x => x.MedicalFolderId);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fisrtName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<string>(type: "text", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    adress = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    specialty = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<int>(type: "integer", nullable: false),
                    headofDepartment = table.Column<bool>(type: "boolean", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    medicationName = table.Column<string>(type: "text", nullable: false),
                    medicationDescription = table.Column<string>(type: "text", nullable: false),
                    medicationComposition = table.Column<string>(type: "text", nullable: false),
                    medicationEffets = table.Column<string>(type: "text", nullable: false),
                    medicationcontraindication = table.Column<string>(type: "text", nullable: false),
                    medicationPrice = table.Column<string>(type: "text", nullable: false),
                    medicationPicture = table.Column<string>(type: "text", nullable: false),
                    medicationCode = table.Column<string>(type: "text", nullable: false),
                    DateFabrication = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationsId);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId");
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fisrtName = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<string>(type: "text", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    adress = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true),
                    MedicalFolderFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patient_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId");
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    RadioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RadioName = table.Column<string>(type: "text", nullable: false),
                    RadioDescription = table.Column<string>(type: "text", nullable: false),
                    RadioType = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    medicalFolderFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.RadioId);
                    table.ForeignKey(
                        name: "FK_Radio_MedicalFolder_medicalFolderFk",
                        column: x => x.medicalFolderFk,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scanner",
                columns: table => new
                {
                    ScannerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScannerName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScannerType = table.Column<string>(type: "text", nullable: false),
                    AgentFk = table.Column<int>(type: "integer", nullable: false),
                    medicalFolderFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scanner", x => x.ScannerId);
                    table.ForeignKey(
                        name: "FK_Scanner_Agent_AgentFk",
                        column: x => x.AgentFk,
                        principalTable: "Agent",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scanner_MedicalFolder_medicalFolderFk",
                        column: x => x.medicalFolderFk,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalFolderId",
                table: "Medications",
                column: "MedicalFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_MedicalFolderId",
                table: "Patient",
                column: "MedicalFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_medicalFolderFk",
                table: "Radio",
                column: "medicalFolderFk");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_AgentFk",
                table: "Scanner",
                column: "AgentFk");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_medicalFolderFk",
                table: "Scanner",
                column: "medicalFolderFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Scanner");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "MedicalFolder");
        }
    }
}
