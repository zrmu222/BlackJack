using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BlackJack
{
    class HighScore
    {

        string path;

        public HighScore()
        {
            path = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
        }





        public void saveScore(int score)
        {
            List<int> scores = getScores();
            scores.Add(score);
            scores.Sort();
            scores.Reverse();

            StreamWriter writer;
            try
            {
                writer = new StreamWriter(path + @"\Highscores.txt");              
                for (int i = 0; i < scores.Count && i < 5; i++)
                {

                    if (scores[i] > 100)
                    {
                        writer.WriteLine(scores[i]);
                    }
                }


                writer.Close();
            } catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message.ToString());
                Console.ReadKey();
            }
            finally
            {
            }

        }

        public List<int> getScores()
        {
            List<int> scoreList = new List<int>();
            try
            {
                StreamReader reader = new StreamReader(path + @"\Highscores.txt");
                string str = "";
                while ((str = reader.ReadLine()) != null)
                {
                    scoreList.Add(Convert.ToInt32(str));
                }
                reader.Close();

            }catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message.ToString());
                Console.ReadKey();
            }

            scoreList.Sort();
            scoreList.Reverse();
            return scoreList;
        }





    }
}
