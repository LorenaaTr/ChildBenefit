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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Relation> Relations { get; set; }

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
