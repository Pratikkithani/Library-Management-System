using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Identity.Migrations
{
    /// <inheritdoc />
    public partial class InitialIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "436f5faa-8c4c-40ad-be12-4bd345174e83", "AQAAAAIAAYagAAAAEBStVdxoCuikQu6jx3BuOk2QXqSHanUXm4be+L6mzRNBPcuMniydu/RoiQI0sDfrmg==", "2066cbfc-36c4-42fd-a931-6dfd76ac05a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06fc1f68-3d5d-4810-a072-f389ab7bc930", "AQAAAAIAAYagAAAAED81z2fi+xL/y9rhgSAw7n70VBGaUxRLGE2cjJSzovHMynlyaYyfaKoujTR0SPbQMA==", "66a9b133-00b7-4c31-abce-bbc3e1a18757" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77f52f35-091f-4110-9168-464f8f3ea043", "AQAAAAIAAYagAAAAEKf2gy8HsfqVy8eY8CkhhHdfqTZhm9z5rCaVz6TRCq9BareKBnTLfOYL5KLpjLFPgw==", "e911fb87-2f55-4f57-b94e-7df5e6ff1739" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "94ae21fc-776e-49ba-b5d8-c9f3e407cf0b", "AQAAAAIAAYagAAAAEMs3ebqP8xwsekhCkrSosWSSQ01JIVIuzonZi34sKM8aCvPGosL5IQksfTx8FEVnmw==", "66c46fcc-7a36-417e-b50f-cdc721e0ec4b" });
        }
    }
}
