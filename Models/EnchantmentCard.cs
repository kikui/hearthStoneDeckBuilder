namespace hearthStoneDeckBuilder.Models
{
    public class EnchantmentCard : Card
    {
        public EnchantmentCard(string name, ClassType cardType, CardRarity rarity, string text, int cost, CardType type)
        : base(name, cardType, rarity, text, cost, type)
        {
            
        }
    }
}