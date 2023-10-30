using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.RepositoryPattern.InfraStructure.Migrations
{
    public partial class Initial_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubMenu_Roles_RolesRoleId",
                schema: "Admin",
                table: "SubMenu");

            migrationBuilder.DropIndex(
                name: "IX_SubMenu_RolesRoleId",
                schema: "Admin",
                table: "SubMenu");

            migrationBuilder.DropColumn(
                name: "RolesRoleId",
                schema: "Admin",
                table: "SubMenu");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_RoleId",
                schema: "Admin",
                table: "SubMenu",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubMenu_Roles_RoleId",
                schema: "Admin",
                table: "SubMenu",
                column: "RoleId",
                principalSchema: "Admin",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubMenu_Roles_RoleId",
                schema: "Admin",
                table: "SubMenu");

            migrationBuilder.DropIndex(
                name: "IX_SubMenu_RoleId",
                schema: "Admin",
                table: "SubMenu");

            migrationBuilder.AddColumn<int>(
                name: "RolesRoleId",
                schema: "Admin",
                table: "SubMenu",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_RolesRoleId",
                schema: "Admin",
                table: "SubMenu",
                column: "RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubMenu_Roles_RolesRoleId",
                schema: "Admin",
                table: "SubMenu",
                column: "RolesRoleId",
                principalSchema: "Admin",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
