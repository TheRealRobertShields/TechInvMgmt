using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInvMgmt.Migrations
{
    public partial class Migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "AspNetUsers");
        }
    }
}
