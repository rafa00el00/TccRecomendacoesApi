using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCCApi.CrudApi.Models.DTO;

namespace TCCApi.CrudApi.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<EventoDTO> Eventos { get; set; }
        public DbSet<ClienteDTO> Clientes { get; set; }
        public DbSet<EmpresaDTO> Empresas { get; set; }
        public DbSet<VendaDTO> Vendas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=EventosDB");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmpresaDTO>()
           .HasIndex(p => new { p.Cnpj})
           .IsUnique(true);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClienteDTO>()
           .HasIndex(p => new { p.CPF, p.Email })
           .IsUnique(true);
        }
    }
}
