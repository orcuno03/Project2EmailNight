using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2EmailNight.Migrations
{
    public partial class AddMessageFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDraft",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpam",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrash",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsDraft",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsSpam",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsTrash",
                table: "Messages");
        }
    }
}
