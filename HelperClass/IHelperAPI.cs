using System.Collections.Generic;
using System.Threading.Tasks;
using hearthStoneDeckBuilder.Models;
using hearthStoneDeckBuilder.ViewModels;
using Newtonsoft.Json.Linq;

namespace hearthStoneDeckBuilder.HelperClass
{
    public interface IHelperAPI
    {
        Task<BuildDeckViewModel> getCards(List<string> type);
        Task<BuildDeckViewModel> getAllCards();
        Task<List<Card>> getCardsByID(string[] namesList);
        Task<List<Card>> getPresetDeck(PresetDeckEnum deckShape);
    }
}