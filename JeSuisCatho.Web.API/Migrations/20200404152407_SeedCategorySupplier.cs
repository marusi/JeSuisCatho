using Microsoft.EntityFrameworkCore.Migrations;

namespace JeSuisCatho.Web.API.Migrations
{
    public partial class SeedCategorySupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Fleshy Fruit') ");
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Dry Fruit') ");
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Aggregate Fruit') ");
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Multiple Fruit') ");
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Accessory Fruit') ");
            migrationBuilder.Sql("INSERT INTO CategoryItems (Name) VALUES ('Vegetable') ");


            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Avocados', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Berries', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Citrus', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Drupes', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Hesperidia', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Melons', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Pepos', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Pomes', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Tropical and Exotic', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Tomatoes', ( SELECT ID FROM CategoryItems WHERE Name = 'Fleshy Fruit'))");


            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Follicie', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Legume', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Capsule', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Silique', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Achene', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Caryopsis or grain', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Samara', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Schizocarp', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Loment', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Nut', ( SELECT ID FROM CategoryItems WHERE Name = 'Dry Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Matured ovaries formed in a single flower and arranged over the " +
                "surface of a single receptable', ( SELECT ID FROM CategoryItems WHERE Name = 'Aggregate Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Matured ovaries formed of several to many flowers more or less united into a mass '," +
                " ( SELECT ID FROM CategoryItems WHERE Name = 'Multiple Fruit'))");
            migrationBuilder.Sql("INSERT INTO SubCategoryItems (Name,  CategoryItemId ) VALUES ('Develop from tissues surrounding the ovaries', ( SELECT ID FROM CategoryItems WHERE Name = 'Accessory Fruit'))");


            migrationBuilder.Sql("INSERT INTO Suppliers (CompanyName, FirstName, LastName, ContactTitle, Address1, Address2, City, County, PostalCode, MobileNo, Email, URL, TypeGoods, Notes) VALUES ('MaryMarakha', 'Mary', 'Marakha', 'Wa Matunda', '59197-00200 Nairobi', 'Moi Drive, Osupuko Road, Umoja II - Old Stage after Chiefs Camp', 'Nairobi', 'Nairobi', '00200, City Square', '0722522604', 'emarakha@yahoo.com', 'to be updated', 'Fruits', 'Fruits are my speciality') ");
            migrationBuilder.Sql("INSERT INTO Suppliers (CompanyName, FirstName, LastName, ContactTitle, Address1, Address2, City, County, PostalCode, MobileNo, Email, URL, TypeGoods, Notes) VALUES ('Deleted', 'Edgar', 'Marakha', 'Kiambu Fruiters', '59197-00200 Nairobi', 'Juja, Thika Road, Kimbo - Stage', 'Thika', 'Kiambu', '00200, City Square', '0702890432', 'edgargamarusi@live.com', 'to be updated', 'Fruits', 'Fruits are my speciality') ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SubCategoryItems");
            migrationBuilder.Sql("DELETE FROM CategoryItems");
            migrationBuilder.Sql("DELETE FROM Suppliers");
         
        }
    }
}
