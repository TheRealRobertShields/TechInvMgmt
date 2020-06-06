using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Migrations
{
    public partial class Mig002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SubinventoryId",
                table: "SerialNumbers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PartId",
                table: "SerialNumbers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SubinventoryId",
                table: "SerialNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "PartId",
                table: "SerialNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
