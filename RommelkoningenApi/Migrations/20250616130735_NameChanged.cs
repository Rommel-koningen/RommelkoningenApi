using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RommelkoningenApi.Migrations
{
    /// <inheritdoc />
    public partial class NameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "windrichting",
                table: "FotoData",
                newName: "Windrichting");

            migrationBuilder.RenameColumn(
                name: "temperatuur",
                table: "FotoData",
                newName: "Temperatuur");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Windrichting",
                table: "FotoData",
                newName: "windrichting");

            migrationBuilder.RenameColumn(
                name: "Temperatuur",
                table: "FotoData",
                newName: "temperatuur");
        }
    }
}
