using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.DataLayer
{
    public class PersonRepo : IPersonRepo
    {
        PersonCollection PersonCollection = new PersonCollection();
        GameCollection GameCollection = new GameCollection();
        ScoreCollections ScoreCollection = new ScoreCollections();
        ContestCollection ContestCollection = new ContestCollection();
        RequestCollections RequestCollections = new RequestCollections();
        PathCollections PathCollection = new PathCollections();
        PayFeeCollection PayFeeCollection = new PayFeeCollection();
        StringBuilder Builder = new StringBuilder();

        MathProxy proxy = new MathProxy();

        public string FilePath = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Logger.txt";

        public IEnumerable<Request> AnyRequest()
        {
            RequestCollections.Reading();
            return RequestCollections.GetEnumerator();
        }

        public IEnumerable<Person> PayFee()
        {
            PayFeeCollection.Reading();
            return PayFeeCollection.GetEnumerator();
        }

        public string NewPerson(Person person)
        {
            var getNumber = 0;
            var list = GetPersons();

            foreach (var number in list) //Från PayFee
            {
                if (getNumber < number.ContestNumber)
                {
                    getNumber = number.ContestNumber;
                }
            }

            var persons = new Person(getNumber, person.FirstName, person.LastName, person.Email);

            if (getNumber != 0)
            {
                PersonCollection.Writing(persons);

                return "Fungerade";
            }

            else
                return "Fungerade inte";

        }

        public string NewPerson()
        {
            PersonCollection.Reading();

            var getNumber = 0;
            PayFeeCollection.Reading();

            foreach (var number in PayFeeCollection.GetEnumerator()) //Från PayFee
            {
                if (getNumber < number.ContestNumber)
                {
                    getNumber = number.ContestNumber;
                }
            }

            var count = proxy.Add(getNumber, 1);

            Console.Write("Förnamn: ");
            var firstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            var lastName = Console.ReadLine();
            Console.Write("Epostadress:");
            var email = Console.ReadLine();

            var person = new Person(Convert.ToInt32(count), firstName, lastName, email);

            PayFeeCollection.Writing(person);


            Builder.Append($"\n{DateTime.Now} - En användare vid namn {firstName} {lastName} har lagt till sig i  PayFeeFirst filen");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return $"Du lade till följande information: {firstName} {lastName} med epostadressen {email}. Ditt tävlingsnummer är: {count}";
        }

        public string AddPerson(Person person) //Från NewPerson (PayFee) till Member
        {
            PersonCollection.Writing(person);

            Builder.Append($"\n{DateTime.Now} - Admin har flyttat över {person.FirstName} {person.LastName} med nytt tävlingsnummer {person.ContestNumber} till Member-filen och är markerad som betald.");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return "Tillagd till Memberfilen";
        }

        public string RemoveFromFee(List<Person> person)
        {
            PayFeeCollection.RemoveAndWrite(person);

            return "Listan i PayFee är uppdaterad";
        }

        public IEnumerable<Person> GetPersons()
        {
            PersonCollection.Reading();

            Builder.Append($"\n{DateTime.Now} - Användaren får alla deltagare utskrivna");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return PersonCollection.GetEnumerator();
        }
    }
}
