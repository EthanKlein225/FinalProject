using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCollection>().HasKey(s => new {s.CollectionId, s.GameId});
        }

        public DbSet<Collection> Collection {get; set;} = default!;
        public DbSet<Game> Game {get; set;} = default!; 
        public DbSet<GameCollection> GameCollection {get; set;} = default!;
    }
}