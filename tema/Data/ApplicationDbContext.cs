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
    }
}
