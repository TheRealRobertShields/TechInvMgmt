using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Data.Migrations
{
    public partial class FixedInventoryClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Parts_PartNumber",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Subinventories_SubInv",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Subinventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_PartNumber",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_SubInv",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "SubInv",
                table: "Inventory");

            migrationBuilder.AlterColumn<string>(
                name: "PartNumber",
                table: "Inventory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartName",
                table: "Inventory",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subinventory",
                table: "Inventory",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartName",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Subinventory",
                table: "Inventory");

            migrationBuilder.AlterColumn<string>(
                name: "PartNumber",
                table: "Inventory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubInv",
                table: "Inventory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subinventories",
                columns: table => new
                {
                    SubInv = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subinventories", x => x.SubInv);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PartNumber",
                table: "Inventory",
                column: "PartNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SubInv",
                table: "Inventory",
                column: "SubInv");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Parts_PartNumber",
                table: "Inventory",
                column: "PartNumber",
                principalTable: "Parts",
                principalColumn: "Number",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Subinventories_SubInv",
                table: "Inventory",
                column: "SubInv",
                principalTable: "Subinventories",
                principalColumn: "SubInv",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
