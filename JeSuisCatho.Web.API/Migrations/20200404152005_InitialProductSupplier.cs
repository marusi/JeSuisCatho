using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class InitialProductSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactTitle = table.Column<string>(maxLength: 255, nullable: false),
                    Address1 = table.Column<string>(maxLength: 255, nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    County = table.Column<string>(maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: false),
                    MobileNo = table.Column<string>(maxLength: 70, nullable: false),
                    Email = table.Column<string>(maxLength: 150, nullable: false),
                    URL = table.Column<string>(maxLength: 255, nullable: false),
                    TypeGoods = table.Column<string>(maxLength: 255, nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CategoryItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryItems_CategoryItems_CategoryItemId",
                        column: x => x.CategoryItemId,
                        principalTable: "CategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubCategoryItemId = table.Column<int>(nullable: false),
                    ProductAvailable = table.Column<bool>(nullable: false),
                    DiscountAvailable = table.Column<bool>(nullable: false),
                    InfoVendorProductID = table.Column<int>(nullable: false),
                    InfoProductName = table.Column<string>(maxLength: 255, nullable: false),
                    InfoProductDescription = table.Column<string>(maxLength: 255, nullable: false),
                    InfoNote = table.Column<string>(maxLength: 255, nullable: true),
                    SellQuantityPerUnit = table.Column<int>(nullable: false),
                    SellUnitPrice = table.Column<decimal>(nullable: false),
                    SellDiscount = table.Column<decimal>(nullable: false),
                    SellUnitWeight = table.Column<int>(nullable: false),
                    SellUnitInStock = table.Column<int>(nullable: false),
                    SellUnitsOnOrder = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_SubCategoryItems_SubCategoryItemId",
                        column: x => x.SubCategoryItemId,
                        principalTable: "SubCategoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSuppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSuppliers", x => new { x.ProductId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryItemId",
                table: "Products",
                column: "SubCategoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSuppliers_SupplierId",
                table: "ProductSuppliers",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItems_CategoryItemId",
                table: "SubCategoryItems",
                column: "CategoryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSuppliers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "SubCategoryItems");

            migrationBuilder.DropTable(
                name: "CategoryItems");
        }
    }
}
