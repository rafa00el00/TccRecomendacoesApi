﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using TCCApi.VendaApi.Dados;

namespace TCCApi.VendaApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20180908013805_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("TCCApi.VendaApi.Models.DTO.CompraDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataCompra");

                    b.Property<string>("Ddd");

                    b.Property<string>("Descricao");

                    b.Property<string>("EmailComprador");

                    b.Property<string>("GuidEmpresa");

                    b.Property<string>("GuidUsuario");

                    b.Property<string>("HashComprador");

                    b.Property<string>("ItemID");

                    b.Property<string>("ModoPagamento");

                    b.Property<string>("NomeComprador");

                    b.Property<string>("NomeEmpresa");

                    b.Property<int>("Qtd");

                    b.Property<string>("Status");

                    b.Property<double>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
