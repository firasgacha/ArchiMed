using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class vvvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientFk",
                table: "MedicalFolder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientFk",
                table: "MedicalFolder",
                type: "integer",
                nullable: true);
        }
    }
}
