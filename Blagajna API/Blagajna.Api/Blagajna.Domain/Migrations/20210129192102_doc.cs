using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class doc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FinalIzvod",
                table: "DenIzvodi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "IzvodDate",
                table: "DenIzvodi",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "DenIzvodi",
                columns: new[] { "Id", "DenBlSostojba", "FinalIzvod", "IzvodDate", "Saldo", "VkupenPriem", "VkupnaIsplata" },
                values: new object[] { 1, 1000000, false, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 256978, 10000, 100000 });

            migrationBuilder.InsertData(
                table: "DenDocumnents",
                columns: new[] { "Id", "DenIzvodId", "DocDate", "PresmetkovnaEdId", "TotalSmetki", "VidDocument", "VrabotenId", "Zabeleska" },
                values: new object[] { 1, 1, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 1, 1, null });

            migrationBuilder.InsertData(
                table: "DenSmetki",
                columns: new[] { "Id", "DenDocumnetId", "SmetkaDate", "SmetkaInfo", "SmetkaTotal" },
                values: new object[] { 1, 1, new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "1234aaa", 1000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DenSmetki",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DenDocumnents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DenIzvodi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FinalIzvod",
                table: "DenIzvodi");

            migrationBuilder.DropColumn(
                name: "IzvodDate",
                table: "DenIzvodi");
        }
    }
}
