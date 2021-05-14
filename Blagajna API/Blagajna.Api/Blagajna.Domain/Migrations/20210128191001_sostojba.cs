using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class sostojba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DenBlSostojba",
                columns: new[] { "Id", "DenSostojba" },
                values: new object[] { 1, 1000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DenBlSostojba",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
