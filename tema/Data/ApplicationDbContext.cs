using Microsoft.EntityFrameworkCore;
using tema.Models;

namespace tema.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Gender> Genders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, AlDescription = "Femer", EnDescription = "Female", SrDescription ="Zensko"},
                new Gender { Id = 2, AlDescription = "Mashkull", EnDescription = "Male", SrDescription ="Muski"},
                new Gender { Id = 3, AlDescription = "Te tjera", EnDescription = "Others", SrDescription ="Drugi"}
                );
        }
    }
}
