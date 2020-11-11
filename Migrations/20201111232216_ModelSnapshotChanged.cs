using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class ModelSnapshotChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_UserIdentities_UserIdentityId",
                table: "Nurses");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_UserIdentities_UserIdentityId",
                table: "Nurses",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_UserIdentities_UserIdentityId",
                table: "Nurses");

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_UserIdentities_UserIdentityId",
                table: "Nurses",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
