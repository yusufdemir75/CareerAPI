using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "age",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
