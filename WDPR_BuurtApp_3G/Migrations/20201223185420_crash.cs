using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WDPR_BuurtApp_3G.Migrations
{
    public partial class crash : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieID);
                });

            migrationBuilder.CreateTable(
                name: "Melding",
                columns: table => new
                {
                    MeldingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: true),
                    Titel = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Anoniem = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Omschrijving = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CategorieID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Foto = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Gesloten = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Melding", x => x.MeldingID);
                    table.ForeignKey(
                        name: "FK_Melding_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Melding_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "CategorieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    MeldingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => new { x.UserID, x.MeldingID });
                    table.ForeignKey(
                        name: "FK_Like_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Like_Melding_MeldingID",
                        column: x => x.MeldingID,
                        principalTable: "Melding",
                        principalColumn: "MeldingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactie",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    MeldingID = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reactietekst = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactie", x => new { x.UserID, x.MeldingID });
                    table.ForeignKey(
                        name: "FK_Reactie_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactie_Melding_MeldingID",
                        column: x => x.MeldingID,
                        principalTable: "Melding",
                        principalColumn: "MeldingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "varchar(255) CHARACTER SET utf8mb4", nullable: false),
                    MeldingID = table.Column<int>(type: "int", nullable: false),
                    Omschrijving = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => new { x.UserID, x.MeldingID });
                    table.ForeignKey(
                        name: "FK_Report_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Report_Melding_MeldingID",
                        column: x => x.MeldingID,
                        principalTable: "Melding",
                        principalColumn: "MeldingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_MeldingID",
                table: "Like",
                column: "MeldingID");

            migrationBuilder.CreateIndex(
                name: "IX_Melding_CategorieID",
                table: "Melding",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_Melding_UserID",
                table: "Melding",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reactie_MeldingID",
                table: "Reactie",
                column: "MeldingID");

            migrationBuilder.CreateIndex(
                name: "IX_Report_MeldingID",
                table: "Report",
                column: "MeldingID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "Reactie");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Melding");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropColumn(
                name: "Adres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "AspNetUsers");
        }
    }
}
