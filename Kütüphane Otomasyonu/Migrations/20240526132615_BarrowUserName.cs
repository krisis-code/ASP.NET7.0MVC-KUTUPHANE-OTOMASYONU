using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitapKiralamaOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class BarrowUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Borrows",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Borrows");
        }
    }
}
