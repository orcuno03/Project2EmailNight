using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2EmailNight.Migrations
{
    public partial class FixedMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStarted",
                table: "Messages",
                newName: "IsStarred");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStarred",
                table: "Messages",
                newName: "IsStarted");
        }
    }
}
