using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LINQTask.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Discount_Percentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
               name: "PurchaseOrders",
               columns: table => new
               {
                   PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   CustomerID = table.Column<int>(type: "int", nullable: false),
                   Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                   Amount = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                   table.ForeignKey(
                   name: "FK_PurchaseOrders_Customers_CustomerID",
                   column: x => x.CustomerID,
                   principalTable: "Customers",
                   principalColumn: "CustomerID",
                   onDelete: ReferentialAction.Restrict);
               });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetails",
                columns: table => new
                {
                    PurchaseDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseOrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetails", x => x.PurchaseDetailsID);
                    table.ForeignKey(
                    name: "FK_PurchaseOrderDetails__PurchaseOrderId ",
                    column: x => x.PurchaseOrderID,
                    principalTable: "PurchaseOrders",
                    principalColumn: "PurchaseOrderId",
                    onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                    name: "FK_PurchaseOrderDetails_Products_ProductID ",
                    column: x => x.ProductID,
                    principalTable: "Products",
                    principalColumn: "ProductID",
                    onDelete: ReferentialAction.Restrict);
                });

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetails");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");
        }
    }
}
