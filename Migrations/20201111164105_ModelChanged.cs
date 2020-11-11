using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartDripper.WebAPI.Migrations
{
    public partial class ModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_UserIdentity_UserIdentityId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_UserIdentity_UserIdentityId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_UserIdentity_UserIdentityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_UserIdentity_UserIdentityId",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdentity",
                table: "UserIdentity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "UserIdentity",
                newName: "UserIdentities");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_Admin_UserIdentityId",
                table: "Admins",
                newName: "IX_Admins_UserIdentityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdentities",
                table: "UserIdentities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_UserIdentities_UserIdentityId",
                table: "Admins",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_UserIdentities_UserIdentityId",
                table: "Devices",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_UserIdentities_UserIdentityId",
                table: "Doctors",
                column: "UserIdentityId",
                principalTable: "UserIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Admins_UserIdentities_UserIdentityId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_UserIdentities_UserIdentityId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_UserIdentities_UserIdentityId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_UserIdentities_UserIdentityId",
                table: "Nurses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserIdentities",
                table: "UserIdentities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "UserIdentities",
                newName: "UserIdentity");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserIdentityId",
                table: "Admin",
                newName: "IX_Admin_UserIdentityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserIdentity",
                table: "UserIdentity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_UserIdentity_UserIdentityId",
                table: "Admin",
                column: "UserIdentityId",
                principalTable: "UserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_UserIdentity_UserIdentityId",
                table: "Devices",
                column: "UserIdentityId",
                principalTable: "UserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_UserIdentity_UserIdentityId",
                table: "Doctors",
                column: "UserIdentityId",
                principalTable: "UserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_UserIdentity_UserIdentityId",
                table: "Nurses",
                column: "UserIdentityId",
                principalTable: "UserIdentity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
