using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResourceManagementSystem.Infrastructure.Migrations
{
    public partial class DatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Staffs_UserId",
                        column: x => x.UserId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StaffID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Staffs_StaffID",
                        column: x => x.StaffID,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CreatedAt", "LastModifiedAt", "Title" },
                values: new object[,]
                {
                    { "C001", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8246), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Food Items" },
                    { "C002", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8270), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clothing" },
                    { "C003", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8271), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Electronic Appliances" },
                    { "C004", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8273), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Art & Music" },
                    { "C005", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8274), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sport Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "CreatedAt", "LastModifiedAt", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { "P001", "C001", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8584), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bread", 1.45m, 1000 },
                    { "P002", "C001", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8587), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eggs", 4.5m, 500 },
                    { "P003", "C002", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8590), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Polo T-Shirt", 7.00m, 25 },
                    { "P004", "C002", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8592), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Regular Jeans", 7.45m, 25 },
                    { "P005", "C002", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8596), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travel Joggers", 12m, 20 },
                    { "P006", "C003", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8598), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung Galaxy S22 Ultra", 250m, 15 },
                    { "P007", "C003", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASUS Zenbook", 1250m, 15 },
                    { "P008", "C004", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8602), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lord of the Ring", 18.25m, 15 },
                    { "P009", "C004", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8603), new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8604), "Fender Guitar", 100m, 12 },
                    { "P010", "C005", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8605), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hockey Stick", 125m, 15 },
                    { "P011", "C005", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8606), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sports Wear", 50m, 15 },
                    { "P012", "C005", new DateTime(2022, 8, 31, 8, 57, 9, 179, DateTimeKind.Local).AddTicks(8607), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gym Hero", 75m, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductID",
                table: "OrderLines",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffID",
                table: "Orders",
                column: "StaffID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Staffs",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Staffs",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
