using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class PersonCollection : Person
    {
        private List<Person> Persons = new List<Person>();

        //Gömmer den underliggande kollektionen från dem som använder den.
        public IEnumerable<Person> GetEnumerator()
        {
            foreach (var value in this.Persons)
            {
                yield return value;
            }
        }

        public bool AddPerson(Person person)
        {
            Persons.Add(person);
            return true;
        }

        public bool RemovePerson(Person person)
        {
            Persons.Remove(person);
            return true;
        }

        public void Reading() //För att läsa Medlemmar
        {
            Persons.Clear(); //Tömmer listan ifall det finns värden från början så skrivs det inte ut x antal gånger

            var path = @"C:\Users\Emma\Desktop\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Members.txt";

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

                    Person client = new Person(Convert.ToInt32(toArrays[0]),
                    toArrays[1], toArrays[2], toArrays[3]);

                    Persons.Add(client);
                }

                if (numberOfClients == 0) { Console.WriteLine("Inga medlemmar funna"); }
            }
        }

        public void Writing(Person values)
        {
            string first = new CultureInfo("en-US").TextInfo.ToTitleCase(values.FirstName);
            string last = new CultureInfo("en-US").TextInfo.ToTitleCase(values.LastName);
            string email = new CultureInfo("en-US").TextInfo.ToTitleCase(values.Email);

            values.FirstName = first;
            values.LastName = last;
            values.Email = email;


            using (StreamWriter writer = new StreamWriter(@"C:\Users\emma\source\repos\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\Members.txt", true))
            {
                writer.WriteLine(values);
            }

            AddPerson(values);
        }
    }
}
