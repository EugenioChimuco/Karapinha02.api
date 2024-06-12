using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Servicos_IdServico",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_IdServico",
                table: "Profissionais");

            migrationBuilder.DropColumn(
                name: "IdProfissional",
                table: "Servicos");

            migrationBuilder.RenameColumn(
                name: "IdServico",
                table: "Profissionais",
                newName: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_IdCategoria",
                table: "Profissionais",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Categorias_IdCategoria",
                table: "Profissionais",
                column: "IdCategoria",
                principalTable: "Categorias",
                principalColumn: "IdCategoria",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissionais_Categorias_IdCategoria",
                table: "Profissionais");

            migrationBuilder.DropIndex(
                name: "IX_Profissionais_IdCategoria",
                table: "Profissionais");

            migrationBuilder.RenameColumn(
                name: "IdCategoria",
                table: "Profissionais",
                newName: "IdServico");

            migrationBuilder.AddColumn<int>(
                name: "IdProfissional",
                table: "Servicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_IdServico",
                table: "Profissionais",
                column: "IdServico",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profissionais_Servicos_IdServico",
                table: "Profissionais",
                column: "IdServico",
                principalTable: "Servicos",
                principalColumn: "IdServico",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
