using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class actualizacaoBD3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servicos_Marcacoes_MarcacaoIdMarcacao",
                table: "Servicos");

            migrationBuilder.DropIndex(
                name: "IX_Servicos_MarcacaoIdMarcacao",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "MarcacaoIdMarcacao",
                table: "Servicos");

            migrationBuilder.AddColumn<float>(
                name: "PrecoDaMarcacao",
                table: "Marcacoes",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoDaMarcacao",
                table: "Marcacoes");

            migrationBuilder.AddColumn<int>(
                name: "MarcacaoIdMarcacao",
                table: "Servicos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_MarcacaoIdMarcacao",
                table: "Servicos",
                column: "MarcacaoIdMarcacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Servicos_Marcacoes_MarcacaoIdMarcacao",
                table: "Servicos",
                column: "MarcacaoIdMarcacao",
                principalTable: "Marcacoes",
                principalColumn: "IdMarcacao");
        }
    }
}
