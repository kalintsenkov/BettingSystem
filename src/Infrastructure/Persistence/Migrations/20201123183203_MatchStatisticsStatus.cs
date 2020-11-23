namespace BettingSystem.Infrastructure.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MatchStatisticsStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Statistics_Status_Value",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Statistics_Status_Value",
                table: "Matches");
        }
    }
}
