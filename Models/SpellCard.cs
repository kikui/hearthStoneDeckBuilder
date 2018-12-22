namespace hearthStoneDeckBuilder.Models
{
    using System;
    using System.Collections.Generic;
    public sealed class SpellCard : Card
    {
        public SpellCard(string name, ClassType cardType, CardRarity rarity, string text, int cost, CardType type)
        : base(name, cardType, rarity, text, cost, type)
        {

        }
    }
}