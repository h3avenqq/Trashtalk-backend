using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trashtalk.Persistence.Migrations
{
    public partial class BarcodeMaxLength256 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Trash",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(258)",
                oldMaxLength: 258);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Barcode",
                table: "Trash",
                type: "character varying(258)",
                maxLength: 258,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);
        }
    }
}
