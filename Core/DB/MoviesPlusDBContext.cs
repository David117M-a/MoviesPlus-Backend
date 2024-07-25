using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DB
{
    public class MoviesPlusDBContext : DbContext
    {
        public MoviesPlusDBContext(DbContextOptions<MoviesPlusDBContext> options) : base(options)
        {
        }

        DbSet<Actor> Actors { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<ActorMovie> ActorMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Actor).WithMany(a => a.Movies)
                    .HasForeignKey(e => e.ActorId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Movie).WithMany(m => m.Actors)
                    .HasForeignKey(e => e.MovieId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Genre).WithMany(a => a.Movies)
                    .HasForeignKey(e => e.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasMany(e => e.Movies).WithOne(a => a.Genre)
                    .HasForeignKey(e => e.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
