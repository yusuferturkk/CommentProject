using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentProject.DataAccessLayer.Migrations
{
    public partial class mig_add_comment_titles_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TitleId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TitleId",
                table: "Comments",
                column: "TitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Titles_TitleId",
                table: "Comments",
                column: "TitleId",
                principalTable: "Titles",
                principalColumn: "TitleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Titles_TitleId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_TitleId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "TitleId",
                table: "Comments");
        }
    }
}
