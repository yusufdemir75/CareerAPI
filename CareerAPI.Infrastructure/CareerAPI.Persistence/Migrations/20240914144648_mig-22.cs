using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "number",
                table: "User");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "number",
                table: "ApplyAdverts");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "number",
                table: "Advert");

            migrationBuilder.DropColumn(
                name: "number",
                table: "AdminLogs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "User",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Categories",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "ApplyAdverts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Applications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "Advert",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number",
                table: "AdminLogs",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
