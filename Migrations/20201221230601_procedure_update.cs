using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class procedure_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodPressure",
                table: "Procedures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pulse",
                table: "Procedures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "Procedures",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Temperature",
                table: "Procedures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Volume",
                table: "Procedures",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodPressure",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "Pulse",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Procedures");
        }
    }
}
