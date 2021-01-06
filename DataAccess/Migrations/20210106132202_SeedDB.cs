using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Adventure" },
                    { 3, "Fiction" },
                    { 4, "Mistery" }
                });

            migrationBuilder.InsertData(
                table: "CoatingTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Soft Cover" },
                    { 3, "Hard Cover" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoatingTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 4, "George", 2, 1, "Test book", "111 - 242 - 111", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", 7.0, 22.949999999999999, 17.100000000000001, 20.5, "Test book" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoatingTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 2, "George", 2, 2, "Our famous apple pies!", "111 - 111 - 111", "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", 2.0, 12.949999999999999, 9.0999999999999996, 10.5, "Apple Pie" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "CoatingTypeId", "Description", "ISBN", "ImageUrl", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[] { 3, "George", 3, 3, "Our famous books", "111 - 111 - 745", "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg", 5.0, 18.949999999999999, 14.1, 15.5, "Book 2 " });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CoatingTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CoatingTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
