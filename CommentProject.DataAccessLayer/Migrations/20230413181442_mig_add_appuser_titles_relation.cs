using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommentProject.DataAccessLayer.Migrations
{
    public partial class mig_add_appuser_titles_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Titles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Titles_AppUserId",
                table: "Titles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserId",
                table: "Titles",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Titles_AspNetUsers_AppUserId",
                table: "Titles");

            migrationBuilder.DropIndex(
                name: "IX_Titles_AppUserId",
                table: "Titles");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Titles");
        }
    }
}
