using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR_BuurtApp_3G.Migrations
{
    public partial class VotesEnAantalViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Melding",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "Melding",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "AantalViews",
                table: "Melding",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ReactieID = table.Column<int>(type: "int", nullable: false),
                    ReactieUserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    ReactieMeldingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => new { x.UserID, x.ReactieID });
                    table.ForeignKey(
                        name: "FK_Vote_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vote_Reactie_ReactieUserID_ReactieMeldingID",
                        columns: x => new { x.ReactieUserID, x.ReactieMeldingID },
                        principalTable: "Reactie",
                        principalColumns: new[] { "UserID", "MeldingID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vote_ReactieUserID_ReactieMeldingID",
                table: "Vote",
                columns: new[] { "ReactieUserID", "ReactieMeldingID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropColumn(
                name: "AantalViews",
                table: "Melding");

            migrationBuilder.AlterColumn<string>(
                name: "Titel",
                table: "Melding",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Omschrijving",
                table: "Melding",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);
        }
    }
}
