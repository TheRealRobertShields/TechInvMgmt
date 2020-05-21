using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Migrations
{
    public partial class Migration004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomInventoryId",
                table: "SerialNumbers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventoryRowId",
                table: "SerialNumbers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_InventoryRowId",
                table: "SerialNumbers",
                column: "InventoryRowId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Inventory_InventoryRowId",
                table: "SerialNumbers",
                column: "InventoryRowId",
                principalTable: "Inventory",
                principalColumn: "RowId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Inventory_InventoryRowId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_InventoryRowId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "CustomInventoryId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "InventoryRowId",
                table: "SerialNumbers");
        }
    }
}
