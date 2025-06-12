using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RommelkoningenApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FotoData",
                columns: table => new
                {
                    Foto_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Datum_En_Tijd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Camera_Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<float>(type: "real", nullable: false),
                    Latitude = table.Column<float>(type: "real", nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    windrichting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    temperatuur = table.Column<int>(type: "int", nullable: false),
                    Weer_Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoData", x => x.Foto_Id);
                });

            migrationBuilder.CreateTable(
                name: "AfvalData",
                columns: table => new
                {
                    Afval_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Foto_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Afval_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confidence = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfvalData", x => x.Afval_Id);
                    table.ForeignKey(
                        name: "FK_AfvalData_FotoData_Foto_Id",
                        column: x => x.Foto_Id,
                        principalTable: "FotoData",
                        principalColumn: "Foto_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AfvalData_Foto_Id",
                table: "AfvalData",
                column: "Foto_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfvalData");

            migrationBuilder.DropTable(
                name: "FotoData");
        }
    }
}
