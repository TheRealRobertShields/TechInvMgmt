using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Data.Migrations
{
    public partial class FixSerializedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Serial",
                table: "Parts");

            migrationBuilder.AddColumn<bool>(
                name: "IsSerialized",
                table: "Parts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "Inventory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSerialized",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Serial",
                table: "Parts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
