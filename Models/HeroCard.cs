namespace hearthStoneDeckBuilder.Models
{
    using System;
    using System.Collections.Generic;
    public sealed class HeroCard : Card
    {
        public int Armor { get; private set; }

        public HeroCard(string name, ClassType cardClass, CardRarity rarity, string text, int cost, int armor, CardType type)
        : base(name, cardClass, rarity, text, cost, type)
        {
            Armor = armor;
        }
    }
}