using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class procedure_hasproblem_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasProblem",
                table: "Procedures",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasProblem",
                table: "Procedures");
        }
    }
}
