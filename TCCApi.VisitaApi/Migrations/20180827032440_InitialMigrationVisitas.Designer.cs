﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using TCCApi.VisitaApi.Dados;

namespace TCCApi.VisitaApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20180827032440_InitialMigrationVisitas")]
    partial class InitialMigrationVisitas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("TCCApi.VisitaApi.Models.Visita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataVisita");

                    b.Property<string>("GuidUsuario");

                    b.Property<int>("IdEvento");

                    b.HasKey("Id");

                    b.ToTable("Visitas");
                });
#pragma warning restore 612, 618
        }
    }
}
