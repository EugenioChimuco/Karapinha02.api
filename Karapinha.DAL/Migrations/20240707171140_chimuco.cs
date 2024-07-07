using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Karapinha.DAL.Migrations
{
    /// <inheritdoc />
    public partial class chimuco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCategoria = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hora = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.IdHorario);
                });

            migrationBuilder.CreateTable(
                name: "Utilizadores",
                columns: table => new
                {
                    IdUtilizador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDeUser = table.Column<int>(type: "int", nullable: false),
                    EstadoDoUtilizador = table.Column<bool>(type: "bit", nullable: false),
                    EstadoDaConta = table.Column<bool>(type: "bit", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizadores", x => x.IdUtilizador);
                });

            migrationBuilder.CreateTable(
                name: "Profissionais",
                columns: table => new
                {
                    IdProfissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionais", x => x.IdProfissional);
                    table.ForeignKey(
                        name: "FK_Profissionais_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDeServico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoDoServico = table.Column<float>(type: "real", nullable: false),
                    FotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_Servicos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marcacoes",
                columns: table => new
                {
                    IdMarcacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDeMarcacao = table.Column<DateOnly>(type: "date", nullable: false),
                    PrecoDaMarcacao = table.Column<float>(type: "real", nullable: false),
                    EstadoDeMarcacao = table.Column<bool>(type: "bit", nullable: false),
                    IdUtilizador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcacoes", x => x.IdMarcacao);
                    table.ForeignKey(
                        name: "FK_Marcacoes_Utilizadores_IdUtilizador",
                        column: x => x.IdUtilizador,
                        principalTable: "Utilizadores",
                        principalColumn: "IdUtilizador");
                });

            migrationBuilder.CreateTable(
                name: "HorarioFuncionarios",
                columns: table => new
                {
                    IdHorarioFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFuncionarios", x => x.IdHorarioFuncionario);
                    table.ForeignKey(
                        name: "FK_HorarioFuncionarios_Horarios_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorarioFuncionarios_Profissionais_IdProfissional",
                        column: x => x.IdProfissional,
                        principalTable: "Profissionais",
                        principalColumn: "IdProfissional",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcacaoServicos",
                columns: table => new
                {
                    IdMarcacaoServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdServico = table.Column<int>(type: "int", nullable: false),
                    IdProfissional = table.Column<int>(type: "int", nullable: false),
                    DataMarcacao = table.Column<DateOnly>(type: "date", nullable: false),
                    IdHorario = table.Column<int>(type: "int", nullable: false),
                    MarcacaoIdMarcacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoServicos", x => x.IdMarcacaoServico);
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Horarios_IdHorario",
                        column: x => x.IdHorario,
                        principalTable: "Horarios",
                        principalColumn: "IdHorario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Marcacoes_MarcacaoIdMarcacao",
                        column: x => x.MarcacaoIdMarcacao,
                        principalTable: "Marcacoes",
                        principalColumn: "IdMarcacao");
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Profissionais_IdProfissional",
                        column: x => x.IdProfissional,
                        principalTable: "Profissionais",
                        principalColumn: "IdProfissional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoServicos_Servicos_IdServico",
                        column: x => x.IdServico,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionarios_IdHorario",
                table: "HorarioFuncionarios",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionarios_IdProfissional",
                table: "HorarioFuncionarios",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_IdHorario",
                table: "MarcacaoServicos",
                column: "IdHorario");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_IdProfissional",
                table: "MarcacaoServicos",
                column: "IdProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_IdServico",
                table: "MarcacaoServicos",
                column: "IdServico");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoServicos_MarcacaoIdMarcacao",
                table: "MarcacaoServicos",
                column: "MarcacaoIdMarcacao");

            migrationBuilder.CreateIndex(
                name: "IX_Marcacoes_IdUtilizador",
                table: "Marcacoes",
                column: "IdUtilizador");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionais_IdCategoria",
                table: "Profissionais",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_IdCategoria",
                table: "Servicos",
                column: "IdCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioFuncionarios");

            migrationBuilder.DropTable(
                name: "MarcacaoServicos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Marcacoes");

            migrationBuilder.DropTable(
                name: "Profissionais");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Utilizadores");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
