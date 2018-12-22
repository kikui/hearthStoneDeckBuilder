using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hearthStoneDeckBuilder.Models;
using hearthStoneDeckBuilder.ViewModels;
using hearthStoneDeckBuilder.HelperClass;

namespace hearthStoneDeckBuilder.Controllers
{
    public class DeckController : Controller
    {
        private readonly HSContext _context;

        private readonly IHelperAPI _ihelperApi;

        public DeckController(HSContext contextDeck, IHelperAPI ihelperAPi)
        {
            _context = contextDeck;
            _ihelperApi = ihelperAPi;
        }

        // GET: Deck
        public async Task<IActionResult> Index(string deckClassType, string searchTitleDeck, string searchAuthorDeck)
        {
            IQueryable<ClassType> classTypeQuery = from d in _context.Deck orderby d.ClassType select d.ClassType;
            var decks = from d in _context.Deck select d;

            if (!String.IsNullOrEmpty(searchTitleDeck))
            {
                decks = decks.Where(s => s.Title.Contains(searchTitleDeck));
            }

            if (!String.IsNullOrEmpty(searchAuthorDeck))
            {
                decks = decks.Where(s => s.Author.Contains(searchAuthorDeck));
            }

            if (!String.IsNullOrEmpty(deckClassType))
            {
                ClassType classConvert = (ClassType)Enum.Parse(typeof(ClassType), deckClassType);
                decks = decks.Where(x => x.ClassType == classConvert);
            }

            var deckClassTypeVM = new DeckViewModel();
            deckClassTypeVM.ClassType = new SelectList(await classTypeQuery.Distinct().ToListAsync());
            deckClassTypeVM.Decks = await decks.ToListAsync();
            deckClassTypeVM.SearchTitleDeck = searchTitleDeck;
            deckClassTypeVM.SearchAuthorDeck = searchAuthorDeck;

            return View(deckClassTypeVM);
        }

        // GET: Deck/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cards = from d in _context.Card select d;
            cards = cards.Where(x => x.deckID == id);
            await cards.ToArrayAsync();

            var deck = await _context.Deck
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // GET: Deck/Create
        public IActionResult Create(string message)
        {
            ViewBag.message = message;
            return View();
        }

        // POST: Deck/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string author, string title, string presetDeckString, ClassType classType)
        {
            List<Card> checkList;
            List<ClassType> classTypeNumber = new List<ClassType>();
            Console.WriteLine(presetDeckString);
            PresetDeckEnum presetDeck = (PresetDeckEnum)Enum.Parse(typeof(PresetDeckEnum), presetDeckString);

            if (ModelState.IsValid)
            {
                int countHero = 0;
                Boolean validDeckNumber = true;
                Boolean validDeckHereoNumber = true;
                Boolean validDeckCardDuplicate = true;
                Boolean validClassDeck = true;
                Boolean validLegendaryNumber = true;
                checkList = _ihelperApi.getPresetDeck(presetDeck).Result;

                //verifier les decks de 30 cartes
                if (checkList.Count != 30) validDeckNumber = false;

                foreach (var item in checkList)
                {
                    //verifier max 1 hero
                    if (item.Type == CardType.HERO) countHero++;
                    if (countHero >= 2) validDeckHereoNumber = false;
                    //vérification de triplon
                    if (CountCard(item.Name, "name") > 2) validDeckCardDuplicate = false;
                    //verifier bien 2 class type max
                    if (CountClassType(item.CardClass) == false) validClassDeck = false;
                    //verification du nombre de legendaire
                    if (CountCard(item.Rarity.ToString(), "rarity") > 1) validLegendaryNumber = false;
                }

                if (validDeckCardDuplicate == true && validDeckHereoNumber == true && validDeckNumber == true && validClassDeck == true && validLegendaryNumber == true)
                {
                    Deck deck = new Deck(title, author, classType);
                    deck.List = checkList;
                    _context.Add(deck);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    Console.WriteLine("validDeckCardDuplicate: " + validDeckCardDuplicate + ", validDeckHereoNumber: " + validDeckHereoNumber + "/" + countHero + ", validDeckNumber: " + validDeckNumber + "/" + checkList.Count + ", validClassDeck: " + validClassDeck + "/" + classTypeNumber.Count + ", validLegendaryNumber: " + validLegendaryNumber);
                    //renvoyer la liste des erreurs
                    var message = "validDeckCardDuplicate: " + validDeckCardDuplicate + ", validDeckHereoNumber: " + validDeckHereoNumber + "/" + countHero + ", validDeckNumber: " + validDeckNumber + "/" + checkList.Count + ", validClassDeck: " + validClassDeck + "/" + classTypeNumber.Count + ", validLegendaryNumber: " + validLegendaryNumber;
                    return RedirectToAction(nameof(Create), new { message = message });
                }

            }

            return View();

            int CountCard(string name, string entity)
            {
                int count = 0;
                foreach (var item in checkList)
                {
                    if (entity == "name")
                    {
                        if (item.Name == name) count++;
                    }
                    if (entity == "rarity")
                    {
                        if (item.Rarity == CardRarity.LEGENDARY) count++;
                    }
                }
                return count;
            }

            Boolean CountClassType(ClassType className)
            {
                if (!classTypeNumber.Contains(className)) classTypeNumber.Add(className);
                if (classTypeNumber.Count == 2 && !classTypeNumber.Contains(ClassType.Neutral)) return false;
                if (classTypeNumber.Count <= 2) return true;

                return false;
            }
        }

        // GET: Deck/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck.FindAsync(id);
            if (deck == null)
            {
                return NotFound();
            }
            return View(deck);
        }

        // POST: Deck/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string author, string title, ClassType classType)
        {
            Deck deck = new Deck(title, author, classType);
            deck.ID = id;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeckExists(deck.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(deck);
        }

        // GET: Deck/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deck = await _context.Deck
                .FirstOrDefaultAsync(m => m.ID == id);
            if (deck == null)
            {
                return NotFound();
            }

            return View(deck);
        }

        // POST: Deck/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //suppression des cartes
            var cards = from d in _context.Card select d;
            cards = cards.Where(x => x.deckID == id);
            Card[] cardList = await cards.ToArrayAsync();
            _context.Card.RemoveRange(cardList);

            //suppression du deck
            var deck = await _context.Deck.FindAsync(id);
            _context.Deck.Remove(deck);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeckExists(int id)
        {
            return _context.Deck.Any(e => e.ID == id);
        }
    }
}
