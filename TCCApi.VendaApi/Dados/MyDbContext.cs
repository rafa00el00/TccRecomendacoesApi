using Microsoft.EntityFrameworkCore;
using TCCApi.VendaApi.Models.DTO;

namespace TCCApi.VendaApi.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<CompraDTO> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=VendasApiDB;SslMode=none");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
