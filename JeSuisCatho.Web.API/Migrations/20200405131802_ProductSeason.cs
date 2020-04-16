using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class ProductSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ProductOfSeason",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductOfSeason",
                table: "Products");
        }
    }
}
