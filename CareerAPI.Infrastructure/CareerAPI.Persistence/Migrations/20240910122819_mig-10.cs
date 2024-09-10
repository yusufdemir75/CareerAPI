using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "githubLink",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "instaLink",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "twitterLink",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "githubLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "instaLink",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "twitterLink",
                table: "AspNetUsers");
        }
    }
}
