using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class DeletePatientLogNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientsLogNotes");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");

            migrationBuilder.CreateTable(
                name: "PatientsLogNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsLogNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientsLogNotes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientsLogNotes_PatientId",
                table: "PatientsLogNotes",
                column: "PatientId");
        }
    }
}
