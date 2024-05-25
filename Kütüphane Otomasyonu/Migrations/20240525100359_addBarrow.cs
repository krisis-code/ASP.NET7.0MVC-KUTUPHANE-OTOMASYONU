using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KitapKiralamaOtomasyonu.Migrations
{
    /// <inheritdoc />
    public partial class addBarrow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "borrows",
                columns: table => new
                {
                    BorrowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrows", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_borrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_borrows_BookId",
                table: "borrows",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrows");
        }
    }
}
