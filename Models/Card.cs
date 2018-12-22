using Newtonsoft.Json;

namespace hearthStoneDeckBuilder.Models
{
    public class Card
    {
        [JsonIgnore]
        public int ID{get; private set;}
        public string LinkPicture {get; set;}
        public ClassType CardClass { get; private set; }
        public CardRarity Rarity { get; private set; }
        public CardType Type {get; private set;}
        public string Text { get; private set; }
        public int Cost { get; private set; }
        public string Name { get; private set; }
        public int deckID {get; set;}
        public Card(string name, ClassType cardClass, CardRarity rarity, string text, int cost, CardType type)
        {
            CardClass = cardClass;
            Rarity = rarity;
            Text = text;
            Cost = cost;
            Name = name;
            Type = type;
        }

        public string toString()
        {
            return Name + " - " + CardClass + " - " + Rarity + " - " + Cost + " - " + Text;
        }
    }
}