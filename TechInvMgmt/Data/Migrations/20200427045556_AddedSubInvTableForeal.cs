using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Data.Migrations
{
    public partial class AddedSubInvTableForeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subinventories",
                columns: table => new
                {
                    Subinv = table.Column<string>(nullable: false),
                    AssignedTech = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subinventories", x => x.Subinv);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subinventories");
        }
    }
}
