using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAOGST.WIS.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingDate = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShippedControlBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingDate = table.Column<string>(type: "TEXT", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippedControlBlocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ballons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StrainGaugeNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    BallonNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ShippingDate = table.Column<string>(type: "TEXT", nullable: true),
                    ControlBlockId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ballons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ballons_ControlBlocks_ControlBlockId",
                        column: x => x.ControlBlockId,
                        principalTable: "ControlBlocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShippedBallons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StrainGaugeNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    BallonNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ShippedControlBlockId = table.Column<int>(type: "INTEGER", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippedBallons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippedBallons_ShippedControlBlocks_ShippedControlBlockId",
                        column: x => x.ShippedControlBlockId,
                        principalTable: "ShippedControlBlocks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ballons_ControlBlockId",
                table: "Ballons",
                column: "ControlBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippedBallons_ShippedControlBlockId",
                table: "ShippedBallons",
                column: "ShippedControlBlockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ballons");

            migrationBuilder.DropTable(
                name: "ShippedBallons");

            migrationBuilder.DropTable(
                name: "ControlBlocks");

            migrationBuilder.DropTable(
                name: "ShippedControlBlocks");
        }
    }
}
