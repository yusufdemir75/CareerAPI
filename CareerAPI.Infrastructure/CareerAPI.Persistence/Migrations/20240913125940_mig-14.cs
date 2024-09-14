using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "ApplyAdverts",
                newName: "userName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userName",
                table: "ApplyAdverts",
                newName: "username");
        }
    }
}
