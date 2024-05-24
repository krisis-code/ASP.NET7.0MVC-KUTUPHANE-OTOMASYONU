using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SinemaOtomasyonu.Migrations
{
	/// <inheritdoc <Guid("7EDEA16F-E314-496B-924A-2A6BA010D477")> />
	public partial class ForeignKeyAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BookGenreId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookGenreId",
                table: "Books",
                column: "BookGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Genres_BookGenreId",
                table: "Books",
                column: "BookGenreId",
                principalTable: "Genres",
                principalColumn: "BookGenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Genres_BookGenreId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookGenreId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookGenreId",
                table: "Books");
        }
    }
}
