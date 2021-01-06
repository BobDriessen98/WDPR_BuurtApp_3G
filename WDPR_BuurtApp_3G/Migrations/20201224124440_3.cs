using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR_BuurtApp_3G.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anoniem",
                table: "Melding");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Anoniem",
                table: "Melding",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
