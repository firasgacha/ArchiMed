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
                name: "Agents",
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
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
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
                name: "Patients",
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
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
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
                    DepartmentFk = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true)
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
                name: "MedicalFolders",
                columns: table => new
                {
                    FolderNumber = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFolders", x => x.FolderNumber);
                    table.ForeignKey(
                        name: "FK_MedicalFolders_Patients_PatientFk",
                        column: x => x.PatientFk,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AgentFk = table.Column<int>(type: "integer", nullable: false),
                    PatientFk = table.Column<int>(type: "integer", nullable: false),
                    DoctorFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Agents_AgentFk",
                        column: x => x.AgentFk,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorFk",
                        column: x => x.DoctorFk,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalOrders",
                columns: table => new
                {
                    MedicalOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalOrderName = table.Column<string>(type: "text", nullable: false),
                    MedicalOrderDescription = table.Column<string>(type: "text", nullable: false),
                    MedicalOrderDate = table.Column<string>(type: "text", nullable: false),
                    DoctorFk = table.Column<int>(type: "integer", nullable: false),
                    DossierMedicalFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalOrders", x => x.MedicalOrderId);
                    table.ForeignKey(
                        name: "FK_MedicalOrders_Doctors_DoctorFk",
                        column: x => x.DoctorFk,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalOrders_MedicalFolders_DossierMedicalFk",
                        column: x => x.DossierMedicalFk,
                        principalTable: "MedicalFolders",
                        principalColumn: "FolderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radios",
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
                    table.PrimaryKey("PK_Radios", x => x.RadioId);
                    table.ForeignKey(
                        name: "FK_Radios_MedicalFolders_medicalFolderFk",
                        column: x => x.medicalFolderFk,
                        principalTable: "MedicalFolders",
                        principalColumn: "FolderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scanners",
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
                    table.PrimaryKey("PK_Scanners", x => x.ScannerId);
                    table.ForeignKey(
                        name: "FK_Scanners_Agents_AgentFk",
                        column: x => x.AgentFk,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scanners_MedicalFolders_medicalFolderFk",
                        column: x => x.medicalFolderFk,
                        principalTable: "MedicalFolders",
                        principalColumn: "FolderNumber",
                        onDelete: ReferentialAction.Cascade);
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
                    MedicalOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationsId);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalOrders_MedicalOrderId",
                        column: x => x.MedicalOrderId,
                        principalTable: "MedicalOrders",
                        principalColumn: "MedicalOrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AgentFk",
                table: "Appointments",
                column: "AgentFk");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorFk",
                table: "Appointments",
                column: "DoctorFk");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFolders_PatientFk",
                table: "MedicalFolders",
                column: "PatientFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrders_DoctorFk",
                table: "MedicalOrders",
                column: "DoctorFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrders_DossierMedicalFk",
                table: "MedicalOrders",
                column: "DossierMedicalFk");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalOrderId",
                table: "Medications",
                column: "MedicalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Radios_medicalFolderFk",
                table: "Radios",
                column: "medicalFolderFk");

            migrationBuilder.CreateIndex(
                name: "IX_Scanners_AgentFk",
                table: "Scanners",
                column: "AgentFk");

            migrationBuilder.CreateIndex(
                name: "IX_Scanners_medicalFolderFk",
                table: "Scanners",
                column: "medicalFolderFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Radios");

            migrationBuilder.DropTable(
                name: "Scanners");

            migrationBuilder.DropTable(
                name: "MedicalOrders");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "MedicalFolders");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
