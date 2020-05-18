using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class GameStoreContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>().HasKey(k => new { k.Id });
            builder.Entity<Game>().Property(p => p.Name).IsRequired();
            builder.Entity<Game>().Property(p => p.Description).IsRequired();
            builder.Entity<Game>().Property(p => p.Price).IsRequired();

            builder.Entity<Genre>().HasKey(k => new { k.Id });
            builder.Entity<Genre>().Property(p => p.Title).IsRequired();

            builder.Entity<GameGenre>().HasKey(k => new { k.GameId, k.GenreId });

            base.OnModelCreating(builder);
        }
    }
}