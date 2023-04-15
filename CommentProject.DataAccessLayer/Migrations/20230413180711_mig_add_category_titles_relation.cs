using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentProject.DataAccessLayer.Migrations
{
    public partial class mig_add_category_titles_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_CategoryId",
                table: "Titles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_Categories_CategoryId",
                table: "Titles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_Categories_CategoryId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_CategoryId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Titles");
        }
    }
}
