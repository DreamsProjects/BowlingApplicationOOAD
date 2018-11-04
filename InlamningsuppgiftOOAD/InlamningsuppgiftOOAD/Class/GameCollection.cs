using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace InlamningsuppgiftOOAD.Class
{
    public class GameCollection : Game
    {
        private List<Game> Games = new List<Game>();
        //int CurrentPosition;

        //Gömmer den underliggande kollektionen från dem som använder den.
        public IEnumerable<Game> GetEnumerator()
        {
            foreach (var value in this.Games)
            {
                yield return value;
            }
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

        public void RemoveGame(Game game)
        {
            Games.Remove(game);
        }

        public void Reading() //För att läsa in matcher
        {
            Games.Clear();

            var numberOfClients = 0;
            var path = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Files\Games.txt";

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

                    Game client = new Game(toArrays[0], Convert.ToInt32(toArrays[1]), toArrays[2], toArrays[3]);

                    Games.Add(client);
                }

            }
        }

        public bool Writing(Game value)
        {
            string name = new CultureInfo("en-US").TextInfo.ToTitleCase(value.Name);
            string one = new CultureInfo("en-US").TextInfo.ToTitleCase(value.PersonOne);
            string two = new CultureInfo("en-US").TextInfo.ToTitleCase(value.PersonTwo);

            value.Name = name;
            value.PersonOne = one;
            value.PersonTwo = two;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\emma\source\repos\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Games.txt", true))
            {
                writer.WriteLine(value.ToString());
            }
            AddGame(value);

            return true;
        }
    }
}
