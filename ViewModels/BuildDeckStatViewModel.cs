using System.Collections.Generic;
using hearthStoneDeckBuilder.Models;

namespace hearthStoneDeckBuilder.ViewModels
{
    public class BuildDeckStatViewModel
    {
        public CardStat CardStat{get;set;}

        public List<Card> Cards{get;set;}
    }
}