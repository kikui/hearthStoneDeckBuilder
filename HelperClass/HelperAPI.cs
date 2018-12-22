using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hearthStoneDeckBuilder.Models;
using hearthStoneDeckBuilder.ViewModels;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace hearthStoneDeckBuilder.HelperClass
{
    public class HelperAPI : IHelperAPI
    {
        static HttpClient client = new HttpClient();

        public async Task<BuildDeckViewModel> getCards(List<string> types)
        {
            int countMinion = 0;
            int countSpell = 0;
            int countEnchantment = 0;
            int countHero = 0;
            int countHeroPower = 0;
            int countWeapon = 0;
            List<Card> CardListMinion = new List<Card>();
            List<Card> CardListSpell = new List<Card>();
            List<Card> CardListEnchantment = new List<Card>();
            List<Card> CardListWeapon = new List<Card>();
            List<Card> CardListHero = new List<Card>();
            List<Card> CardListHeroPower = new List<Card>();
            List<BuildDeckStatViewModel> viewModelList = new List<BuildDeckStatViewModel>();

            HttpResponseMessage response = await client.GetAsync("https://api.hearthstonejson.com/v1/27845/frFR/cards.json");
            JArray jsonParseList = new JArray();
            if (response.IsSuccessStatusCode)
            {
                jsonParseList = await response.Content.ReadAsAsync<JArray>();

                foreach (var item in jsonParseList)
                {
                    if (item["type"] != null)
                    {
                        string jsonType = item["type"].Value<string>();
                        string idCard = item["id"].Value<string>();
                        CardType jsonTypeClass = (CardType)Enum.Parse(typeof(CardType), jsonType);
                        foreach (var type in types)
                        {
                            CardType typeClass = (CardType)Enum.Parse(typeof(CardType), type);
                            if (jsonTypeClass == typeClass)
                            {
                                if (typeClass == CardType.ENCHANTMENT)
                                {
                                    EnchantmentCard Card = item.ToObject<EnchantmentCard>();
                                    countEnchantment++;
                                    Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                    CardListEnchantment.Add(Card);
                                }
                                else if (typeClass == CardType.HERO)
                                {
                                    HeroCard Card = item.ToObject<HeroCard>();
                                    if (Card.Armor != 0)
                                    {
                                        countHero++;
                                        Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                        CardListHero.Add(Card);
                                    }
                                }
                                else if (typeClass == CardType.HERO_POWER)
                                {
                                    HeroPowerCard Card = item.ToObject<HeroPowerCard>();
                                    countHeroPower++;
                                    Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                    CardListHeroPower.Add(Card);
                                }
                                else if (typeClass == CardType.MINION)
                                {
                                    MinionCard Card = item.ToObject<MinionCard>();
                                    countMinion++;
                                    Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                    CardListMinion.Add(Card);
                                }
                                else if (typeClass == CardType.SPELL)
                                {
                                    SpellCard Card = item.ToObject<SpellCard>();
                                    countSpell++;
                                    Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                    CardListSpell.Add(Card);
                                }
                                else if (typeClass == CardType.WEAPON)
                                {
                                    WeaponCard Card = item.ToObject<WeaponCard>();
                                    countWeapon++;
                                    Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                                    CardListWeapon.Add(Card);
                                }
                            }
                        }
                    }

                }

                CardStat cardStatMinion = new CardStat("minion", countMinion);
                CardStat cardStatSpell = new CardStat("spell", countSpell);
                CardStat cardStatHero = new CardStat("hero", countHero);
                CardStat cardStatHeroPower = new CardStat("hero_power", countHeroPower);
                CardStat cardStatWeapon = new CardStat("weapon", countWeapon);
                CardStat cardStatEnchantment = new CardStat("enchantment", countEnchantment);

                var statViewModelMinion = new BuildDeckStatViewModel
                {
                    CardStat = cardStatMinion,
                    Cards = CardListMinion
                };
                var statViewModelSpell = new BuildDeckStatViewModel
                {
                    CardStat = cardStatSpell,
                    Cards = CardListSpell
                };
                var statViewModelHero = new BuildDeckStatViewModel
                {
                    CardStat = cardStatHero,
                    Cards = CardListHero
                };
                var statViewModelHeroPower = new BuildDeckStatViewModel
                {
                    CardStat = cardStatHeroPower,
                    Cards = CardListHeroPower
                };
                var statViewModelWeapon = new BuildDeckStatViewModel
                {
                    CardStat = cardStatWeapon,
                    Cards = CardListWeapon
                };
                var statViewModelEnchantment = new BuildDeckStatViewModel
                {
                    CardStat = cardStatEnchantment,
                    Cards = CardListEnchantment
                };

                BuildDeckStatViewModel[] rangeStatViewModel = {
                    statViewModelEnchantment,
                    statViewModelHero,
                    statViewModelHeroPower,
                    statViewModelWeapon,
                    statViewModelSpell,
                    statViewModelMinion
                    };

                viewModelList.AddRange(rangeStatViewModel);

                var model = new BuildDeckViewModel
                {
                    Stats = viewModelList
                };
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<BuildDeckViewModel> getAllCards()
        {
            //pourquoi avoir faire un getCards par type ?
            //pour afficher les enchantements dans mes tests, 
            //et les enlever dans le build sans devoir retaper tout un meme code
            List<string> cards = new List<string>();
            string[] listType = { "MINION", "ENCHANTMENT", "HERO", "HERO_POWER", "SPELL", "WEAPON" };
            cards.AddRange(listType);
            var model = await getCards(cards);

            return model;
        }

        public async Task<List<Card>> getCardsByID(string[] idList)
        {
            //recup un nombre de cartes en fonction de la liste d ID
            List<Card> deck = new List<Card>();

            HttpResponseMessage response = await client.GetAsync("https://api.hearthstonejson.com/v1/27845/frFR/cards.json");
            JArray jsonParseList = new JArray();
            if (response.IsSuccessStatusCode)
            {
                jsonParseList = await response.Content.ReadAsAsync<JArray>();
                foreach (var item in jsonParseList)
                {
                    if (item["id"] != null)
                    {
                        foreach (var item2 in idList)
                        {
                            if (item2 == item["id"].Value<string>())
                            {
                                Card card = searchRightTypeClass(item);
                                if(card != null) deck.Add(card);
                            }
                        }
                    }
                }
            }

            Console.WriteLine(deck.Count);
            return deck;
        }

        public async Task<List<Card>> getPresetDeck(PresetDeckEnum deckShape)
        {
            //récupère un deck en fonction de la selection
            List<Card> deck;

            //selection des cartes
            //deck de moins de 30 cartes
            string[] packCard1 = { "AT_017", "AT_022", "AT_024", "AT_067", "AT_069", "AT_071", "CFM_669", "AT_091", "AT_117", "AT_130", "BOT_059", "BOT_102t", "BOT_104", "BOT_107", "BOT_218", "BOT_218t", "BOT_237", "BOT_286", "BOT_286", "BOT_406", "BOT_413", "BRMA10_6", "BRMA13_4", "BRMA16_5", "BRMA17_9", "CS2_049", "EX1_144", "GILA_600h2", "AT_005", "AT_005", "EX1_144" };
            //deck avec 3 cartes identiques
            string[] packCard2 = { "AT_017", "AT_022", "AT_024", "AT_067", "AT_069", "AT_071", "CFM_669", "AT_091", "AT_117", "AT_130", "BOT_059", "BOT_102t", "BOT_104", "BOT_107", "BOT_218", "BOT_218t", "BOT_237", "BOT_286", "BOT_286", "BOT_406", "BOT_413", "BRMA10_6", "BRMA13_4", "BRMA16_5", "BRMA17_9", "CS2_049", "AT_005", "GILA_600h2", "AT_005", "AT_005"  };
            //deck avec 2 héros
            string[] packCard3 = { "AT_017", "AT_022", "AT_024", "AT_067", "AT_069", "AT_071", "CFM_669", "AT_091", "AT_117", "AT_130", "BOT_059", "BOT_102t", "BOT_104", "BOT_107", "BOT_218", "BOT_218t", "BOT_237", "BOT_286", "BOT_286", "BOT_406", "BOT_413", "BRMA10_6", "BRMA13_4", "BRMA16_5", "BRMA17_9", "CS2_049", "EX1_144", "GILA_600h2", "ICC_829", "AT_005"  };
            //deck ne respectant pas la class du deck
            string[] packCard4 = { "AT_017", "AT_057", "AT_024", "AT_067", "AT_069", "AT_071", "CFM_669", "AT_091", "AT_117", "AT_130", "BOT_059", "BOT_102t", "BOT_104", "BOT_107", "BOT_218", "BOT_218t", "BOT_237", "BOT_286", "BOT_286", "BOT_406", "BOT_413", "BRMA10_6", "BRMA13_4", "BRMA16_5", "BRMA17_9", "CS2_049", "EX1_144", "GILA_600h2", "AT_005", "AT_005"  };
            //respectant les règles
            string[] packCard5 = { "AT_017", "AT_022", "AT_024", "AT_067", "AT_069", "AT_071", "CFM_669", "AT_091", "AT_117", "AT_130", "BOT_059", "BOT_102t", "BOT_104", "BOT_107", "BOT_218", "BOT_218t", "BOT_237", "BOT_286", "BOT_286", "BOT_406", "BOT_413", "BRMA10_6", "BRMA13_4", "BRMA16_5", "BRMA17_9", "CS2_049", "EX1_144", "GILA_600h2", "AT_005", "AT_005" };

            if (deckShape == PresetDeckEnum.InvalidBadNumberCards)
            {
                deck = await getCardsByID(packCard1);
            }
            else if (deckShape == PresetDeckEnum.InvalidRepeatCard)
            {
                deck = await getCardsByID(packCard2);
            }
            else if (deckShape == PresetDeckEnum.InvalidOverHero)
            {
                deck = await getCardsByID(packCard3);
            }
            else if (deckShape == PresetDeckEnum.InvalidClassDeck)
            {
                deck = await getCardsByID(packCard4);
            }
            else if (deckShape == PresetDeckEnum.ValidDeck)
            {
                deck = await getCardsByID(packCard5);
            }
            else
            {
                deck = new List<Card>();
            }

            return deck;
        }

        //fonction de simplification de parcour de type de card
        private Card searchRightTypeClass(JToken item)
        {
            //je recup mon token et je veux verifier de quel type il est pour utiliser la bonne class
            string jsonType = item["type"].Value<string>();
            string idCard = item["id"].Value<string>();
            CardType jsonTypeClass = (CardType)Enum.Parse(typeof(CardType), jsonType);
            
            if (jsonTypeClass == CardType.HERO)
            {
                HeroCard Card = item.ToObject<HeroCard>();
                Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                Console.WriteLine(Card.Name + " " + Card.Type + " " + Card.CardClass + " " + Card.Rarity + " : " + idCard);
                return Card;
            }
            else if (jsonTypeClass == CardType.HERO_POWER)
            {
                HeroPowerCard Card = item.ToObject<HeroPowerCard>();
                Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                Console.WriteLine(Card.Name + " " + Card.Type + " " + Card.CardClass + " " + Card.Rarity + " : " + idCard);
                return Card;
            }
            else if (jsonTypeClass == CardType.MINION)
            {
                MinionCard Card = item.ToObject<MinionCard>();
                Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                Console.WriteLine(Card.Name + " " + Card.Type + " " + Card.CardClass + " " + Card.Rarity + " : " + idCard);
                return Card;
            }
            else if (jsonTypeClass == CardType.SPELL)
            {
                SpellCard Card = item.ToObject<SpellCard>();
                Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                Console.WriteLine(Card.Name + " " + Card.Type + " " + Card.CardClass + " " + Card.Rarity + " : " + idCard);
                return Card;
            }
            else if (jsonTypeClass == CardType.WEAPON)
            {
                WeaponCard Card = item.ToObject<WeaponCard>();
                Card.LinkPicture = "https://art.hearthstonejson.com/v1/render/latest/frFR/512x/" + idCard + ".png";
                Console.WriteLine(Card.Name + " " + Card.Type + " " + Card.CardClass + " " + Card.Rarity + " : " + idCard);
                return Card;
            }

            return null;
        }
    }
}