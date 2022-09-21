using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArchiMed.Migrations
{
    public partial class ImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Scanner",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Radio",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Patient",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Medications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Agent",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Scanner");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Radio");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Medications");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Agent");
        }
    }
}
