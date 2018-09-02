using Microsoft.EntityFrameworkCore;
using TCCApi.EventoApi.Models.DTO;

namespace TCCApi.EventoApi.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<EventoDTO> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=EventosApiDB;SslMode=none");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
