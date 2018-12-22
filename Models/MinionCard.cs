namespace hearthStoneDeckBuilder.Models
{
    using System;
    using System.Collections.Generic;
    public sealed class MinionCard : Card
    {
        public int Health { get; private set; }
        public int Attack { get; private set; }

        public MinionCard(string name, ClassType cardClass, CardRarity rarity, string text, int cost, int health, int attack, CardType type)
        : base(name, cardClass, rarity, text, cost, type)
        {
            Health = health;
            Attack = attack;
        }
    }
}