using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class EmbassyCongo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    NewsEventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCategories_NewsEvents_NewsEventId",
                        column: x => x.NewsEventId,
                        principalTable: "NewsEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NewsCategoryId = table.Column<int>(nullable: false),
                    IsInvited = table.Column<bool>(nullable: false),
                    AmbacoTitle = table.Column<string>(maxLength: 255, nullable: false),
                    AmbacoSubTitle = table.Column<string>(maxLength: 255, nullable: false),
                    AmbacoBody = table.Column<string>(maxLength: 12000, nullable: false),
                    AmbacoDateOfEvent = table.Column<DateTime>(nullable: false),
                    AmbacoDuration = table.Column<string>(maxLength: 255, nullable: true),
                    LastUpdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_NewsCategories_NewsCategoryId",
                        column: x => x.NewsCategoryId,
                        principalTable: "NewsCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleLocations", x => new { x.ArticleId, x.LocationId });
                    table.ForeignKey(
                        name: "FK_ArticleLocations_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleLocations_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleLocations_LocationId",
                table: "ArticleLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_NewsCategoryId",
                table: "Articles",
                column: "NewsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCategories_NewsEventId",
                table: "NewsCategories",
                column: "NewsEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleLocations");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "NewsCategories");

            migrationBuilder.DropTable(
                name: "NewsEvents");
        }
    }
}
