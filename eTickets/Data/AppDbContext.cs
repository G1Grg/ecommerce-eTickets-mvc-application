using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext:DbContext
    {   
        //Acts as a translator between models and SQL Server
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
               //am ==> actor movie
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId
            });

            //m ==>movie
            // HasOne(m=>m.movie) means 1 movie has relation with many actor_Movies with foreign key m.MovieId in model Actor_movie
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);

            //to generate default authenticator
            base.OnModelCreating (modelBuilder);
        }

        // Define model for each model 
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies{ get; set; }
        public DbSet<Cinema> Cinemas{ get; set; }
        public DbSet<Producer> Producers { get; set; }
    }
}
