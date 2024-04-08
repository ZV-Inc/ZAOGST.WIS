using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAOGST.WIS.Migrations
{
    public partial class update_shippedControlBlock_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSended",
                table: "ShippedControlBlocks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSended",
                table: "ShippedControlBlocks");
        }
    }
}
