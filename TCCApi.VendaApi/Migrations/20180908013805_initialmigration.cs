using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCCApi.VendaApi.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Celular = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataCompra = table.Column<DateTime>(nullable: false),
                    Ddd = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    EmailComprador = table.Column<string>(nullable: true),
                    GuidEmpresa = table.Column<string>(nullable: true),
                    GuidUsuario = table.Column<string>(nullable: true),
                    HashComprador = table.Column<string>(nullable: true),
                    ItemID = table.Column<string>(nullable: true),
                    ModoPagamento = table.Column<string>(nullable: true),
                    NomeComprador = table.Column<string>(nullable: true),
                    NomeEmpresa = table.Column<string>(nullable: true),
                    Qtd = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
