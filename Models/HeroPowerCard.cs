namespace hearthStoneDeckBuilder.Models
{
    public sealed class HeroPowerCard : Card
    {
        public HeroPowerCard(string name, ClassType cardType, CardRarity rarity, string text, int cost, CardType type)
        : base(name, cardType, rarity, text, cost, type)
        {
            
        }
    }
}