using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZAOGST.WIS.Migrations
{
    public partial class update_user_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "Token");
        }
    }
}
