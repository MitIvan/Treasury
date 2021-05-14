using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PeNumber",
                table: "PresmetkovniEd",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "PresmetkovniEd",
                keyColumn: "Id",
                keyValue: 1,
                column: "PeNumber",
                value: 250);

            migrationBuilder.UpdateData(
                table: "PresmetkovniEd",
                keyColumn: "Id",
                keyValue: 2,
                column: "PeNumber",
                value: 251);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeNumber",
                table: "PresmetkovniEd");
        }
    }
}
