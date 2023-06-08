using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBYS.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class sec_mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "KullaniciId",
                table: "Gorev",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonelId",
                table: "Gorev",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Gorev_KullaniciId",
                table: "Gorev",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorev_PersonelId",
                table: "Gorev",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gorev_Kullanici_KullaniciId",
                table: "Gorev",
                column: "KullaniciId",
                principalTable: "Kullanici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gorev_Personel_PersonelId",
                table: "Gorev",
                column: "PersonelId",
                principalTable: "Personel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gorev_Kullanici_KullaniciId",
                table: "Gorev");

            migrationBuilder.DropForeignKey(
                name: "FK_Gorev_Personel_PersonelId",
                table: "Gorev");

            migrationBuilder.DropIndex(
                name: "IX_Gorev_KullaniciId",
                table: "Gorev");

            migrationBuilder.DropIndex(
                name: "IX_Gorev_PersonelId",
                table: "Gorev");

            migrationBuilder.DropColumn(
                name: "KullaniciId",
                table: "Gorev");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Gorev");
        }
    }
}
