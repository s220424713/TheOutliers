using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Outliers_E_Commerce.Migrations
{
    public partial class M01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "309d7d21-57d0-4e44-b736-38cb1b41250c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37418110-756a-472e-8789-23ff80ea2ef5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824ddd47-eb87-4a87-becd-c00168271595");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5fb22b1-5cfd-4fc7-9a69-a9119455cf5d");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "OrderDetails",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "309d7d21-57d0-4e44-b736-38cb1b41250c", "c9e7852f-c8c6-44b7-abe2-a3dc11624d0f", "Customer", "CUSTOMER" },
                    { "37418110-756a-472e-8789-23ff80ea2ef5", "e1ebf808-a6e2-42ae-a5ef-8932aa164559", "DepartmentEmployee", "DEPARTMENTEMPLOYEE" },
                    { "824ddd47-eb87-4a87-becd-c00168271595", "2b546813-bcec-4e71-a9a5-1e3d4deb7085", "Admin", "ADMIN" },
                    { "d5fb22b1-5cfd-4fc7-9a69-a9119455cf5d", "c5006a5b-8465-4f0a-8e3f-6445bad9e691", "SalesEmployee", "SALESEMPLOYEE" }
                });
        }
    }
}
