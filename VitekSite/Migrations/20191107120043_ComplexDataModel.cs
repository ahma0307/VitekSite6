using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VitekSite.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Student_CustomerID",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Course_ProductID",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_ProductID",
                table: "Subscription",
                newName: "IX_Subscription_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_CustomerID",
                table: "Subscription",
                newName: "IX_Subscription_CustomerID");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Product",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarketID",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "SubscriptionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductID");

            migrationBuilder.CreateTable(
                name: "ProductGuide",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGuide", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CountryAssignment",
                columns: table => new
                {
                    ProductGuideID = table.Column<int>(nullable: false),
                    Location = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryAssignment", x => x.ProductGuideID);
                    table.ForeignKey(
                        name: "FK_CountryAssignment_ProductGuide_ProductGuideID",
                        column: x => x.ProductGuideID,
                        principalTable: "ProductGuide",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    MarketID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ProductGuideID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.MarketID);
                    table.ForeignKey(
                        name: "FK_Market_ProductGuide_ProductGuideID",
                        column: x => x.ProductGuideID,
                        principalTable: "ProductGuide",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductAssignment",
                columns: table => new
                {
                    ProductGuideID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAssignment", x => new { x.ProductID, x.ProductGuideID });
                    table.ForeignKey(
                        name: "FK_ProductAssignment_ProductGuide_ProductGuideID",
                        column: x => x.ProductGuideID,
                        principalTable: "ProductGuide",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAssignment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_MarketID",
                table: "Product",
                column: "MarketID");

            migrationBuilder.CreateIndex(
                name: "IX_Market_ProductGuideID",
                table: "Market",
                column: "ProductGuideID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAssignment_ProductGuideID",
                table: "ProductAssignment",
                column: "ProductGuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Market_MarketID",
                table: "Product",
                column: "MarketID",
                principalTable: "Market",
                principalColumn: "MarketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Customer_CustomerID",
                table: "Subscription",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Product_ProductID",
                table: "Subscription",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Market_MarketID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Customer_CustomerID",
                table: "Subscription");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Product_ProductID",
                table: "Subscription");

            migrationBuilder.DropTable(
                name: "CountryAssignment");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "ProductAssignment");

            migrationBuilder.DropTable(
                name: "ProductGuide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_MarketID",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "MarketID",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Course");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_ProductID",
                table: "Enrollment",
                newName: "IX_Enrollment_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_Subscription_CustomerID",
                table: "Enrollment",
                newName: "IX_Enrollment_CustomerID");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "SubscriptionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Student_CustomerID",
                table: "Enrollment",
                column: "CustomerID",
                principalTable: "Student",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Course_ProductID",
                table: "Enrollment",
                column: "ProductID",
                principalTable: "Course",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
