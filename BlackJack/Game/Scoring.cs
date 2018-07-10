using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Scoring
    {

        public Scoring()
        {

        }


        public int getScore(Hand dealer, Hand user, int bet)
        {
            int userValue = user.getValue();
            int dealerValue = dealer.getValue();


            int result = 0;

            if (userValue > 21)
            {
                Console.WriteLine("Bust");
                result = -bet;
            }
            else if (userValue == dealerValue)
            {
                Console.WriteLine("Split");
            }
            else if (userValue == 21)
            {
                Console.WriteLine("Winner Winner!");
                result = bet * 2;

            }
            else if (dealerValue > 21)
            {
                Console.WriteLine("You Win!");
                result = bet;
            }
            else if (userValue > dealerValue && dealerValue < 21)
            {
                Console.WriteLine("Winner!");
                result = bet;
            }
            else
            {
                Console.WriteLine("Dealer Wins.");
                result = -bet;
            }

            return result;
        }


    }
}
