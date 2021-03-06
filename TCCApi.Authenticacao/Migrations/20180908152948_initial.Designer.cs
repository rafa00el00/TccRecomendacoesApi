﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;
using TCCApi.Authenticacao.Dados;

namespace TCCApi.Authenticacao.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20180908152948_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UsersClaims");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUserClaim<int>");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.DTO.ClienteTagDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TagName");

                    b.Property<int?>("UsuarioDTOId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioDTOId");

                    b.ToTable("ClienteTagDTO");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.DTO.EmpresaDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cnpj");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Organizador");

                    b.Property<string>("RazaoSocial");

                    b.Property<string>("TelefoneContato");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.DTO.UsuarioDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Celular");

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Descricao");

                    b.Property<string>("Email");

                    b.Property<string>("Guid");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.MyClaim", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>");

                    b.Property<int?>("ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("MyClaim");

                    b.HasDiscriminator().HasValue("MyClaim");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.DTO.ClienteTagDTO", b =>
                {
                    b.HasOne("TCCApi.Authenticacao.Models.DTO.UsuarioDTO")
                        .WithMany("Tags")
                        .HasForeignKey("UsuarioDTOId");
                });

            modelBuilder.Entity("TCCApi.Authenticacao.Models.MyClaim", b =>
                {
                    b.HasOne("TCCApi.Authenticacao.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
