using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class correctuserroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "138e1648-6573-433a-a28f-1cf287baa2cd", "29390fa2-3c81-431f-9758-a3f56379826b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "52468a51-5f9b-4b66-93f1-7f374dfad875" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "138e1648-6573-433a-a28f-1cf287baa2cd",
                column: "ConcurrencyStamp",
                value: "c14d1f78-8ac6-4d45-b815-b8c77e4e77d2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1b2801-af80-4424-a6ad-d67f84892b1f",
                column: "ConcurrencyStamp",
                value: "d8b0eced-3a6d-4026-8a72-6eca3d7da044");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "29390fa2-3c81-431f-9758-a3f56379826b" },
                    { "138e1648-6573-433a-a28f-1cf287baa2cd", "52468a51-5f9b-4b66-93f1-7f374dfad875" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29390fa2-3c81-431f-9758-a3f56379826b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ef69627e-6c60-49e1-a09d-2ec7b1323ad1", "AQAAAAEAACcQAAAAED6XEeHZIbA7/Oz0KG91x3XBuQLXWOqn1VDEtHm33xQRUAf0tbbNNc/sP4IXYeFKOw==", "5c851abf-ffa9-42d4-8e06-732f4ee44cea" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52468a51-5f9b-4b66-93f1-7f374dfad875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80a8695f-16d2-4adb-a8cc-ed4aa090350d", "AQAAAAEAACcQAAAAEEuKtS45bmvQVeKZZMv/lGWZz7hoE+KvMFB1HoH9XCy6lF6GgL+C+8vD6+pFdTJxsA==", "e64c2a36-d36b-4993-b2a0-3f8a33996574" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "29390fa2-3c81-431f-9758-a3f56379826b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "138e1648-6573-433a-a28f-1cf287baa2cd", "52468a51-5f9b-4b66-93f1-7f374dfad875" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "138e1648-6573-433a-a28f-1cf287baa2cd",
                column: "ConcurrencyStamp",
                value: "3b88b51b-a9ee-4bba-93e5-7f72276803f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1b2801-af80-4424-a6ad-d67f84892b1f",
                column: "ConcurrencyStamp",
                value: "fb4541a0-8e77-4dc3-a7fb-28f0bbf76ffb");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "138e1648-6573-433a-a28f-1cf287baa2cd", "29390fa2-3c81-431f-9758-a3f56379826b" },
                    { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "52468a51-5f9b-4b66-93f1-7f374dfad875" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29390fa2-3c81-431f-9758-a3f56379826b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02570e3b-2cce-4ff1-aae5-256c58ce4f7e", "AQAAAAEAACcQAAAAEHVKYHs9Q/8zMDJiq+qyn7hHjQVfSzj7NEN3wPoGinRqN2mZ+gRv+wa17pMOyh5iYQ==", "5f2fd3ac-ac82-4c0b-8443-9c598206e9bd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52468a51-5f9b-4b66-93f1-7f374dfad875",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad70d5a3-18d2-43c5-b0b0-2dc444d1adaf", "AQAAAAEAACcQAAAAEFKr/+tReN/1Hyr/HgXllD6dCw9nrn+p98jbp94nY6cA9DqySXTXv48kDmKoHCBJvA==", "28629b9c-d659-4415-ac3e-9a3d244279d1" });
        }
    }
}
