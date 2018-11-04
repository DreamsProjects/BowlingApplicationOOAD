using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class ContestCollection : Contest
    {
        private List<Contest> Contests = new List<Contest>();

        public IEnumerable<Contest> GetEnumerator()
        {
            foreach (var value in this.Contests)
            {
                yield return value;
            }
        }

        public bool AddContest(Contest contest)
        {
            Contests.Add(contest);
            return true;
        }

        public bool RemoveContest(Contest contest)
        {
            Contests.Remove(contest);
            return true;
        }

        public void Reading() //För att läsa in matcher
        {
            Contests.Clear();

            var path = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Contests.txt";

            var numberOfClients = 0;
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

                    Contest client = new Contest(toArrays[0], Convert.ToDateTime(toArrays[1]), Convert.ToDateTime(toArrays[2]), toArrays[3]);

                    Contests.Add(client);
                }

                if (numberOfClients == 0) Console.WriteLine("Inga matcher funna");
            }
        }

        public void Writing(Contest values)
        {
            //System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(values.Name.ToLower());

            string s = new CultureInfo("en-US").TextInfo.ToTitleCase(values.Name);
            values.Name = s;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\emma\source\repos\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Contests.txt", true))
            {
                writer.WriteLine(values.ToString());
            }

            AddContest(values);
        }
    }
}
