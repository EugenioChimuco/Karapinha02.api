using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class actualizacaoBD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarcacaoServicos",
                columns: table => new
                {
                    IdMArcacoaServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    IdMarcacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoServicos", x => x.IdMArcacoaServico);
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Marcacoes_IdMarcacao",
                        column: x => x.IdMarcacao,
                        principalTable: "Marcacoes",
                        principalColumn: "IdMarcacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_IdMarcacao",
                table: "MarcacaoServicos",
                column: "IdMarcacao");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_IdServico",
                table: "MarcacaoServicos",
                column: "IdServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoServicos");
        }
    }
}
