using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Outliers_E_Commerce.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ff73ccd-e25d-49dd-a63a-e8e5ed0a7f57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "521e87c4-569a-4974-a1d5-d6f29d8cbad6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5988c44b-673d-4df1-a3ff-de83ba556920");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c8e8079-bf1c-4adc-87d0-30c79cd38407");

            migrationBuilder.AddColumn<int>(
                name: "Supplierid",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "SaleOrders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Supplierid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deliveryData = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Supplierid);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employeeid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DepartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employeeid);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_ID",
                        column: x => x.ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Departments_DepartID",
                        column: x => x.DepartID,
                        principalTable: "Departments",
                        principalColumn: "DepartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequest_VM",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employeeid = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseRID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequest_VM", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequest_VM_Employee_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "Employee",
                        principalColumn: "Employeeid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequest_VM_tblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tblProduct",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseRequests",
                columns: table => new
                {
                    RequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employeeid = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseRequests", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_purchaseRequests_Employee_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "Employee",
                        principalColumn: "Employeeid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "267b9376-72f7-4c1b-9ad5-29aa7f4935f0", "7a3ce6f9-d315-4ab4-b316-8f5c9c061a8b", "SalesEmployee", "SALESEMPLOYEE" },
                    { "595b3461-ff63-4854-9075-ac05ca5b6896", "80993bfd-9062-4b63-96ec-9d6254ad9b21", "Customer", "CUSTOMER" },
                    { "5bb4095a-ab72-43ab-baa9-1a945a1bf4c8", "cbd1548c-bbe0-46bd-bcac-9b0906cbc92a", "Admin", "ADMIN" },
                    { "ef1d8d4a-cb39-4f73-9166-c693246efd75", "9e800725-2b9f-4d71-8a4b-73ca04bc4580", "DepartmentEmployee", "DEPARTMENTEMPLOYEE" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_Supplierid",
                table: "tblProduct",
                column: "Supplierid");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartID",
                table: "Employee",
                column: "DepartID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ID",
                table: "Employee",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_VM_Employeeid",
                table: "PurchaseRequest_VM",
                column: "Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequest_VM_ProductID",
                table: "PurchaseRequest_VM",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseRequests_Employeeid",
                table: "purchaseRequests",
                column: "Employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_Supplier_Supplierid",
                table: "tblProduct",
                column: "Supplierid",
                principalTable: "Supplier",
                principalColumn: "Supplierid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_Supplier_Supplierid",
                table: "tblProduct");

            migrationBuilder.DropTable(
                name: "PurchaseRequest_VM");

            migrationBuilder.DropTable(
                name: "purchaseRequests");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_Supplierid",
                table: "tblProduct");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267b9376-72f7-4c1b-9ad5-29aa7f4935f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595b3461-ff63-4854-9075-ac05ca5b6896");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bb4095a-ab72-43ab-baa9-1a945a1bf4c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef1d8d4a-cb39-4f73-9166-c693246efd75");

            migrationBuilder.DropColumn(
                name: "Supplierid",
                table: "tblProduct");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "SaleOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3ff73ccd-e25d-49dd-a63a-e8e5ed0a7f57", "868f8094-f05f-4980-bd5b-6d8f5c98f2ec", "SalesEmployee", "SALESEMPLOYEE" },
                    { "521e87c4-569a-4974-a1d5-d6f29d8cbad6", "b0370bf8-9d68-4548-ab6e-28c17bda1e3d", "DepartmentEmployee", "DEPARTMENTEMPLOYEE" },
                    { "5988c44b-673d-4df1-a3ff-de83ba556920", "0fdd009c-2170-44b5-bf9c-fa7d9bc7a4ef", "Customer", "CUSTOMER" },
                    { "8c8e8079-bf1c-4adc-87d0-30c79cd38407", "1abeb76f-6453-4558-9ea8-f63c2187cc68", "Admin", "ADMIN" }
                });
        }
    }
}
