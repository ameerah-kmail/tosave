using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task4_userAPI.Migrations
{
    public partial class Initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ceartBY",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ceartDate",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "updateBY",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "updateDate",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ceartBY",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "ceartDate",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "updateBY",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "updateDate",
                table: "posts");
        }
    }
}
