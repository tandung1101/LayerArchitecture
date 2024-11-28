using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayerArchitecture.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pencil", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Book", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new Guid("d2f2c4e6-6a5b-4b78-bcb5-4d56a8e17e9f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Handbook", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6f9a9c21-4cfa-4b52-1111-c2b8d7e26711"), new Guid("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), new DateTime(2024, 11, 28, 10, 5, 20, 368, DateTimeKind.Local).AddTicks(1352), "Pen 1", 100m, 20, null },
                    { new Guid("6f9a9c21-4cfa-4b52-2222-c2b8d7e26711"), new Guid("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), new DateTime(2024, 11, 28, 10, 5, 20, 368, DateTimeKind.Local).AddTicks(1362), "Pen 2", 200m, 30, null },
                    { new Guid("6f9a9c21-4cfa-4b52-3333-c2b8d7e26711"), new Guid("6f9a9c21-4cfa-4b52-8581-c2b8d7e26711"), new DateTime(2024, 11, 28, 10, 5, 20, 368, DateTimeKind.Local).AddTicks(1365), "Pen 3", 600m, 60, null },
                    { new Guid("6f9a9c21-4cfa-4b52-4444-c2b8d7e26711"), new Guid("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), new DateTime(2024, 11, 28, 10, 5, 20, 368, DateTimeKind.Local).AddTicks(1367), "Book 1", 600m, 60, null },
                    { new Guid("6f9a9c21-4cfa-4b52-5555-c2b8d7e26711"), new Guid("9b1ec4d7-39f7-493a-bef4-4bcff24da0d3"), new DateTime(2024, 11, 28, 10, 5, 20, 368, DateTimeKind.Local).AddTicks(1370), "Book 2", 6600m, 320, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { new Guid("401b7c7b-512e-4fff-a9cd-71a707e82e53"), "Red", 100, new Guid("6f9a9c21-4cfa-4b52-1111-c2b8d7e26711"), 200 });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { new Guid("f264c7ca-91b7-41e1-9286-4a61a1b41e63"), "Blue", 300, new Guid("6f9a9c21-4cfa-4b52-2222-c2b8d7e26711"), 200 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
