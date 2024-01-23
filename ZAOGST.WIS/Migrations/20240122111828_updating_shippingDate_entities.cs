using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAOGST.WIS.Migrations
{
    public partial class updating_shippingDate_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShippingDate",
                table: "ShippedBallons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingDate",
                table: "ShippedBallons");
        }
    }
}
