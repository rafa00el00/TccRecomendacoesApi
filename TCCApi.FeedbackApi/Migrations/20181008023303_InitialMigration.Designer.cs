﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using TCCApi.FeedbackApi.Dados;

namespace TCCApi.FeedbackApi.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181008023303_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("TCCApi.FeedbackApi.Models.DTO.FeedbackDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodEvento");

                    b.Property<string>("GuidUsuario");

                    b.Property<string>("Mensagem");

                    b.Property<string>("NomeUsuario");

                    b.Property<int>("Rate");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });
#pragma warning restore 612, 618
        }
    }
}