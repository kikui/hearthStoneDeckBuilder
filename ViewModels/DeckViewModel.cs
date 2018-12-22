using System.Collections.Generic;
using hearthStoneDeckBuilder.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace hearthStoneDeckBuilder.ViewModels
{
    public class DeckViewModel
    {
        public List<Deck> Decks;
        public SelectList ClassType;
        public string DeckClassType { get; set; }
        public string SearchTitleDeck { get; set; }
        public string SearchAuthorDeck { get; set; }
    }
}