using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectNewApi.Migrations
{
    /// <inheritdoc />
    public partial class studios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "lokacije",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opcina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mjesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostanskiBroj = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lokacije", x => x.LokacijaId);
                });

            migrationBuilder.CreateTable(
                name: "studios",
                columns: table => new
                {
                    StudioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LokacijaId = table.Column<int>(type: "int", nullable: true),
                    VlasnikId = table.Column<int>(type: "int", nullable: false),
                    StudioImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studios", x => x.StudioId);
                    table.ForeignKey(
                        name: "FK_studios_lokacije_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "lokacije",
                        principalColumn: "LokacijaId");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_studios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "studios",
                        principalColumn: "StudioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_studios_LokacijaId",
                table: "studios",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_users_StudioId",
                table: "users",
                column: "StudioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "studios");

            migrationBuilder.DropTable(
                name: "lokacije");
        }
    }
}
