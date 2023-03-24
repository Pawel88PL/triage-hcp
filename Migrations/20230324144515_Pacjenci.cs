using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace triage_hcp.Migrations
{
    public partial class Pacjenci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoDalejZPacjentem",
                table: "Pacjenci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Epikryza",
                table: "Pacjenci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObserwacjeRatPiel",
                table: "Pacjenci",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoDalejZPacjentem",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "Epikryza",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "ObserwacjeRatPiel",
                table: "Pacjenci");
        }
    }
}
