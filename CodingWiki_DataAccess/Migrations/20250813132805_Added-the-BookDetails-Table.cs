using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedtheBookDetailsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategorys",
                table: "SubCategorys");

            migrationBuilder.RenameTable(
                name: "SubCategorys",
                newName: "SubCategories");

            migrationBuilder.AddColumn<int>(
                name: "BookDetail_Id",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategory_Id");

            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    BookDetail_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfChapters = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.BookDetail_Id);
                });

            migrationBuilder.InsertData(
                table: "BookDetails",
                columns: new[] { "BookDetail_Id", "NumberOfChapters", "NumberOfPages", "Weight" },
                values: new object[,]
                {
                    { 1, 10, 100, "1kg" },
                    { 2, 12, 120, "1.2kg" },
                    { 3, 8, 80, "0.8kg" },
                    { 4, 15, 150, "1.5kg" },
                    { 5, 20, 200, "2kg" },
                    { 6, 18, 180, "1.8kg" },
                    { 7, 22, 220, "2.2kg" },
                    { 8, 25, 250, "2.5kg" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "BookDetail_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "BookDetail_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "BookDetail_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4,
                column: "BookDetail_Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 5,
                column: "BookDetail_Id",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 6,
                column: "BookDetail_Id",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 7,
                column: "BookDetail_Id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 8,
                column: "BookDetail_Id",
                value: 8);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetails_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "BookDetail_Id",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategorys",
                table: "SubCategorys",
                column: "SubCategory_Id");
        }
    }
}
