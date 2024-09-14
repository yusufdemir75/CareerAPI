using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isApproved",
                table: "ApplyAdverts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "ApplyAdverts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isApproved",
                table: "ApplyAdverts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ApplyAdverts");
        }
    }
}
