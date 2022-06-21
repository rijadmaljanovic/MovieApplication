using Microsoft.EntityFrameworkCore;
using MovieApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApplication.Infrastructure
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<MovieRating>().HasKey(x => new { x.MovieId, x.UserId });

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.MovieId, x.ActorId });

            //modelBuilder.Entity<MovieActor>()
            //    .HasKey(bc => new { bc.ActorId, bc.MovieId });
            //modelBuilder.Entity<MovieActor>()
            //    .HasOne(bc => bc.Movie)
            //    .WithMany(b => b.Actors)
            //    .HasForeignKey(bc => bc.MovieId);
            //modelBuilder.Entity<MovieActor>()
            //    .HasOne(bc => bc.Actor)
            //    .WithMany(c => c.Movies)
            //    .HasForeignKey(bc => bc.ActorId);

            //modelBuilder.Entity<Movie>()
            //    .HasMany<Actor>(s => s.Actors)
            //    .WithMany(c => c.Movies);
        }
    }
}
