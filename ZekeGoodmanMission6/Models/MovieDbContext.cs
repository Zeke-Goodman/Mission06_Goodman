using Microsoft.EntityFrameworkCore;

namespace ZekeGoodmanMission6.Models
{
    public class MovieDbContext : DbContext
    {
        // Constructor for MovieDbContext, initializes the context with options
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base (options)
        {

        }

        // DbSet for accessing movie entities in the database
        public DbSet<insertMovie> Movies { get; set; }
    }
}
