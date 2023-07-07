using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace triage_hcp.Migrations
{
    public partial class WaitingTime_And_TotalTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalTime",
                table: "Pacjenci",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "WaitingTime",
                table: "Pacjenci",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalTime",
                table: "Pacjenci");

            migrationBuilder.DropColumn(
                name: "WaitingTime",
                table: "Pacjenci");
        }
    }
}
