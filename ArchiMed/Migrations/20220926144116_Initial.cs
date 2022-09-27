﻿using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
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
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFolder", x => x.MedicalFolderId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fisrtName = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    lastName = table.Column<string>(type: "text", nullable: false),
                    birthday = table.Column<string>(type: "text", nullable: false),
                    gender = table.Column<string>(type: "text", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    postalCode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    user_type = table.Column<string>(type: "text", nullable: false),
                    specialty = table.Column<string>(type: "text", nullable: true),
                    headofDepartment = table.Column<bool>(type: "boolean", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentFk = table.Column<int>(type: "integer", nullable: true),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Users_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDate = table.Column<string>(type: "text", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalOrder",
                columns: table => new
                {
                    MedicalOrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicalOrderDescription = table.Column<string>(type: "text", nullable: false),
                    MedicalOrderDate = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalOrder", x => x.MedicalOrderId);
                    table.ForeignKey(
                        name: "FK_MedicalOrder_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId");
                    table.ForeignKey(
                        name: "FK_MedicalOrder_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalOrder_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    RadioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RadioDescription = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.RadioId);
                    table.ForeignKey(
                        name: "FK_Radio_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId");
                    table.ForeignKey(
                        name: "FK_Radio_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Radio_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Radio_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scanner",
                columns: table => new
                {
                    ScannerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    AgentId = table.Column<int>(type: "integer", nullable: false),
                    MedicalFolderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scanner", x => x.ScannerId);
                    table.ForeignKey(
                        name: "FK_Scanner_MedicalFolder_MedicalFolderId",
                        column: x => x.MedicalFolderId,
                        principalTable: "MedicalFolder",
                        principalColumn: "MedicalFolderId");
                    table.ForeignKey(
                        name: "FK_Scanner_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scanner_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scanner_Users_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Users",
                        principalColumn: "id",
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
                    medicationContraindication = table.Column<string>(type: "text", nullable: false),
                    medicationPrice = table.Column<int>(type: "integer", nullable: false),
                    medicationCode = table.Column<string>(type: "text", nullable: false),
                    DateFabrication = table.Column<string>(type: "text", nullable: false),
                    DateExpiration = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    MedicalOrderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationsId);
                    table.ForeignKey(
                        name: "FK_Medications_MedicalOrder_MedicalOrderId",
                        column: x => x.MedicalOrderId,
                        principalTable: "MedicalOrder",
                        principalColumn: "MedicalOrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_AgentId",
                table: "Appointment",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId",
                table: "Appointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrder_DoctorId",
                table: "MedicalOrder",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrder_MedicalFolderId",
                table: "MedicalOrder",
                column: "MedicalFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalOrder_PatientId",
                table: "MedicalOrder",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_MedicalOrderId",
                table: "Medications",
                column: "MedicalOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_AgentId",
                table: "Radio",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_DoctorId",
                table: "Radio",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_MedicalFolderId",
                table: "Radio",
                column: "MedicalFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_PatientId",
                table: "Radio",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_AgentId",
                table: "Scanner",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_DoctorId",
                table: "Scanner",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_MedicalFolderId",
                table: "Scanner",
                column: "MedicalFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_PatientId",
                table: "Scanner",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DepartmentId",
                table: "Users",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalFolderId",
                table: "Users",
                column: "MedicalFolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Scanner");

            migrationBuilder.DropTable(
                name: "MedicalOrder");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "MedicalFolder");
        }
    }
}