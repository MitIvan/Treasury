using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class denizvod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DenIzvodi",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Saldo", "VkupenPriem", "VkupnaIsplata" },
                values: new object[] { 0, 0, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DenIzvodi",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Saldo", "VkupenPriem", "VkupnaIsplata" },
                values: new object[] { 256978, 10000, 100000 });
        }
    }
}
