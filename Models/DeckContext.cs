namespace hearthStoneDeckBuilder.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    public class HSContext : DbContext
    {
        public HSContext (DbContextOptions<HSContext> options)
            : base(options)
        {
        }

        public DbSet<hearthStoneDeckBuilder.Models.Deck> Deck { get; set; }
        public DbSet<hearthStoneDeckBuilder.Models.Card> Card { get; set; }

    }
}