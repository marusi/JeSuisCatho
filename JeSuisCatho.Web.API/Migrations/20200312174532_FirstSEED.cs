using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class FirstSEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Mombasa')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kwale')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kilifi')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Tana River')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Lamu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Taita-Taveta')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Garissa')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Wajir')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Mandera')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Isiolo')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Meru')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Tharaka-Nithi')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Embu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kitui')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Machakos')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Makueni')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nyandarua')");

            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nyeri')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kirinyaga')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Muranga')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kiambu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Turkana')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('West Pokot')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Samburu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Trans-Nzoia')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Uasin Gishu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Elgeyo-Marakwet')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nandi')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Baringo')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Laikipia')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nakuru')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Narok')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kajiado')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kericho')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Bomet')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kakamega')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Vihiga')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Bungoma')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Busia')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Siaya')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kisumu')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Homa Bay')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Migori')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Kisii')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nyamira')");
            migrationBuilder.Sql("INSERT INTO Locations (Name) VALUES ('Nairobi')");

            // ARCHDIOCESE TABLE SEED OF KENYA
            migrationBuilder.Sql("INSERT INTO Archdioceses (Name) VALUES ( 'Archdiocese of Kisumu') ");
            migrationBuilder.Sql("INSERT INTO Archdioceses ( Name) VALUES ('Archdiocese of Mombasa') ");
            migrationBuilder.Sql("INSERT INTO Archdioceses ( Name) VALUES ('Archdiocese of Nairobi') ");
            migrationBuilder.Sql("INSERT INTO Archdioceses ( Name) VALUES ('Archdiocese of Nyeri') ");

            // DIOCESE SEED OF RESPECTIVE ARCHDIOCESE
            // FOR RESPECTIVE ARCHDIOSES ID WE SELECT AND SEED EXACT NAME FROM DB TO AVOID LOSE OF DATA INCASE ID CHANGES
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Kisumu', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Bungoma', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Eldoret', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Homabay', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Kakamega', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of kisii', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Kitale', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Lodwar', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Kisumu'))");

            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Mombasa', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Mombasa'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Garissa', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Mombasa'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Malindi', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Mombasa'))");


            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Nairobi', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Kericho', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of kitui', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Machakos', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Nakuru', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Ngong', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nairobi'))");

            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Nyeri', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Embu', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Maralal', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Marsabit', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Meru', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Muranga', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Dioceses (Name,  ArchdioceseId ) VALUES ('Diocese of Nyahururu', ( SELECT ID FROM Archdioceses WHERE Name = 'Archdiocese of Nyeri'))");
            migrationBuilder.Sql("INSERT INTO Divisions (Name) VALUES ('Parish')");
            migrationBuilder.Sql("INSERT INTO Divisions (Name) VALUES ('Sub Parish')");

            migrationBuilder.Sql("INSERT INTO Divisions (Name) VALUES ('OutStation')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Locations");
            migrationBuilder.DropTable(name: "Archdioceses");
            migrationBuilder.DropTable(name: "Dioceses");
            migrationBuilder.DropTable(name: "Deaneries");
            migrationBuilder.DropTable(name: "Divisions");


        }
    }

}
