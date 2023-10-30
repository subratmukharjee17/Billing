using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.RepositoryPattern.InfraStructure.Migrations
{
    public partial class Initial_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainMenu",
                schema: "Admin",
                columns: table => new
                {
                    MainMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenu", x => x.MainMenuId);
                });

            migrationBuilder.CreateTable(
                name: "SubMenu",
                schema: "Admin",
                columns: table => new
                {
                    SubMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMenuId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenu", x => x.SubMenuId);
                    table.ForeignKey(
                        name: "FK_SubMenu_MainMenu_MainMenuId",
                        column: x => x.MainMenuId,
                        principalSchema: "Admin",
                        principalTable: "MainMenu",
                        principalColumn: "MainMenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubMenu_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalSchema: "Admin",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_MainMenuId",
                schema: "Admin",
                table: "SubMenu",
                column: "MainMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenu_RolesRoleId",
                schema: "Admin",
                table: "SubMenu",
                column: "RolesRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubMenu",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "MainMenu",
                schema: "Admin");
        }
    }
}
