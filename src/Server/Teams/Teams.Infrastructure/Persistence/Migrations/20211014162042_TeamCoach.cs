namespace BettingSystem.Infrastructure.Teams.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TeamCoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CoachId",
                table: "Teams",
                column: "CoachId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Coaches_CoachId",
                table: "Teams",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Coaches_CoachId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Teams_CoachId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CoachId",
                table: "Teams");
        }
    }
}
