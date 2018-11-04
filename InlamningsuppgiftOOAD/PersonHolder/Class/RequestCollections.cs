using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class RequestCollections : Request
    {

        private List<Request> Requests = new List<Request>();

        //Gömmer den underliggande kollektionen från dem som använder den.
        public IEnumerable<Request> GetEnumerator()
        {
            foreach (var value in this.Requests)
            {
                yield return value;
            }
        }

        public bool AddRequest(Request request)
        {
            Requests.Add(request);
            return true;
        }

        public bool RemoveRequest(Request request)
        {
            Requests.Remove(request);
            return true;
        }

        public void Reading() //För att läsa Medlemmar
        {
            Requests.Clear(); //Tömmer listan ifall det finns värden från början så skrivs det inte ut x antal gånger

            var path = @"C:\Users\Emma\Desktop\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Request.txt";

            var numberOfRequests = 0;
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    numberOfRequests++;
                }
            }

            using (var reader = new StreamReader(path)) //Textfil  läsas in
            {

                for (int i = 0; i < numberOfRequests; i++)
                {
                    string information = reader.ReadLine();

                    string[] toArrays = information.Split(';');

                    Request client = new Request(toArrays[0], toArrays[1], Convert.ToInt32(toArrays[2]), Convert.ToInt32(toArrays[3]));

                    Requests.Add(client);
                }

                if (numberOfRequests == 0) { Console.WriteLine("Inga request funna"); }
            }
        }

        public void Writing(Request values)
        {
            string first = new CultureInfo("en-US").TextInfo.ToTitleCase(values.FirstName);
            string last = new CultureInfo("en-US").TextInfo.ToTitleCase(values.LastName);
            string email = new CultureInfo("en-US").TextInfo.ToTitleCase(values.Email);

            values.FirstName = first;
            values.LastName = last;
            values.Email = email;

            using (StreamWriter writer = new StreamWriter(@"C:\Users\emma\source\repos\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Request.txt", true))
            {
                writer.WriteLine(values.ToString());
            }

            AddRequest(values);
        }
    }
}
