using System;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CareerAPI.Persistence.Migrations
{
    public partial class mig9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "AspNetUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            // JsonDocument için varsayılan bir boş JSON array'i atanıyor
            migrationBuilder.AddColumn<JsonDocument>(
                name: "skills",
                table: "AspNetUsers",
                type: "jsonb",
                nullable: false,
                defaultValue: JsonDocument.Parse("[]"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "skills",
                table: "AspNetUsers");
        }
    }
}
