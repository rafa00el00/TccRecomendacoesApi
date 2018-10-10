using Microsoft.EntityFrameworkCore;
using TCCApi.FeedbackApi.Models.DTO;
using TCCApi.FeedbackApi.Models.DTO;

namespace TCCApi.FeedbackApi.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<FeedbackDTO> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=FeedbackApiDB;SslMode=none");
                
                   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
