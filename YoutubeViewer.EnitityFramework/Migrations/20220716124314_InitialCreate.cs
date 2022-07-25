using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YoutubeViewer.EnitityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "youtubeViewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    IsSubscribed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMember = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_youtubeViewers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "youtubeViewers");
        }
    }
}
