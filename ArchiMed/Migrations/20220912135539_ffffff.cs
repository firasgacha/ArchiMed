using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class ffffff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_MedicalFolder_MedicalFolderId",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "MedicalFolderFk",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalFolderId",
                table: "Patient",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_MedicalFolder_MedicalFolderId",
                table: "Patient",
                column: "MedicalFolderId",
                principalTable: "MedicalFolder",
                principalColumn: "MedicalFolderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patient_MedicalFolder_MedicalFolderId",
                table: "Patient");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalFolderId",
                table: "Patient",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "MedicalFolderFk",
                table: "Patient",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_MedicalFolder_MedicalFolderId",
                table: "Patient",
                column: "MedicalFolderId",
                principalTable: "MedicalFolder",
                principalColumn: "MedicalFolderId");
        }
    }
}
