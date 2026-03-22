using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2EmailNight.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isStatus",
                table: "Messages",
                newName: "IsStatus");

            migrationBuilder.AlterColumn<bool>(
                name: "IsStatus",
                table: "Messages",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStatus",
                table: "Messages",
                newName: "isStatus");

            migrationBuilder.AlterColumn<string>(
                name: "isStatus",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
