using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class medicament_on_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicaments_Manufacturers_ManufacturerId",
                table: "Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicaments_MedicalProtocols_MedicalProtocolId",
                table: "Medicaments");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicaments_Manufacturers_ManufacturerId",
                table: "Medicaments",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicaments_MedicalProtocols_MedicalProtocolId",
                table: "Medicaments",
                column: "MedicalProtocolId",
                principalTable: "MedicalProtocols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicaments_Manufacturers_ManufacturerId",
                table: "Medicaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Medicaments_MedicalProtocols_MedicalProtocolId",
                table: "Medicaments");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicaments_Manufacturers_ManufacturerId",
                table: "Medicaments",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Medicaments_MedicalProtocols_MedicalProtocolId",
                table: "Medicaments",
                column: "MedicalProtocolId",
                principalTable: "MedicalProtocols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
