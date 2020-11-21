namespace BettingSystem.Infrastructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class GamblersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gambler_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Gambler_GamblerId",
                table: "Bets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gambler",
                table: "Gambler");

            migrationBuilder.RenameTable(
                name: "Gambler",
                newName: "Gamblers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gamblers",
                table: "Gamblers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gamblers_GamblerId",
                table: "AspNetUsers",
                column: "GamblerId",
                principalTable: "Gamblers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Gamblers_GamblerId",
                table: "Bets",
                column: "GamblerId",
                principalTable: "Gamblers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gamblers_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Gamblers_GamblerId",
                table: "Bets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gamblers",
                table: "Gamblers");

            migrationBuilder.RenameTable(
                name: "Gamblers",
                newName: "Gambler");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gambler",
                table: "Gambler",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Gambler_GamblerId",
                table: "AspNetUsers",
                column: "GamblerId",
                principalTable: "Gambler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Gambler_GamblerId",
                table: "Bets",
                column: "GamblerId",
                principalTable: "Gambler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
