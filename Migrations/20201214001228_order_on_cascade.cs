using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class order_on_cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "MedicamentId1",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MedicamentId1",
                table: "Orders",
                column: "MedicamentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId",
                table: "Orders",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId1",
                table: "Orders",
                column: "MedicamentId1",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MedicamentId1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MedicamentId1",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Medicaments_MedicamentId",
                table: "Orders",
                column: "MedicamentId",
                principalTable: "Medicaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
