using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BlackJack
{
    class Game
    {
        public int bank;
        bool play;
        public DeckUtil deckUtil;
        public int deckNumber;
        public int maxBank;

        public Game()
        {
            bank = Convert.ToInt32(ConfigurationManager.AppSettings["StartingBank"]);
            deckNumber = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfDecks"]);
            play = true;
            deckUtil = new DeckUtil();
            deckUtil.setDeck(deckNumber);
            maxBank = 100;
        }

        public void playGame()
        {
            //Playing the game
            while (bank > 0 && play)
            {
                Console.Clear();

                //Check if deck needs to be shuffled
                if (deckUtil.deck.Count() < 15)
                {
                    Console.WriteLine("Shuffling deck...");
                    deckUtil.setDeck(deckNumber);
                }
                double percentRemaining = Math.Round((((double)deckUtil.deck.Count()) / (52 * (double)deckNumber) * 100), 2);


                Console.WriteLine("Cards Remaining in deck: {0}%", percentRemaining);

                Console.WriteLine("Bank: ${0}", bank);

                //Get bet and validate
                Console.Write("Bet amount: $");
                var input = Console.ReadLine();
                int bet = -1;
                Int32.TryParse(input, out bet);
                while (bet <= 0 || bet > bank)
                {
                    Console.WriteLine("Bet has to be greater then  zero and cannot be more than bank amount.");
                    Console.Write("Please enter bet: $");
                    input = Console.ReadLine();
                    Int32.TryParse(input, out bet);
                }

                Console.Clear();

                //Deal cards
                Hand dealer = new Hand();
                Hand user = new Hand();
                dealer.addCard(deckUtil.getCard());
                user.addCard(deckUtil.getCard());
                user.addCard(deckUtil.getCard());
                Console.WriteLine("Dealer: " + dealer.showCards());
                Console.WriteLine("User: " + user.showCards());
                dealer.addCard(deckUtil.getCard());

                bool playing = true;

                //Let player hit or stay
                while (playing && user.getValue() < 21)
                {
                    playing = false;
                    Console.Write("Hit/Stay (H to hit, enter to stay, d to double down): ");
                    string answer = Console.ReadLine();
                    if (answer == "h")
                    {
                        user.addCard(deckUtil.getCard());
                        Console.WriteLine("User: " + user.showCards());
                        playing = true;
                    }else if (answer == "d")
                    {
                        if(bet * 2 <= bank)
                        {
                            bet += bet;
                            user.addCard(deckUtil.getCard());
                            playing = false;
                        }
                        else
                        {
                            playing = true;
                            Console.WriteLine("Not enough funds to double down.");
                        }
                    }

                    if (user.getValue() >= 21)
                    {
                        playing = false;
                    }
                }

                //Dealers turn
                //Console.Clear();
                Console.WriteLine("User: " + user.showCards());
                Console.WriteLine("Dealer: " + dealer.showCards());
                while (dealer.getValue() < 17)
                {
                    dealer.addCard(deckUtil.getCard());
                    Console.WriteLine("Dealer: " + dealer.showCards());
                }
                //Console.WriteLine("User: " + user.showCards());


                //Scoring
                Scoring score = new Scoring();
                bank += score.getScore(dealer, user, bet);

                Console.WriteLine("Bank: ${0}", bank);

                if (bank > maxBank)
                {
                    maxBank = bank;
                }


                //Continue game?
                Console.WriteLine("Enter to Continue, N to quit: ");
                string keppPlaying = Console.ReadLine();
                if (keppPlaying == "n")
                {
                    break;
                }
            }
        }








    }
}
