namespace BettingSystem.Infrastructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class IsBetProfitable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statistics_Status_Value",
                table: "Matches",
                newName: "Status_Value");

            migrationBuilder.AddColumn<bool>(
                name: "IsProfitable",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfitable",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "Status_Value",
                table: "Matches",
                newName: "Statistics_Status_Value");
        }
    }
}
