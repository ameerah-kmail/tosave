using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4_userAPI.Migrations
{
    public partial class UserPostRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_posts_userId",
                table: "posts",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_userId",
                table: "posts",
                column: "userId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_userId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_userId",
                table: "posts");
        }
    }
}
