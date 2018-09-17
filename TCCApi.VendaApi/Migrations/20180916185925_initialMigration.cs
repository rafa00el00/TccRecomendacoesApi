using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCCApi.VendaApi.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PagamentoDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Cartao = table.Column<string>(nullable: true),
                    Cvv = table.Column<string>(nullable: true),
                    NomeTitular = table.Column<string>(nullable: true),
                    Vencimento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Celular = table.Column<string>(nullable: true),
                    CodStatus = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    Ddd = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DescricaoStatus = table.Column<string>(nullable: true),
                    EmailComprador = table.Column<string>(nullable: true),
                    GuidCompra = table.Column<string>(nullable: true),
                    GuidEmpresa = table.Column<string>(nullable: true),
                    GuidUsuario = table.Column<string>(nullable: true),
                    ItemID = table.Column<string>(nullable: true),
                    NomeComprador = table.Column<string>(nullable: true),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    PagamentoId = table.Column<int>(nullable: true),
                    Qtd = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_PagamentoDto_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "PagamentoDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_PagamentoId",
                table: "Compras",
                column: "PagamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "PagamentoDto");
        }
    }
}
