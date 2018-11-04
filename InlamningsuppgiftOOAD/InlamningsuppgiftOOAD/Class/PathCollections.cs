using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class PathCollections : PathClass
    {
        private readonly string Path = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\EnviromentPath.txt";

        private List<PathClass> PathList = new List<PathClass>();

        public IEnumerable<PathClass> GetEnumerator()
        {
            foreach (var value in this.PathList)
            {
                yield return value;
            }
        }

        public void Writing(int matchid, string personOne, string personTwo, string _name, int number)
        {
            if (_name == "1") _name = "Bowling Discos";
            else if (_name == "2") _name = "Monas Bowlinghall";
            else if (_name == "3") _name = "LunaBowl";

            string one = new CultureInfo("en-US").TextInfo.ToTitleCase(personOne);
            string two = new CultureInfo("en-US").TextInfo.ToTitleCase(personTwo);

            personOne = one;
            personTwo = two;

            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine(matchid + ";" + personOne + ";" + personTwo + ";" + _name + ";" + number);
            }
        }

        public void Reading()
        {
            var lastLine = File.ReadLines(Path).Last();
            var input = lastLine.Replace(";", " ");

            Console.WriteLine("Du, motståndaren, vart och vilken bana:" + input);
        }

        public void Find()
        {
            PathList.Clear(); //Tömmer innan inläsningen för att inte få dubbletter

            var numberOfRequests = 0;
            using (StreamReader r = new StreamReader(Path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    numberOfRequests++;
                }
            }

            using (var reader = new StreamReader(Path)) //Textfil  läsas in
            {

                for (int i = 0; i < numberOfRequests; i++)
                {
                    string information = reader.ReadLine();

                    string[] toArrays = information.Split(';');

                    PathClass client = new PathClass(Convert.ToInt32(toArrays[0]), toArrays[1], toArrays[2], toArrays[3], Convert.ToInt32(toArrays[4]));

                    PathList.Add(client);
                }
            }

            //var list = GetEnumerator();

            //foreach (var values in list)
            //{
            //    var personOne = Regex.Replace(values.PersonOne, @"[\d-]", "");
            //    var personTwo = Regex.Replace(values.PersonTwo, @"[\d-]", "");

            //    Console.WriteLine($"{personOne} och{personTwo} tävlar hos {values.Place} på bana nummer {values.PathOnPlace}");
            //}
        }
    }
}