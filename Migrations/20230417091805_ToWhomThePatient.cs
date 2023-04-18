using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace triage_hcp.Migrations
{
    public partial class ToWhomThePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ToWhomThePatient",
                table: "Pacjenci",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToWhomThePatient",
                table: "Pacjenci");
        }
    }
}
