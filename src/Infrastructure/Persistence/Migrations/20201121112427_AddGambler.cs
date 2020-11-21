namespace BettingSystem.Infrastructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGambler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bets");

            migrationBuilder.AddColumn<int>(
                name: "GamblerId",
                table: "Bets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GamblerId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gambler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gambler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_GamblerId",
                table: "Bets",
                column: "GamblerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GamblerId",
                table: "AspNetUsers",
                column: "GamblerId",
                unique: true,
                filter: "[GamblerId] IS NOT NULL");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Gambler_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Gambler_GamblerId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "Gambler");

            migrationBuilder.DropIndex(
                name: "IX_Bets_GamblerId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GamblerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GamblerId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "GamblerId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_AspNetUsers_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
