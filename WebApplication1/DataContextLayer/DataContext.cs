using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebApplication1.Models;

namespace WebApplication1.DataContextLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorMovie> ActorMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>().HasKey(am => new { am.MovieId, am.ActorId });

            modelBuilder.Entity<Actor>()
                .HasMany(e => e.Movies)
                .WithMany(e => e.Actors)
                .UsingEntity<ActorMovie>();
        }
    }
}
