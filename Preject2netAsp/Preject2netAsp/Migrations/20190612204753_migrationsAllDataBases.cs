using Microsoft.EntityFrameworkCore.Migrations;

namespace Preject2netAsp.Migrations
{
    public partial class migrationsAllDataBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Friends",
                table: "Friends");

            migrationBuilder.RenameTable(
                name: "Friends",
                newName: "friend");

            migrationBuilder.AddPrimaryKey(
                name: "PK_friend",
                table: "friend",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "toptraks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Artist_id = table.Column<string>(nullable: true),
                    Artist_name = table.Column<string>(nullable: true),
                    Artist_idstr = table.Column<string>(nullable: true),
                    Album_name = table.Column<string>(nullable: true),
                    Albums_id = table.Column<string>(nullable: true),
                    License_ccurl = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Releasedate = table.Column<string>(nullable: true),
                    Album_Image = table.Column<string>(nullable: true),
                    Audio = table.Column<string>(nullable: true),
                    Audiodownload = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_toptraks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "toptraks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_friend",
                table: "friend");

            migrationBuilder.RenameTable(
                name: "friend",
                newName: "Friends");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friends",
                table: "Friends",
                column: "Id");
        }
    }
}
