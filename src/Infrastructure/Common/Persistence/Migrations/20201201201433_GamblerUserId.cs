namespace BettingSystem.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class GamblerUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gamblers_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamblerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Gamblers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Gamblers_UserId",
                table: "Gamblers",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gamblers_AspNetUsers_UserId",
                table: "Gamblers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gamblers_AspNetUsers_UserId",
                table: "Gamblers");

            migrationBuilder.DropIndex(
                name: "IX_Gamblers_UserId",
                table: "Gamblers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Gamblers");

            migrationBuilder.AddColumn<int>(
                name: "GamblerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GamblerId",
                table: "AspNetUsers",
                column: "GamblerId",
                unique: true,
                filter: "[GamblerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gamblers_GamblerId",
                table: "AspNetUsers",
                column: "GamblerId",
                principalTable: "Gamblers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
