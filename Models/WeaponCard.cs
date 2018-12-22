namespace hearthStoneDeckBuilder.Models
{
    using System;
    using System.Collections.Generic;
    public sealed class WeaponCard : Card
    {
        public int Durability { get; private set; }

        public WeaponCard(string name, ClassType cardType, CardRarity rarity, string text, int cost, int durability, CardType type)
        : base(name, cardType, rarity, text, cost, type)
        {
            Durability = durability;
        }
    }
}