using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class newSmetka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalSmetki",
                table: "DenDocumnents");

            migrationBuilder.InsertData(
                table: "DenSmetki",
                columns: new[] { "Id", "DenDocumnetId", "SmetkaDate", "SmetkaInfo", "SmetkaTotal" },
                values: new object[] { 2, 1, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "123w", 4000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DenSmetki",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "TotalSmetki",
                table: "DenDocumnents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
