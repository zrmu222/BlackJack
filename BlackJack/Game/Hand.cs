using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Hand
    {

        Dictionary<string, int> cards;

        public Hand()
        {
            cards = new Dictionary<string, int>();
        }

        public void addCard(KeyValuePair<string, int> card)
        {
            cards.Add(card.Key, card.Value);
        }


        public string showCards()
        {
            string showCards = "Cards: ";

            foreach(KeyValuePair<string, int> c in cards)
            {
                showCards += c.Key + " ";
            }

            showCards += "Value: " + getValue();

            return showCards;
        }



        public int getValue()
        {
            int value = 0;

            foreach(KeyValuePair<string, int> v in cards)
            {

                if(v.Value != 11)
                {
                    value += v.Value;
                }
            }

            foreach(KeyValuePair<string, int> a in cards)
            {
                if(a.Value == 11)
                {
                    if(value + 11 > 21)
                    {
                        value += 1;
                    }else
                    {
                        value += 11;
                    }
                }
            }

            return value;
        }

        



    }
}
