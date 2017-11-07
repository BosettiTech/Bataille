using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    // Le Dealer s'occupe de créer les cartes et de les distribuer
    class Dealer
    {
        Deck deck = new Deck();
        private static Random rng = new Random();

        public void createDeck()
        {
            deck.deck = new List<Cards>();
            createColor("Heart");
            createColor("Club");
            createColor("Diamond");
            createColor("Spades");
        }

        public void createColor(String suit)
        {
            createValue(suit, "two");
            createValue(suit, "three");
            createValue(suit, "four");
            createValue(suit, "five");
            createValue(suit, "six");
            createValue(suit, "seven");
            createValue(suit, "eight");
            createValue(suit, "nine");
            createValue(suit, "ten");
            createValue(suit, "jack");
            createValue(suit, "queen");
            createValue(suit, "king");
            createValue(suit, "ace");
        }

        public void createValue(string suit, string rank)
        {
            Cards tmp = new Cards();
            tmp.color = suit;
            tmp.rank = rank;
            deck.deck.Add(tmp);
        }
        /*
        public void Shuffle()
        {
            for (int i = deck.deck.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Cards temp = deck.deck[i];
                deck.deck[i] = deck.deck[j];
                deck.deck[j] = temp;
            }
        }
        public void CardDistribution()
        {
            int i = 0;
            Shuffle();

        }
        */
    }
}
