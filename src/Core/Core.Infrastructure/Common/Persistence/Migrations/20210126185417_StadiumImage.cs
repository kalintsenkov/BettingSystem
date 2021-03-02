namespace BettingSystem.Infrastructure.Common.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class StadiumImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Stadiums");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image_OriginalContent",
                table: "Stadiums",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image_ThumbnailContent",
                table: "Stadiums",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_OriginalContent",
                table: "Stadiums");

            migrationBuilder.DropColumn(
                name: "Image_ThumbnailContent",
                table: "Stadiums");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Stadiums",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");
        }
    }
}
