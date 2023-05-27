using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Outliers_E_Commerce.Migrations
{
    public partial class oh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "purchaseRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41abee20-7ab8-4bd0-b754-b6c5d3a9b38b", "9e14cb46-ad8e-4831-afbb-d7e8b755c884", "Admin", "ADMIN" },
                    { "493c1f6c-5190-4330-a103-b9f0cf7f2469", "563b642e-7257-4040-9d4d-6872bda30555", "Customer", "CUSTOMER" },
                    { "84052282-4fa5-4418-8d67-558e7ce9302f", "df42e7c6-7498-44d8-a7a2-12c97d2eec20", "SalesEmployee", "SALESEMPLOYEE" },
                    { "a16f188f-b83c-48b7-9d9e-138815089179", "38544c05-48c3-4340-9ad6-42de6ce1c49a", "DepartmentEmployee", "DEPARTMENTEMPLOYEE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41abee20-7ab8-4bd0-b754-b6c5d3a9b38b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "493c1f6c-5190-4330-a103-b9f0cf7f2469");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84052282-4fa5-4418-8d67-558e7ce9302f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a16f188f-b83c-48b7-9d9e-138815089179");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "purchaseRequests",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
