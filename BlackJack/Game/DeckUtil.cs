using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class DeckUtil
    {
        public Dictionary<string, int> deck;


        public DeckUtil()
        {
            deck = new Dictionary<string, int>();
        }

        public void setDeck(int deckNumber)
        {
            deck = new Dictionary<string, int>();
            Dictionary<string, int> shuffledDeck = new Dictionary<string, int>();
            List<string> suit = new List<string> { "Hearts", "Diamonds", "Spade", "Clubs" };
            List<string> number = new List<string> {"2", "3", "4", "5", "6", "7", "8", "9", "10"};
            List<string> faceCards = new List<string> { "Jack", "Queen", "King" };

            string deckNumberIdentifer = "";
            for(int d = 0; d < deckNumber; d++)
            {
                foreach (string s in suit)
                {
                    for (int i = 0; i < number.Count; i++)
                    {
                        shuffledDeck.Add((number[i] + "-" + s + deckNumberIdentifer), i + 2);
                    }
                    foreach (string f in faceCards)
                    {
                        shuffledDeck.Add(f + "-" + s + deckNumberIdentifer, 10);
                    }
                    shuffledDeck.Add("Ace-" + s + deckNumberIdentifer, 11);
                }

                deck = shuffledDeck;

                /*
                while (shuffledDeck.Count > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(0, shuffledDeck.Count - 1);
                    //string key = shuffledDeck.ElementAt(rand.Next(0, shuffledDeck.Count)).Key;
                    KeyValuePair<string, int> card = shuffledDeck.ElementAt(rand);
                    //int value = shuffledDeck[key];
                    shuffledDeck.Remove(card.Key);
                    deck.Add(card.Key, card.Value);
                } */
                deckNumberIdentifer += " ";
                
            }

            shuffleDeck(5);

        }

        public KeyValuePair<string, int> getCard(Dictionary<string, int> remainingDeck)
        {
            Random rand = new Random();
            string key = remainingDeck.ElementAt(rand.Next(0, remainingDeck.Count)).Key;
            int value = remainingDeck[key];
            remainingDeck.Remove(key);
            return new KeyValuePair<string, int>(key, value);
        }

        public KeyValuePair<string, int> getCard()
        {
            var card = deck.First();
            deck.Remove(card.Key);
            return new KeyValuePair<string, int>(card.Key, card.Value);
            /*
            Random random = new Random();
            int rand = random.Next(0, deck.Count - 1);
            KeyValuePair<string, int> card = deck.ElementAt(rand);
            deck.Remove(card.Key);
            return card;
            */
        }


        public void shuffleDeck(int number)
        {
            for(int i = 0; i < number; i++)
            {
                Dictionary<string, int> shuffledDeck = new Dictionary<string, int>();
                while(deck.Count > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(0, deck.Count - 1);
                    KeyValuePair<string, int> card = deck.ElementAt(rand);
                    shuffledDeck.Add(card.Key, card.Value);
                    deck.Remove(card.Key);
                }
                deck = shuffledDeck;
            }
        }



    }
}
