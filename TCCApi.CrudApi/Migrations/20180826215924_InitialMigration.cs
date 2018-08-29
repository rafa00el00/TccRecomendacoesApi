using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCCApi.CrudApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Guid = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Cnpj = table.Column<string>(maxLength: 40, nullable: true),
                    NomeFantasia = table.Column<string>(nullable: true),
                    RazaoSocial = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Bairro = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    ClienteDTOId = table.Column<int>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizacao_Clientes_ClienteDTOId",
                        column: x => x.ClienteDTOId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataAtualizacao = table.Column<DateTime>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataEvento = table.Column<DateTime>(nullable: false),
                    DataFimInscricao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DescricaoSimples = table.Column<string>(nullable: true),
                    IdEmpresa = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PublicoAlvo = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Empresas_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventoTagDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    EventoDTOId = table.Column<int>(nullable: true),
                    TagName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoTagDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoTagDTO_Eventos_EventoDTOId",
                        column: x => x.EventoDTOId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FotoEventoDto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CaminhoFoto = table.Column<string>(nullable: true),
                    IdEvento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoEventoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotoEventoDto_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalizacaoDTO",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Bairro = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    EventoDTOId = table.Column<int>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizacaoDTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalizacaoDTO_Eventos_EventoDTOId",
                        column: x => x.EventoDTOId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CodigoRegerencia = table.Column<string>(nullable: true),
                    CodigoTransacao = table.Column<string>(nullable: true),
                    DataCancelamento = table.Column<DateTime>(nullable: false),
                    DataVenda = table.Column<DateTime>(nullable: false),
                    IdCLiente = table.Column<int>(nullable: true),
                    IdEvento = table.Column<int>(nullable: true),
                    StatusVenda = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_IdCLiente",
                        column: x => x.IdCLiente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vendas_Eventos_IdEvento",
                        column: x => x.IdEvento,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CPF_Email",
                table: "Clientes",
                columns: new[] { "CPF", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Cnpj",
                table: "Empresas",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_IdEmpresa",
                table: "Eventos",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EventoTagDTO_EventoDTOId",
                table: "EventoTagDTO",
                column: "EventoDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_FotoEventoDto_IdEvento",
                table: "FotoEventoDto",
                column: "IdEvento");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacao_ClienteDTOId",
                table: "Localizacao",
                column: "ClienteDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalizacaoDTO_EventoDTOId",
                table: "LocalizacaoDTO",
                column: "EventoDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdCLiente",
                table: "Vendas",
                column: "IdCLiente");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_IdEvento",
                table: "Vendas",
                column: "IdEvento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoTagDTO");

            migrationBuilder.DropTable(
                name: "FotoEventoDto");

            migrationBuilder.DropTable(
                name: "Localizacao");

            migrationBuilder.DropTable(
                name: "LocalizacaoDTO");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
