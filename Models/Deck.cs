namespace hearthStoneDeckBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deck
    {
        public int ID{get; set;}
        [Display(Name = "Auteur"), Required]
        public string Author { get; set; }
        [Display(Name = "Type de cartes"), Required]
        public ClassType ClassType { get; set; }
        [Display(Name = "Nom du deck"), Required]
        public string Title { get; set; }
        [Display(Name = "Preset Deck"), Required]
        public List<Card> List { get; set; }

        public Deck(string title, string author, ClassType classType)
        {
            Title = title;
            Author = author;
            ClassType = classType;
        }
    }
}