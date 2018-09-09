using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TCCApi.Authenticacao.Models;
using TCCApi.Authenticacao.Models.DTO;

namespace TCCApi.Authenticacao.Dados
{
    public class MyDbContext : DbContext
    {
        public DbSet<UsuarioDTO> Usuarios { get; set; }
        public DbSet<EmpresaDTO> Empresas { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<IdentityUserClaim<int>> UsersClaims { get; set; }
        public DbSet<IdentityRole<int>> Roles { get; set; }
        public DbSet<IdentityUserRole<int>> UserRoles { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=;Database=AuthApiDB;SslMode=none");

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
        }
    }
}
