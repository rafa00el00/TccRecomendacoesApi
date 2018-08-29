using Microsoft.EntityFrameworkCore;
using TCCApi.VisitaApi.Models;

namespace TCCApi.VisitaApi.Dados
{
    public class MyDbContext : DbContext
    {

        public DbSet<Visita> Visitas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=VisitasDB;");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
