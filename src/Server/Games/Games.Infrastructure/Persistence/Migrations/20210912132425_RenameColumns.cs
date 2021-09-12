namespace BettingSystem.Infrastructure.Matches.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image_Thumbnail",
                table: "Teams",
                newName: "Logo_ThumbnailContent");

            migrationBuilder.RenameColumn(
                name: "Image_Original",
                table: "Teams",
                newName: "Logo_OriginalContent");

            migrationBuilder.RenameColumn(
                name: "Image_Thumbnail",
                table: "Stadiums",
                newName: "Image_ThumbnailContent");

            migrationBuilder.RenameColumn(
                name: "Image_Original",
                table: "Stadiums",
                newName: "Image_OriginalContent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo_ThumbnailContent",
                table: "Teams",
                newName: "Image_Thumbnail");

            migrationBuilder.RenameColumn(
                name: "Logo_OriginalContent",
                table: "Teams",
                newName: "Image_Original");

            migrationBuilder.RenameColumn(
                name: "Image_ThumbnailContent",
                table: "Stadiums",
                newName: "Image_Thumbnail");

            migrationBuilder.RenameColumn(
                name: "Image_OriginalContent",
                table: "Stadiums",
                newName: "Image_Original");
        }
    }
}
