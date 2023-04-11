using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace triage_hcp.Migrations
{
    public partial class TriageDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TriageDate",
                table: "Pacjenci",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TriageDate",
                table: "Pacjenci");
        }
    }
}
