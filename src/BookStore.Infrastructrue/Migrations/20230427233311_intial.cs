using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Infrastructrue.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RackId1",
                table: "Shelves",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShelfId1",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shelves_RackId1",
                table: "Shelves",
                column: "RackId1");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ShelfId1",
                table: "Books",
                column: "ShelfId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Shelves_ShelfId1",
                table: "Books",
                column: "ShelfId1",
                principalTable: "Shelves",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Shelves_Racks_RackId1",
                table: "Shelves",
                column: "RackId1",
                principalTable: "Racks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Shelves_ShelfId1",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Shelves_Racks_RackId1",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Shelves_RackId1",
                table: "Shelves");

            migrationBuilder.DropIndex(
                name: "IX_Books_ShelfId1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "RackId1",
                table: "Shelves");

            migrationBuilder.DropColumn(
                name: "ShelfId1",
                table: "Books");
        }
    }
}
