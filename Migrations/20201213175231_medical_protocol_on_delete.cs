using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class medical_protocol_on_delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalProtocols_Diseases_DiseaseId",
                table: "MedicalProtocols");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalProtocols_Diseases_DiseaseId",
                table: "MedicalProtocols",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalProtocols_Diseases_DiseaseId",
                table: "MedicalProtocols");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalProtocols_Diseases_DiseaseId",
                table: "MedicalProtocols",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
