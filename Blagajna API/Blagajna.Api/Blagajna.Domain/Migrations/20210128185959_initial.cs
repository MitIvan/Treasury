using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Blagajna.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DenBlSostojba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenSostojba = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenBlSostojba", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DenIzvodi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VkupnaIsplata = table.Column<int>(nullable: false),
                    VkupenPriem = table.Column<int>(nullable: false),
                    Saldo = table.Column<int>(nullable: false),
                    DenBlSostojba = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenIzvodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PresmetkovniEd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresmetkovniEd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vraboteni",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mb = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vraboteni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DenDocumnents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocDate = table.Column<DateTime>(nullable: false),
                    VidDocument = table.Column<int>(nullable: false),
                    PresmetkovnaEdId = table.Column<int>(nullable: false),
                    VrabotenId = table.Column<int>(nullable: false),
                    Zabeleska = table.Column<string>(maxLength: 200, nullable: true),
                    TotalSmetki = table.Column<int>(nullable: false),
                    DenIzvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenDocumnents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenDocumnents_DenIzvodi_DenIzvodId",
                        column: x => x.DenIzvodId,
                        principalTable: "DenIzvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenDocumnents_PresmetkovniEd_PresmetkovnaEdId",
                        column: x => x.PresmetkovnaEdId,
                        principalTable: "PresmetkovniEd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DenDocumnents_Vraboteni_VrabotenId",
                        column: x => x.VrabotenId,
                        principalTable: "Vraboteni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DenSmetki",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmetkaInfo = table.Column<string>(nullable: true),
                    SmetkaDate = table.Column<DateTime>(nullable: false),
                    SmetkaTotal = table.Column<int>(nullable: false),
                    DenDocumnetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DenSmetki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DenSmetki_DenDocumnents_DenDocumnetId",
                        column: x => x.DenDocumnetId,
                        principalTable: "DenDocumnents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PresmetkovniEd",
                columns: new[] { "Id", "PeName" },
                values: new object[,]
                {
                    { 1, "SK 123 ZZ" },
                    { 2, "SK 124 HZ" }
                });

            migrationBuilder.InsertData(
                table: "Vraboteni",
                columns: new[] { "Id", "FullName", "Mb" },
                values: new object[,]
                {
                    { 1, "Ivan Mitev", 190 },
                    { 2, "Ljubica Donevska", 191 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DenDocumnents_DenIzvodId",
                table: "DenDocumnents",
                column: "DenIzvodId");

            migrationBuilder.CreateIndex(
                name: "IX_DenDocumnents_PresmetkovnaEdId",
                table: "DenDocumnents",
                column: "PresmetkovnaEdId");

            migrationBuilder.CreateIndex(
                name: "IX_DenDocumnents_VrabotenId",
                table: "DenDocumnents",
                column: "VrabotenId");

            migrationBuilder.CreateIndex(
                name: "IX_DenSmetki_DenDocumnetId",
                table: "DenSmetki",
                column: "DenDocumnetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DenBlSostojba");

            migrationBuilder.DropTable(
                name: "DenSmetki");

            migrationBuilder.DropTable(
                name: "DenDocumnents");

            migrationBuilder.DropTable(
                name: "DenIzvodi");

            migrationBuilder.DropTable(
                name: "PresmetkovniEd");

            migrationBuilder.DropTable(
                name: "Vraboteni");
        }
    }
}
