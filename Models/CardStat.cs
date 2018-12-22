namespace hearthStoneDeckBuilder.Models
{
    public class CardStat
    {
        public string Name {get; set;}
        public int Count {get; set;}

        public CardStat(string name, int count){
            Name = name;
            Count = count;
        }
    }
}