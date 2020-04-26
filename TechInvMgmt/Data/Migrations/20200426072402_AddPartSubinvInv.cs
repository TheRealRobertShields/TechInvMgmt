using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Data.Migrations
{
    public partial class AddPartSubinvInv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    Number = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Serial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Subinventories",
                columns: table => new
                {
                    SubInv = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subinventories", x => x.SubInv);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(nullable: true),
                    SubInv = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.RowId);
                    table.ForeignKey(
                        name: "FK_Inventory_Parts_PartNumber",
                        column: x => x.PartNumber,
                        principalTable: "Parts",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventory_Subinventories_SubInv",
                        column: x => x.SubInv,
                        principalTable: "Subinventories",
                        principalColumn: "SubInv",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_PartNumber",
                table: "Inventory",
                column: "PartNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_SubInv",
                table: "Inventory",
                column: "SubInv");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Subinventories");
        }
    }
}
