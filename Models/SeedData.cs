using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace hearthStoneDeckBuilder.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HSContext(
                serviceProvider.GetRequiredService<DbContextOptions<HSContext>>()))
            {
                // Look for any movies.
                if (context.Deck.Any())
                {
                    return;   // DB has been seeded
                }

                context.Deck.AddRange(
                     new Deck("druid test", "moi", ClassType.Druid),
                     new Deck("Mage test", "moi", ClassType.Mage),
                     new Deck("rogue test", "moi", ClassType.Rogue)
                );
                context.SaveChanges();
            }
        }
    }
}