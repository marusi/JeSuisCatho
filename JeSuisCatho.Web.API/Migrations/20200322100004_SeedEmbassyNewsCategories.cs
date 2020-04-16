using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class SeedEmbassyNewsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Seed for news and events categories
            migrationBuilder.Sql("INSERT INTO NewsEvents (Name) VALUES ('Event')");
            migrationBuilder.Sql("INSERT INTO NewsEvents (Name) VALUES ('News')");

            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('National Celebration', ( SELECT ID FROM NewsEvents WHERE Name = 'Event'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Birthday Party', ( SELECT ID FROM NewsEvents WHERE Name = 'Event'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Cultural Day', ( SELECT ID FROM NewsEvents WHERE Name = 'Event'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Career Day', ( SELECT ID FROM NewsEvents WHERE Name = 'Event'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Open Day', ( SELECT ID FROM NewsEvents WHERE Name = 'Event'))");
       

            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Administration', ( SELECT ID FROM NewsEvents WHERE Name = 'News'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Diplomacy', ( SELECT ID FROM NewsEvents WHERE Name = 'News'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Visa', ( SELECT ID FROM NewsEvents WHERE Name = 'News'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Consular', ( SELECT ID FROM NewsEvents WHERE Name = 'News'))");
            migrationBuilder.Sql("INSERT INTO NewsCategories (Name,  NewsEventId ) VALUES ('Ambassador', ( SELECT ID FROM NewsEvents WHERE Name = 'News'))");
            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable( name: "ArticleLocations");
            migrationBuilder.DropTable( name: "Articles");
            migrationBuilder.DropTable(name: "NewsCategories");
            migrationBuilder.DropTable(name: "Locations");
            migrationBuilder.DropTable(name: "Archdioceses");
            migrationBuilder.DropTable(name: "Dioceses");
            migrationBuilder.DropTable(name: "Deaneries");
            migrationBuilder.DropTable(name: "Divisions");
            migrationBuilder.DropTable( name: "NewsEvents");
        }
    }
}
