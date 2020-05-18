using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Inventory_InventoryRowId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_InventoryRowId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "InventoryRowId",
                table: "SerialNumbers");

            migrationBuilder.CreateTable(
                name: "Subinventories",
                columns: table => new
                {
                    Subinv = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subinventories", x => x.Subinv);
                    table.ForeignKey(
                        name: "FK_Subinventories_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subinventories_EmployeeId",
                table: "Subinventories",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subinventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryRowId",
                table: "SerialNumbers",
                type: "int",
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
    }
}
