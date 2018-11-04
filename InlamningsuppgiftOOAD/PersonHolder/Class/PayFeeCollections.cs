using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class PayFeeCollection : Person
    {
        PersonCollection Collection = new PersonCollection();
        private readonly string Path = @"C:\Users\Emma\Desktop\InlämningsuppgiftOOAD\InlämningsuppgiftOOAD\Files\PayFeeFirst.txt";

        private List<Person> PayFeeList = new List<Person>();

        public IEnumerable<Person> GetEnumerator()
        {
            foreach (var value in this.PayFeeList)
            {
                yield return value;
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

            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine(values);
            }

            Collection.AddPerson(values);
        }

        public void RemoveAndWrite(List<Person> persons)
        {
            using (StreamWriter writer = new StreamWriter(Path, false))
            {
                foreach (var values in persons)
                {
                    writer.WriteLine(values);
                }
            }
        }


        public int Reading() //För att läsa Medlemmar
        {
            PayFeeList.Clear(); //Tömmer listan ifall det finns värden från början så skrivs det inte ut x antal gånger

            var numberOfClients = 0;
            using (StreamReader r = new StreamReader(Path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    numberOfClients++;
                }
            }

            using (var reader = new StreamReader(Path)) //Textfil  läsas in
            {

                for (int i = 0; i < numberOfClients; i++)
                {
                    string information = reader.ReadLine();

                    string[] toArrays = information.Split(';');

                    Person client = new Person(Convert.ToInt32(toArrays[0]),
                    toArrays[1], toArrays[2], toArrays[3]);

                    PayFeeList.Add(client);
                }
            }

            return numberOfClients;
        }
    }
}
