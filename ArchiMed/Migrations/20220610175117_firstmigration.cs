using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medecin",
                columns: table => new
                {
                    MedecinId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    naissance = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    adresse = table.Column<string>(type: "text", nullable: false),
                    ville = table.Column<string>(type: "text", nullable: false),
                    pays = table.Column<string>(type: "text", nullable: false),
                    zipcode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mdp = table.Column<string>(type: "text", nullable: false),
                    specialite = table.Column<int>(type: "integer", nullable: false),
                    telephone = table.Column<int>(type: "integer", nullable: false),
                    chefDeProjet = table.Column<bool>(type: "boolean", nullable: false),
                    ProfileUrl = table.Column<string>(type: "text", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecin", x => x.MedecinId);
                });

            migrationBuilder.CreateTable(
                name: "Consultation",
                columns: table => new
                {
                    ConsultationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateRendezVous = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PatientFk = table.Column<int>(type: "integer", nullable: false),
                    MedecinFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultation", x => x.ConsultationId);
                    table.ForeignKey(
                        name: "FK_Consultation_Medecin_MedecinFk",
                        column: x => x.MedecinFk,
                        principalTable: "Medecin",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DossierMedical",
                columns: table => new
                {
                    NumeroDossier = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DossierMedical", x => x.NumeroDossier);
                });

            migrationBuilder.CreateTable(
                name: "Ordenance",
                columns: table => new
                {
                    OrdenanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrdenanceName = table.Column<string>(type: "text", nullable: false),
                    OrdenanceDescription = table.Column<string>(type: "text", nullable: false),
                    OrdenanceDate = table.Column<string>(type: "text", nullable: false),
                    MedecinFk = table.Column<int>(type: "integer", nullable: false),
                    DossierMedicalFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenance", x => x.OrdenanceId);
                    table.ForeignKey(
                        name: "FK_Ordenance_DossierMedical_DossierMedicalFk",
                        column: x => x.DossierMedicalFk,
                        principalTable: "DossierMedical",
                        principalColumn: "NumeroDossier",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenance_Medecin_MedecinFk",
                        column: x => x.MedecinFk,
                        principalTable: "Medecin",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radio",
                columns: table => new
                {
                    RadioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RadioName = table.Column<string>(type: "text", nullable: false),
                    RadioDescription = table.Column<string>(type: "text", nullable: false),
                    RadioUrl = table.Column<string>(type: "text", nullable: false),
                    RadioImage = table.Column<string>(type: "text", nullable: false),
                    RadioType = table.Column<string>(type: "text", nullable: false),
                    DossierMedicalFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radio", x => x.RadioId);
                    table.ForeignKey(
                        name: "FK_Radio_DossierMedical_DossierMedicalFk",
                        column: x => x.DossierMedicalFk,
                        principalTable: "DossierMedical",
                        principalColumn: "NumeroDossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scanner",
                columns: table => new
                {
                    ScannerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ScannerType = table.Column<string>(type: "text", nullable: false),
                    ScannerUrl = table.Column<string>(type: "text", nullable: false),
                    ScannerImage = table.Column<string>(type: "text", nullable: false),
                    DossierMedicalFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scanner", x => x.ScannerId);
                    table.ForeignKey(
                        name: "FK_Scanner_DossierMedical_DossierMedicalFk",
                        column: x => x.DossierMedicalFk,
                        principalTable: "DossierMedical",
                        principalColumn: "NumeroDossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    MedicamentsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nom = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Composition = table.Column<string>(type: "text", nullable: false),
                    Effets = table.Column<string>(type: "text", nullable: false),
                    ContreIndications = table.Column<string>(type: "text", nullable: false),
                    Prix = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CodeBarre = table.Column<string>(type: "text", nullable: false),
                    DateFabrication = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrdenanceId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentsId);
                    table.ForeignKey(
                        name: "FK_Medicaments_Ordenance_OrdenanceId",
                        column: x => x.OrdenanceId,
                        principalTable: "Ordenance",
                        principalColumn: "OrdenanceId");
                });

            migrationBuilder.CreateTable(
                name: "MedecinService",
                columns: table => new
                {
                    MedecinsListMedecinId = table.Column<int>(type: "integer", nullable: false),
                    ServicesListServiceId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedecinService", x => new { x.MedecinsListMedecinId, x.ServicesListServiceId });
                    table.ForeignKey(
                        name: "FK_MedecinService_Medecin_MedecinsListMedecinId",
                        column: x => x.MedecinsListMedecinId,
                        principalTable: "Medecin",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    naissance = table.Column<string>(type: "text", nullable: false),
                    cin = table.Column<int>(type: "integer", nullable: false),
                    adresse = table.Column<string>(type: "text", nullable: false),
                    ville = table.Column<string>(type: "text", nullable: false),
                    pays = table.Column<string>(type: "text", nullable: false),
                    zipcode = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    mdp = table.Column<string>(type: "text", nullable: false),
                    telephone = table.Column<string>(type: "text", nullable: false),
                    ProfileUrl = table.Column<string>(type: "text", nullable: false),
                    ProfileImage = table.Column<string>(type: "text", nullable: false),
                    DossierMedicalFk = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ServiceFk = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_DossierMedical_DossierMedicalFk",
                        column: x => x.DossierMedicalFk,
                        principalTable: "DossierMedical",
                        principalColumn: "NumeroDossier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    ChefServiceFk = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Patients_ChefServiceFk",
                        column: x => x.ChefServiceFk,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_MedecinFk",
                table: "Consultation",
                column: "MedecinFk");

            migrationBuilder.CreateIndex(
                name: "IX_Consultation_PatientFk",
                table: "Consultation",
                column: "PatientFk");

            migrationBuilder.CreateIndex(
                name: "IX_DossierMedical_PatientFk",
                table: "DossierMedical",
                column: "PatientFk");

            migrationBuilder.CreateIndex(
                name: "IX_MedecinService_ServicesListServiceId",
                table: "MedecinService",
                column: "ServicesListServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_OrdenanceId",
                table: "Medicaments",
                column: "OrdenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenance_DossierMedicalFk",
                table: "Ordenance",
                column: "DossierMedicalFk");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenance_MedecinFk",
                table: "Ordenance",
                column: "MedecinFk");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DossierMedicalFk",
                table: "Patients",
                column: "DossierMedicalFk");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ServiceFk",
                table: "Patients",
                column: "ServiceFk");

            migrationBuilder.CreateIndex(
                name: "IX_Radio_DossierMedicalFk",
                table: "Radio",
                column: "DossierMedicalFk");

            migrationBuilder.CreateIndex(
                name: "IX_Scanner_DossierMedicalFk",
                table: "Scanner",
                column: "DossierMedicalFk");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ChefServiceFk",
                table: "Service",
                column: "ChefServiceFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Patients_PatientFk",
                table: "Consultation",
                column: "PatientFk",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierMedical_Patients_PatientFk",
                table: "DossierMedical",
                column: "PatientFk",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedecinService_Service_ServicesListServiceId",
                table: "MedecinService",
                column: "ServicesListServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Service_ServiceFk",
                table: "Patients",
                column: "ServiceFk",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Service_ServiceFk",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_DossierMedical_Patients_PatientFk",
                table: "DossierMedical");

            migrationBuilder.DropTable(
                name: "Consultation");

            migrationBuilder.DropTable(
                name: "MedecinService");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "Radio");

            migrationBuilder.DropTable(
                name: "Scanner");

            migrationBuilder.DropTable(
                name: "Ordenance");

            migrationBuilder.DropTable(
                name: "Medecin");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "DossierMedical");
        }
    }
}
