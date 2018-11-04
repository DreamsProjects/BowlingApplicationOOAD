using InlamningsuppgiftOOAD.BusinessLayer;
using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD
{
    public class Start
    {
        private IGames _game = new Games();
        MathProxy proxy = new MathProxy();

        public string FilePath = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Logger.txt"; //Ska spara systemhändelse i textfil

        public Start()
        {

            Console.WriteLine("Välkommen till Bengans Bowling Brawl!");

            Console.WriteLine("Är du redan registrerad?");
            var value = Console.ReadLine();
            Register(value);

            Console.WriteLine("Välkommen till Bengans Bowling Brawl!");
            Console.WriteLine("\n** Huvudmeny **");
            Console.WriteLine("0) Deltagare");
            Console.WriteLine("1) Matcher");
            Console.WriteLine("2) Sök match");
            Console.WriteLine("3) Visa vinnare på match");
            Console.WriteLine("4) Visa vinnare på cup");
            Console.WriteLine("5) Årets vinnare");
            Console.WriteLine("6) Tävlingar");
            Console.WriteLine("7) Lägg till dig på match");
            Console.WriteLine("8) Spela");

            Console.WriteLine("Admin 9) Matchhanterare");
            Console.WriteLine("Admin 10) Faktura hantering");

            while (true)
            {
                try
                {
                    Console.Write(">");
                    var input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 0:
                            ReadPeople();
                            break;
                        case 1:
                            ReadGames();
                            break;
                        case 2:
                            SearchGame();
                            break;
                        case 3:
                            WinnersInGames();
                            break;
                        case 4:
                            WinnerOfSpecificContest();
                            break;
                        case 5:
                            Winners();
                            break;
                        case 6:
                            ReadContests();
                            break;
                        case 7:
                            AddOnGame();
                            break;
                        case 8:
                            PlayGame();
                            break;
                        case 9:
                            GameHandler(0); //Match hantering klar
                            break;
                        case 10:
                            GameHandler(1);//Faktura hantering
                            break;

                        default: break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Du kan bara skriva in siffror.. :)");
                }

                catch (OverflowException)
                {
                    Console.WriteLine("Du kan inte skriva in en sådan lång siffra..");
                }
            }
        }

        private void WinnerOfSpecificContest()
        {
            Console.WriteLine("Ange cup namn: ");
            var cups = _game.GetContests();

            foreach (var item in cups)
            {
                Console.WriteLine($"{item.Name}");
            }

            var input = Console.ReadLine();

            var returned = _game.GetWinnerOfSpecificContest(input);

            Console.WriteLine(returned);
        }

        private void Winners()
        {
            var winner = _game.GetWinner();

            if (winner.Count > 0)
            {
                var sort = winner.OrderByDescending(x => x.Percentage).FirstOrDefault();

                Console.WriteLine($"Årets champion: {sort.FirstName} {sort.LastName} vinnar andel: {sort.Percentage}");
            }
            else
            {
                Console.WriteLine("Ingen användare har spelat mer än 10 matcher");
            }
        }

        public void PlayGame()
        {
            var pointOne = 0;
            var pointTwo = 0;
            var roundOne = 0;
            var roundTwo = 0;
            var firstPerson = "";
            var secondPerson = "";
            var winner = "";
            var personOne = "";
            var personTwo = "";

            List<Game> games = new List<Game>();
            Console.WriteLine("Namn på cupen: ");
            var nameOnCup = Console.ReadLine();

            var list = _game.GetGamesOnName(nameOnCup);

            foreach (var item in list)
            {
                if (item.Name.ToLower().Contains(nameOnCup.ToLower()))
                {
                    games.Add(item);
                }

            }

            var valueOfName = "";
            if (games.Count > 0)
            {

                foreach (var item in games)
                {
                    Console.WriteLine("MatchNumret: {0} Personer som möts: {1} vs {2}", item.GameNumber, item.PersonOne, item.PersonTwo);
                    valueOfName = item.ContestDesider;
                }

                Console.WriteLine("Ange MatchNumret");
                var matchId = int.Parse(Console.ReadLine());

                var allreadyExisting = _game.Existing(matchId); //returnerar 0

                try
                {
                    if (allreadyExisting == true) //Om matchen inte redan är tävlad på
                    {
                        foreach (var values in list)
                        {
                            if (values.GameNumber == matchId)
                            {
                                firstPerson = values.PersonOne;
                                secondPerson = values.PersonTwo;
                            }
                        }

                        personOne = Regex.Replace(firstPerson, @"[\d-]", "");
                        personTwo = Regex.Replace(secondPerson, @"[\d-]", "");

                        for (int x = 0; x < 3; x++)
                        {
                            Console.WriteLine($"Match nummer: {x + 1}");
                            Console.WriteLine("******************");

                            for (int i = 0; i < 12; i++)
                            {
                                Console.WriteLine($"Lägg in poäng på rond nummer {i + 1} för person {personOne}");
                                var integerOne = int.Parse(Console.ReadLine());
                                pointOne += integerOne;

                                Console.WriteLine($"Lägg in poäng på rond nummer {i + 1} för person {personTwo}");
                                var integerTwo = int.Parse(Console.ReadLine());
                                pointTwo += integerTwo;

                                if (i == 12)
                                {
                                    if (valueOfName == "Högsta poäng per rond")
                                    {
                                        if (pointOne > pointTwo) { roundOne += 1; Console.WriteLine($"{personOne} har {roundOne} poäng"); }

                                        else if (pointOne < pointTwo) { roundTwo += 1; Console.WriteLine($"{personTwo} har {roundTwo} poäng"); }

                                        else if (pointOne == pointTwo) roundOne += 0; roundTwo += 0;
                                    }

                                    if (x == 3) Console.WriteLine($"{personOne} har {roundOne} vunna ronder och {personTwo} har {roundTwo} vunna ronder.");
                                }
                            }
                        }

                        if (pointOne != 0 && pointTwo != 0)
                        {
                            Console.WriteLine($"Är resultaten för spelare {personOne} korrekt? {pointOne}");
                            var yesOrNo = Console.ReadLine();

                            Console.WriteLine($"Är slutresultatet för spelare {personTwo} korrekt? {pointTwo}");
                            var yesOrNoTwo = Console.ReadLine();

                            if (yesOrNo.ToLower() == "ja" && yesOrNoTwo.ToLower() == "ja")
                            {
                                winner = _game.Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson); //Utser vinnaren

                                var addScores = new Scores(matchId, winner, firstPerson, secondPerson);

                                var returned = _game.CreateScores(addScores);

                                Console.WriteLine(returned);
                            }

                            else
                            {
                                Console.WriteLine($"Sätt om TOTAL resultatet för spelare {personOne}: ");
                                pointOne = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine($"Sätt om TOTAL resultatet för spelare {personTwo}: ");
                                pointTwo = Convert.ToInt32(Console.ReadLine());

                                winner = _game.Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson); //Utser vinnaren

                                var addScores = new Scores(matchId, winner, firstPerson, secondPerson);

                                var returned = _game.CreateScores(addScores);

                                Console.WriteLine(returned);
                            }
                        }

                        else
                        {
                            winner = _game.Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson); //Utser vinnaren

                            var addScores = new Scores(matchId, winner, firstPerson, secondPerson);

                            var returned = _game.CreateScores(addScores);

                            Console.WriteLine(returned);
                        }
                    }

                    else
                    {
                        Console.WriteLine("Matchen är redan spelad");
                    }
                }

                catch (FormatException) //Fel format hantering
                {
                    Console.WriteLine("Du kan bara skriva in siffror..");
                }
            }
        }

        private void WinnersInGames()
        {
            Console.WriteLine("MatchId:");
            try
            {
                var input = Convert.ToInt32(Console.ReadLine());

                var items = _game.GetGameScores(input);

                if (items.GameNumber != 0) Console.WriteLine($"På match nummer: {items.GameNumber} så blev vinnaren {items.Winner}");
                else Console.WriteLine("Denna match är inte spelad ännu");
            }

            catch (FormatException)
            {
                Console.WriteLine("Du kan bara skriva in siffror..");
            }
        }

        private bool GameChallenge(string first, string last, int contestNr)
        {
            var isTrue = false;

            Console.WriteLine("Välj bland följande matcher som du vill spela i?");
            var getGames = _game.GetContests();

            foreach (var games in getGames)
            {
                Console.WriteLine($"{games.Name} ---- Avslutas {games.Ending}");
            }

            var name = Console.ReadLine();

            foreach (var existing in getGames)
            {
                if (existing.Name.ToLower() == name.ToLower())
                {
                    isTrue = true;
                }
            }

            if (isTrue == true)
            {
                var returned = NotChallenged(name.ToLower(), first.ToLower(), last.ToLower(), contestNr);
            }

            else Console.WriteLine("Antingen har tävlingen avslutats eller så finns den inte");

            return true;
        }

        private bool NotChallenged(string name, string first, string last, int contestNr)
        {
            var yourValues = contestNr + " " + first.ToLower() + " " + last.ToLower();
            var count = 0;
            var personsName = "";
            var isNull = 0;

            var personList = _game.GetPersons();

            var gameList = _game.GetGames();

            string[] arrayValue = new string[300];
            int i = 0;
            var isGame = 0;

            foreach (var item in gameList)
            {
                if (item.PersonOne.ToLower() == yourValues.ToLower()) //Kollar om du är på plats 1
                {
                    arrayValue[i] = item.PersonTwo.ToLower();
                    count++;
                    i++;
                }

                else if (item.PersonTwo.ToLower() == yourValues.ToLower()) //Kollar om du är på plats 2
                {
                    arrayValue[i] = item.PersonOne.ToLower();
                    count++;
                    i++;
                }
                isGame = 1;
            }

            if (isGame == 1)
            {
                if (count >= 10)
                {
                    Console.WriteLine("Du har redan {0} matcher, vill du skriva upp dig för att kunna spela {1}?", count, count + 1);
                    var value = Console.ReadLine();

                    if (value.Contains("Ja"))
                    {
                        var items = _game.PathWriting(first, last, count + 1, contestNr);
                        Console.WriteLine(items);
                        var builder = _game.RequestMessageToSystem(first, last, contestNr);
                    }
                }

                else
                {
                    foreach (var values in personList.Distinct())
                    {
                        var number = values.ContestNumber;

                        var other = number + " " + values.FirstName.ToLower() + " " + values.LastName.ToLower();

                        arrayValue[i + 1] = yourValues.ToLower();
                        var isTrue = arrayValue.Contains(other.ToLower());

                        if (isTrue == true)
                        {
                            count++;
                        }
                        else
                        {
                            Console.WriteLine($"Välj: {values.ContestNumber} Om du vill möta {values.FirstName} {values.LastName}");
                        }
                    }
                }

                isNull = 1;

            }

            if (isNull == 0) //Om inga spel finns!
            {
                foreach (var values in personList.Distinct())
                {
                    if (values.ContestNumber != contestNr)
                    {
                        Console.WriteLine("Välj: {0} Om du vill möta {1} {2}", values.ContestNumber, values.FirstName, values.LastName);
                    }
                }
            }
            try
            {
                if (count < 10) //Kolla om matcher är mindre än 10
                {
                    isNull = 1;

                    var id = int.Parse(Console.ReadLine());

                    foreach (var foreachs in personList)
                    {
                        if (foreachs.ContestNumber == id)
                        {
                            personsName = foreachs.ContestNumber + " " + foreachs.FirstName.ToLower() + " " + foreachs.LastName.ToLower();
                        }
                    }

                    //Kolla om personen har matcher med den utvalda!
                    foreach (var items in gameList)
                    {
                        if (items.PersonOne.ToLower() == yourValues.ToLower() && items.PersonTwo.ToLower() == personsName.ToLower() ||
                            items.PersonTwo.ToLower() == yourValues.ToLower() && items.PersonOne.ToLower() == personsName.ToLower())
                        {
                            isNull = 0;
                            Console.WriteLine("Du har redan en match med den utvalda personen!");
                            return false;
                        }

                        else if (items.PersonOne.ToLower() == yourValues.ToLower() && items.PersonTwo.ToLower() == yourValues.ToLower())
                        {
                            isNull = 0;
                            Console.WriteLine("Du kan inte ha en match med dig själv....");
                            return false;
                        }
                    }

                    if (isNull == 1)
                    {
                        var getNumber = 0;

                        foreach (var number in gameList)
                        {
                            if (getNumber < number.GameNumber)
                            {
                                getNumber = number.GameNumber;
                            }
                        }

                        var countings = getNumber + 1;


                        var value = new Game(name, countings, yourValues, personsName); //email

                        var addingToGame = _game.GameToFile(value);

                        Console.WriteLine("Välj vilken bowlinghall ni ska spela på: ");
                        Console.WriteLine("1) Bowling Discos");
                        Console.WriteLine("2) Monas bowlinghall");
                        Console.WriteLine("3) LunaBowl");
                        Console.Write("Ange antingen nummer eller namn: ");
                        var input = Console.ReadLine();

                        PathCompound enviro = new PathCompound(input);
                        enviro.Display();

                        var addingToPath = _game.PathToFile(getNumber, yourValues, personsName, input, enviro._paths);
                    }
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Du kan bara skriva in siffror..");
            }

            return true;
        }

        private void AddOnGame()
        {
            List<Person> people = new List<Person>();
            var contestNr = 0;

            Console.Write("Ditt förnamn: ");
            var first = Console.ReadLine();

            Console.Write("Ditt efternamn:");
            var second = Console.ReadLine();

            var list = _game.GetPersons();

            foreach (var item in list)
            {
                if (item.FirstName.ToLower() == first.ToLower() && item.LastName.ToLower() == second.ToLower())
                {
                    people.Add(item);
                    contestNr = item.ContestNumber;
                }
            }

            if (people.Count >= 1)
            {
                if (people.Count > 1)
                {
                    Console.Write("Mer än 1 person med detta för- och efternamn. Skriv in ditt tävlingsnummer: ");
                    contestNr = Convert.ToInt32(Console.ReadLine());
                }

                foreach (var find in people)
                {
                    if (find.ContestNumber == contestNr)
                    {
                        GameChallenge(first.ToLower(), second.ToLower(), contestNr);//Personen ska lägga till sig på matcher
                    }
                }
            }

            else if (people.Count == 0)
            {
                Console.WriteLine("Ingen person hittades!");
            }
        }

        private void ReadContests()
        {
            var list = _game.GetContests();

            Console.WriteLine("Tävlingar som pågår just nu:");

            foreach (var values in list)
            {
                Console.WriteLine($"{values.Name} startar {values.Start} och avslutas {values.Ending}");
            }
        }

        private void GameHandler(int choosing) //Admin
        {
            Console.Write("Din epostadress: ");
            var email = Console.ReadLine();

            Administrator adminUser = Administrator.GetInstance(); //Singelton

            var count = 0;

            if (adminUser.IsAdmin(email))
            {
                count = 1;
            }

            else
            {
                Console.WriteLine("Oops... Ingen admin med denna information finns");
            }


            if (count == 1 && choosing == 0) //Matchhantering. Lägg till tävling, Para personer i request listan
            {
                Console.WriteLine("1) Para ihop personer från Request?");
                Console.WriteLine("2) Lägg till tävling? ");
                var reader = Console.ReadLine();

                var existingGames = _game.GetGames();

                if (reader == "1")
                {
                    var requests = _game.AnyRequest();

                    if (requests.Count() > 2)
                    {
                        MatchRequests(existingGames);
                    }
                }
                else if (reader == "2") AddContest();
            }


            if (count == 1 && choosing == 1)
                PayedUser();

        }

        private void MatchRequests(IEnumerable<Game> gameList)
        {
            string[] arrayValue = new string[300];
            string[] gameValue = new string[300];
            int i = 0;

            foreach (var item in gameList)
            {
                arrayValue[i] = item.PersonOne.ToLower();
                i++;
                arrayValue[i] = item.PersonTwo.ToLower();
                i++;
            }

            foreach (var values in arrayValue.Distinct()) //Tar bort alla dubbletta värden och säger till vem användaren kan välja
            {
                var person = Regex.Replace(values, @"[\d-]", "");
                var id = Int32.Parse(values);

                Console.WriteLine($"Ange: {id} för person: {person}");
            }
            try
            {
                var reader = Int32.Parse(Console.ReadLine());
                i = 0;
                var getNumber = 0;
                string personValue = "";
                string opponentValue = "";

                var persons = _game.GetPersons();

                foreach (var item in persons)
                {
                    if (reader == item.ContestNumber)
                    {
                        personValue = $"{item.ContestNumber} {item.FirstName} {item.LastName}";
                    }
                }

                foreach (var item in gameList)
                {
                    if (item.PersonOne.ToLower() == personValue.ToLower()) //Kollar om personen är på plats 1
                    {
                        gameValue[i] = item.PersonTwo.ToLower();
                        i++;
                    }

                    else if (item.PersonTwo.ToLower() == personValue.ToLower()) //Kollar om personen är på plats 2
                    {
                        gameValue[i] = item.PersonOne.ToLower();
                        i++;
                    }
                }

                foreach (var games in gameValue) //Få ut personens id
                {
                    var person = Regex.Replace(games, @"[\d-]", "");
                    var id = Int32.Parse(games);

                    Console.WriteLine($"Ange: {id} för person: {person}");
                }

                var opponent = Int32.Parse(Console.ReadLine());

                foreach (var item in persons)
                {
                    if (item.ContestNumber == opponent)
                    {
                        Console.WriteLine("Välj bland följande matcher som personerna vill spela i?");
                        var getGames = _game.GetContests();

                        foreach (var games in getGames)
                        {
                            Console.WriteLine($"{games.Name} ---- Avslutas {games.Ending}");
                        }

                        var name = Console.ReadLine();

                        foreach (var number in gameList)
                        {
                            if (getNumber < number.GameNumber)
                            {
                                getNumber = number.GameNumber;
                            }
                        }

                        var countings = getNumber + 1;


                        var value = new Game(name, countings, personValue, opponentValue); //email

                        var addingToGame = _game.GameToFile(value);

                        Console.WriteLine("Välj vilken bowlinghall personerna ska spela på: ");
                        Console.WriteLine("1) Bowling Discos");
                        Console.WriteLine("2) Monas bowlinghall");
                        Console.WriteLine("3) LunaBowl");
                        Console.Write("Ange antingen nummer eller namn: ");
                        var input = Console.ReadLine();

                        PathCompound enviro = new PathCompound(input);
                        enviro.Display();

                        var addingToPath = _game.PathToFile(getNumber, personValue, opponentValue, input, enviro._paths);
                    }
                }
            }
            catch (FormatException) //Fel format hantering
            {
                Console.WriteLine("Du kan bara skriva in siffror.. :)");
            }

        }

        private void AddContest()
        {
            Console.Write("Vill du lägga till en match?");
            var answer = Console.ReadLine();

            if (answer.Contains("Ja"))
            {
                Console.Write("Namn på tävlingen: ");
                var name = Console.ReadLine();

                Console.WriteLine("Startar: ");
                var startDate = Console.ReadLine();

                Console.WriteLine("Slutar: ");
                var endDate = Console.ReadLine();

                Console.WriteLine("Hur ska vinnaren i en match utses?");
                Console.WriteLine("1) Högsta poäng per rond?");
                Console.WriteLine("2) Total poäng totalt i alla tre omgångar?");
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());

                    var contestDesider = "";

                    if (input == 1) contestDesider = "Högsta poäng per rond";
                    if (input == 2) contestDesider = "Total poäng i alla tre omgångar";

                    var values = new Contest(name, Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), contestDesider);

                    var printed = _game.AddContest(values);

                    Console.WriteLine(printed);
                }

                catch (FormatException) //Fel format hantering
                {
                    Console.WriteLine("Du kan bara skriva in siffror..");
                }
            }
        }

        private void PayedUser()
        {
            Console.WriteLine("Nummer på användaren som betalat: ");
            int getNumber = 0;
            var firstname = "";
            var lastname = "";
            var emailaddress = "";

            var lists = _game.PayFee();
            var players = _game.GetPersons();

            var count = lists.Count();

            if (count == 0)
            {
                Console.WriteLine("Finns inga personer som inte har betalat");
            }
            else
            {
                foreach (var items in lists)
                {
                    Console.WriteLine($"Ange: {items.ContestNumber} Om denna person betalat: {items.FirstName} {items.LastName} med epostadressen {items.Email}");
                }

                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());

                    List<Person> NewItems = new List<Person>();

                    foreach (var values in lists)
                    {
                        if (values.ContestNumber == input)
                        {
                            foreach (var number in players) //Från PayFee
                            {
                                if (getNumber < number.ContestNumber)
                                {
                                    getNumber = number.ContestNumber;
                                }

                                firstname = values.FirstName;
                                lastname = values.LastName;
                                emailaddress = values.Email;
                            }

                            var counting = proxy.Add(getNumber, 1);

                            var personValues = new Person(Convert.ToInt32(counting), firstname, lastname, emailaddress);
                            var addedToMember = _game.AddPerson(personValues);
                        }

                        else
                        {
                            NewItems.Add(values);
                        }
                    }
                    //Tar bort personen från PayFee filen!
                    if (NewItems.Count > 0)
                    {
                        var returned = _game.RemoveFromFee(NewItems);
                        Console.WriteLine(returned);
                    }
                }

                catch (FormatException) //Fel format hantering
                {
                    Console.WriteLine("Du kan bara skriva in siffror.. :)");
                }
            }
        }

        private void SearchGame()
        {
            Console.Write("Match nummer:");

            try
            {
                var id = int.Parse(Console.ReadLine());

                var gameBack = _game.GetMatches(id);

                if (gameBack.GameNumber != 0)
                {
                    Console.WriteLine($"{gameBack.PersonOne} möter {gameBack.PersonTwo} hos {gameBack.Place} på bana nummer: {gameBack.PathOnPlace}");
                }

                else Console.WriteLine("Finns ingen match med detta nummer");

            }
            catch (FormatException) //Fel format hantering
            {
                Console.WriteLine("Du kan bara skriva in siffror..");
            }
        }

        private void ReadGames()
        {
            var list = _game.GetGames();

            foreach (var values in list)
            {
                var personOne = Regex.Replace(values.PersonOne, @"[\d-]", "");
                var personTwo = Regex.Replace(values.PersonTwo, @"[\d-]", "");

                Console.WriteLine($"Tävlande i cupen {values.Name} med match nummer {values.GameNumber}: {personOne} och {personTwo}");
            }
            Console.WriteLine("**********************************************************************************");
        }

        private void ReadPeople()
        {
            var list = _game.GetPersons();

            Console.WriteLine("Alla deltagare:");

            foreach (var values in list)
            {
                Console.WriteLine($"Personen {values.FirstName} {values.LastName} Tävlar med nummer: {values.ContestNumber}");
            }
        }

        private void Register(string value)
        {
            var input = value.ToLower();

            if (input.Contains("nej")) AddPersons();
        }

        private void AddPersons()
        {
            var output = _game.NewPerson();
            Console.WriteLine(output);
        }
    }
}
