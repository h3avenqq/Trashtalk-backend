using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace Trashtalk.Persistence.Migrations
{
    public partial class BarcodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "ReceptionPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Coordinates = table.Column<Point>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceptionPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrashBins",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashBins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    BriefDescription = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_ReceptionPoints_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "ReceptionPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrashTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Algorithm = table.Column<string>(type: "text", nullable: false),
                    TrashBinId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrashTypes_TrashBins_TrashBinId",
                        column: x => x.TrashBinId,
                        principalTable: "TrashBins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trash",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trash_TrashTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TrashTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTrash",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TrashId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    District = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTrash_Trash_TrashId",
                        column: x => x.TrashId,
                        principalTable: "Trash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_News_Id",
                table: "News",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceptionPoints_Id",
                table: "ReceptionPoints",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trash_Barcode",
                table: "Trash",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trash_Id",
                table: "Trash",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trash_TypeId",
                table: "Trash",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrashBins_Id",
                table: "TrashBins",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrashTypes_Id",
                table: "TrashTypes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrashTypes_TrashBinId",
                table: "TrashTypes",
                column: "TrashBinId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrash_Id",
                table: "UserTrash",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserTrash_TrashId",
                table: "UserTrash",
                column: "TrashId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "UserTrash");

            migrationBuilder.DropTable(
                name: "ReceptionPoints");

            migrationBuilder.DropTable(
                name: "Trash");

            migrationBuilder.DropTable(
                name: "TrashTypes");

            migrationBuilder.DropTable(
                name: "TrashBins");
        }
    }
}
