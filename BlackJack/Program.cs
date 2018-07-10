using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    static class Program
    {

        static void Main()
        {
            HighScore highScore = new HighScore();
            List<int> scores = highScore.getScores();
            Console.WriteLine("Highscores: ");
            foreach (int i in scores)
            {
                Console.WriteLine("$" + i);
            }
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Starting BlackJack...");
            Console.Write("How many decks do you want to play with?: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Game game = new Game
            {
                deckNumber = number
            };
            game.deckUtil.setDeck(number);
            game.playGame();          
            highScore.saveScore(game.maxBank);
            Console.WriteLine("Score: ${0}", game.maxBank);
            Console.ReadKey();
        }
    }

}
