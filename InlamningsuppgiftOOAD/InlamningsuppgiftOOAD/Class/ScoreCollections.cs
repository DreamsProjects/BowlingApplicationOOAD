using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class ScoreCollections : Scores
    {
        private List<Scores> Scores = new List<Scores>();

        public IEnumerable<Scores> GetEnumerator()
        {
            foreach (var value in this.Scores)
            {
                yield return value;
            }
        }

        public bool AddScore(Scores score)
        {
            Scores.Add(score);
            return true;
        }

        public bool RemoveGame(Scores score)
        {
            Scores.Remove(score);
            return true;
        }

        public void Reading() //För att läsa in matcher
        {
            Scores.Clear();

            var numberOfClients = 0;
            var path = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Scores.txt";

            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    numberOfClients++;
                }
            }

            using (var reader = new StreamReader(path)) //Textfil  läsas in
            {
                for (int i = 0; i < numberOfClients; i++)
                {
                    string information = reader.ReadLine();
                    string[] toArrays = information.Split(';');

                    Scores client = new Scores(Convert.ToInt32(toArrays[0]), toArrays[1]); //lagt till två arrays??!!?

                    Scores.Add(client);
                }

                if (numberOfClients == 0)
                    Console.WriteLine("Inga matcher funna");
            }
        }

        public void Writing(Scores scores)
        {
            string winner = new CultureInfo("en-US").TextInfo.ToTitleCase(scores.Winner);

            scores.Winner = winner;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\emma\source\repos\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Scores.txt", true))
            {
                writer.WriteLine(scores.ToString());
            }

            AddScore(scores);
        }
    }
}
