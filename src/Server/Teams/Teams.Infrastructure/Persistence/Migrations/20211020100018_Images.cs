namespace BettingSystem.Infrastructure.Teams.Persistence.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo_OriginalContent",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Logo_ThumbnailContent",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ThumbnailContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_LogoId",
                table: "Teams",
                column: "LogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Images_LogoId",
                table: "Teams",
                column: "LogoId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Images_LogoId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Teams_LogoId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Teams");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo_OriginalContent",
                table: "Teams",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo_ThumbnailContent",
                table: "Teams",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
