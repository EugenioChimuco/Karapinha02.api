using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Utilizadores");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Profissionais");

            migrationBuilder.AddColumn<string>(
                name: "FotoPath",
                table: "Servicos",
                type: "nvarchar(max)",
                nullable: true);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPath",
                table: "Servicos");

            migrationBuilder.DropColumn(
                name: "EstadoCategoria",
                table: "Categorias");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Utilizadores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Profissionais",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
