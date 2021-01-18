namespace BettingSystem.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class TeamPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Teams");
        }
    }
}
