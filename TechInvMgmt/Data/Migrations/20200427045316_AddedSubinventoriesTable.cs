using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Data.Migrations
{
    public partial class AddedSubinventoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Inventory",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Inventory");
        }
    }
}
