using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Trashtalk.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangesTypeOfGeoCordInUserTrashTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UserTrash");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserTrash");

            migrationBuilder.DropColumn(
                name: "District",
                table: "UserTrash");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "UserTrash");

            migrationBuilder.AddColumn<Point>(
                name: "Coordinates",
                table: "UserTrash",
                type: "geometry",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "UserTrash");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserTrash",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserTrash",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "UserTrash",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "UserTrash",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
