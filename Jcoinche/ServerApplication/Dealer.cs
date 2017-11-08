using System;
using System.Collections.Generic;

namespace ServerApplication
{
    // Le Dealer s'occupe de créer les cartes et de les distribuer
    class Dealer
    {
        Deck deck = new Deck();
        private static Random rng = new Random();

        public void CreateDeck()
        {
            deck.deck = new List<Cards>();
            CreateColor("Heart");
            CreateColor("Club");
            CreateColor("Diamond");
            CreateColor("Spades");
        }

        public void CreateColor(String suit)
        {
            CreateValue(suit, "two");
            CreateValue(suit, "three");
            CreateValue(suit, "four");
            CreateValue(suit, "five");
            CreateValue(suit, "six");
            CreateValue(suit, "seven");
            CreateValue(suit, "eight");
            CreateValue(suit, "nine");
            CreateValue(suit, "ten");
            CreateValue(suit, "jack");
            CreateValue(suit, "queen");
            CreateValue(suit, "king");
            CreateValue(suit, "ace");
        }

        public void CreateValue(string suit, string rank)
        {
            Cards tmp = new Cards();
            tmp.color = suit;
            tmp.rank = rank;
            deck.deck.Add(tmp);
            CardDistribution();
        }
     
        public void Shuffle()
        {
            Cards temp = new Cards();
            for (int i = deck.deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                temp = deck.deck[i];
                deck.deck[i] = deck.deck[j];
                deck.deck[j] = temp;
                PrintCollection(deck.deck);
            }
        }
        public void PrintCollection<T>(IEnumerable<T> col)
        {
            foreach (var item in col)
                Console.WriteLine(item);
        }
        public void CardDistribution()
        {
            int i = 0;
            Shuffle();

            while (i != 52)
            {

            }
            
        }
    }
}
