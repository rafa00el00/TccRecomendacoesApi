using Microsoft.EntityFrameworkCore;
using TCCApi.Authenticacao.Models;

namespace TCCApi.Authenticacao.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<Usuario> Eventos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=AuthApiDB;SslMode=none");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
