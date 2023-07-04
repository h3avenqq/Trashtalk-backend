using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trashtalk.Persistence.Migrations
{
    public partial class BarcodeMaxLength258 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Trash",
                type: "character varying(258)",
                maxLength: 258,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "character varying(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Trash",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(258)",
                oldMaxLength: 258);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "News",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(128)",
                oldMaxLength: 128);
        }
    }
}
