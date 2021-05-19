using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initialç : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Raca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaesDono",
                columns: table => new
                {
                    CaesId = table.Column<int>(nullable: false),
                    DonosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaesDono", x => new { x.DonosId, x.CaesId });
                    table.ForeignKey(
                        name: "FK_CaesDono_Caes_CaesId",
                        column: x => x.CaesId,
                        principalTable: "Caes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CaesDono_Donos_DonosId",
                        column: x => x.DonosId,
                        principalTable: "Donos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaesDono_CaesId",
                table: "CaesDono",
                column: "CaesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaesDono");

            migrationBuilder.DropTable(
                name: "Caes");

            migrationBuilder.DropTable(
                name: "Donos");
        }
    }
}
