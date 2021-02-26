using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class doctorondelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_UserIdentities_UserIdentityId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_UserIdentityId",
                table: "Doctors");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_UserIdentities_Id",
                table: "Doctors",
                column: "Id",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_UserIdentities_Id",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserIdentityId",
                table: "Doctors",
                column: "UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_UserIdentities_UserIdentityId",
                table: "Doctors",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
