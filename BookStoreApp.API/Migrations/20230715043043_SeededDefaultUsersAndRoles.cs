using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "138e1648-6573-433a-a28f-1cf287baa2cd", "3b88b51b-a9ee-4bba-93e5-7f72276803f2", "User", "USER" },
                    { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "fb4541a0-8e77-4dc3-a7fb-28f0bbf76ffb", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29390fa2-3c81-431f-9758-a3f56379826b", 0, "02570e3b-2cce-4ff1-aae5-256c58ce4f7e", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEHVKYHs9Q/8zMDJiq+qyn7hHjQVfSzj7NEN3wPoGinRqN2mZ+gRv+wa17pMOyh5iYQ==", null, false, "5f2fd3ac-ac82-4c0b-8443-9c598206e9bd", false, "admin@bookstore.com" },
                    { "52468a51-5f9b-4b66-93f1-7f374dfad875", 0, "ad70d5a3-18d2-43c5-b0b0-2dc444d1adaf", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAEAACcQAAAAEFKr/+tReN/1Hyr/HgXllD6dCw9nrn+p98jbp94nY6cA9DqySXTXv48kDmKoHCBJvA==", null, false, "28629b9c-d659-4415-ac3e-9a3d244279d1", false, "user@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "138e1648-6573-433a-a28f-1cf287baa2cd","52468a51-5f9b-4b66-93f1-7f374dfad875" },
                    { "2d1b2801-af80-4424-a6ad-d67f84892b1f","29390fa2-3c81-431f-9758-a3f56379826b"  }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "138e1648-6573-433a-a28f-1cf287baa2cd", "52468a51-5f9b-4b66-93f1-7f374dfad875" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d1b2801-af80-4424-a6ad-d67f84892b1f", "29390fa2-3c81-431f-9758-a3f56379826b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "138e1648-6573-433a-a28f-1cf287baa2cd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d1b2801-af80-4424-a6ad-d67f84892b1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29390fa2-3c81-431f-9758-a3f56379826b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52468a51-5f9b-4b66-93f1-7f374dfad875");
        }
    }
}
