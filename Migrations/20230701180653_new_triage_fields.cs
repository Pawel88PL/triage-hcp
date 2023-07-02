using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace triage_hcp.Migrations
{
    public partial class new_triage_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "Pacjenci",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BodyTemperature",
                table: "Pacjenci",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "DBP",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GCS",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeartRate",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SBP",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Spo2",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "BodyTemperature",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "DBP",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "GCS",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "HeartRate",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "SBP",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "Spo2",
                table: "Pacjenci");
        }
    }
}
