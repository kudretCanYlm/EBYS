using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EBYS.DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_df : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Kullanici",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Kullanici");
        }
    }
}
