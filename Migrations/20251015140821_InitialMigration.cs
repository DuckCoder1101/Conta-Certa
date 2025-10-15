using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Conta_Certa.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Documento = table.Column<string>(type: "TEXT", maxLength: 14, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Honorario = table.Column<float>(type: "REAL", nullable: false),
                    VencimentoHonorario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Documento);
                });

            migrationBuilder.CreateTable(
                name: "Servicos",
                columns: table => new
                {
                    IdServico = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicos", x => x.IdServico);
                });

            migrationBuilder.CreateTable(
                name: "Cobrancas",
                columns: table => new
                {
                    IdCobranca = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Honorario = table.Column<float>(type: "REAL", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PagoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DocumentoCliente = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobrancas", x => x.IdCobranca);
                    table.ForeignKey(
                        name: "FK_Cobrancas_Clientes_DocumentoCliente",
                        column: x => x.DocumentoCliente,
                        principalTable: "Clientes",
                        principalColumn: "Documento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicosCobranca",
                columns: table => new
                {
                    IdServicoCobranca = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdServicoOrigem = table.Column<long>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<float>(type: "REAL", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    IdCobranca = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicosCobranca", x => x.IdServicoCobranca);
                    table.ForeignKey(
                        name: "FK_ServicosCobranca_Cobrancas_IdCobranca",
                        column: x => x.IdCobranca,
                        principalTable: "Cobrancas",
                        principalColumn: "IdCobranca",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicosCobranca_Servicos_IdServicoOrigem",
                        column: x => x.IdServicoOrigem,
                        principalTable: "Servicos",
                        principalColumn: "IdServico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_DocumentoCliente",
                table: "Cobrancas",
                column: "DocumentoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Cobrancas_Vencimento_DocumentoCliente",
                table: "Cobrancas",
                columns: new[] { "Vencimento", "DocumentoCliente" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Servicos_Nome",
                table: "Servicos",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicosCobranca_IdCobranca_IdServicoOrigem",
                table: "ServicosCobranca",
                columns: new[] { "IdCobranca", "IdServicoOrigem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServicosCobranca_IdServicoOrigem",
                table: "ServicosCobranca",
                column: "IdServicoOrigem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServicosCobranca");

            migrationBuilder.DropTable(
                name: "Cobrancas");

            migrationBuilder.DropTable(
                name: "Servicos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
