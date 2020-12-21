using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class medicament_log_note_on_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId",
                table: "MedicamentLogNotes");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicamentId1",
                table: "MedicamentLogNotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicamentLogNotes_MedicamentId1",
                table: "MedicamentLogNotes",
                column: "MedicamentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId",
                table: "MedicamentLogNotes",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId1",
                table: "MedicamentLogNotes",
                column: "MedicamentId1",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId",
                table: "MedicamentLogNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId1",
                table: "MedicamentLogNotes");

            migrationBuilder.DropIndex(
                name: "IX_MedicamentLogNotes_MedicamentId1",
                table: "MedicamentLogNotes");

            migrationBuilder.DropColumn(
                name: "MedicamentId1",
                table: "MedicamentLogNotes");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicamentLogNotes_Medicaments_MedicamentId",
                table: "MedicamentLogNotes",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
