using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Billing.RepositoryPattern.InfraStructure.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Auditable",
                schema: "Admin",
                columns: table => new
                {
                    AuditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditable", x => x.AuditId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Product",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "MainMenu",
                schema: "Admin",
                columns: table => new
                {
                    MainMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuSortOrder = table.Column<int>(type: "int", nullable: true),
                    HideFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenu", x => x.MainMenuId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Admin",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "BillingInfo",
                schema: "Product",
                columns: table => new
                {
                    BillingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillingInfo", x => x.BillingId);
                    table.ForeignKey(
                        name: "FK_BillingInfo_Customers_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalSchema: "Product",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
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
                    SubMenuSortOrder = table.Column<int>(type: "int", nullable: true),
                    HideFlag = table.Column<bool>(type: "bit", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Admin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    AuditId = table.Column<int>(type: "int", nullable: false),
                    AuditableAuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Auditable_AuditableAuditId",
                        column: x => x.AuditableAuditId,
                        principalSchema: "Admin",
                        principalTable: "Auditable",
                        principalColumn: "AuditId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalSchema: "Admin",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesDetails",
                schema: "Product",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingId = table.Column<int>(type: "int", nullable: false),
                    BillingInfoBillingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDetails", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesDetails_BillingInfo_BillingInfoBillingId",
                        column: x => x.BillingInfoBillingId,
                        principalSchema: "Product",
                        principalTable: "BillingInfo",
                        principalColumn: "BillingId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalesDetails_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalSchema: "Product",
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillingInfo_CustomersCustomerId",
                schema: "Product",
                table: "BillingInfo",
                column: "CustomersCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_BillingInfoBillingId",
                schema: "Product",
                table: "SalesDetails",
                column: "BillingInfoBillingId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesDetails_ProductsProductId",
                schema: "Product",
                table: "SalesDetails",
                column: "ProductsProductId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuditableAuditId",
                schema: "Admin",
                table: "Users",
                column: "AuditableAuditId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesRoleId",
                schema: "Admin",
                table: "Users",
                column: "RolesRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDetails",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "SubMenu",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "BillingInfo",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "MainMenu",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Auditable",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Product");
        }
    }
}
