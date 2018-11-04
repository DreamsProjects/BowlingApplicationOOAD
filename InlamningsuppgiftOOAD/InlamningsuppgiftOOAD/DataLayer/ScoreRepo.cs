using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace InlamningsuppgiftOOAD.DataLayer
{
    public class ScoresRepo : IScoreRepo
    {
        PersonCollection PersonCollection = new PersonCollection();
        GameCollection GameCollection = new GameCollection();
        ScoreCollections ScoreCollection = new ScoreCollections();
        ContestCollection ContestCollection = new ContestCollection();
        RequestCollections RequestCollections = new RequestCollections();
        PathCollections PathCollection = new PathCollections();
        PayFeeCollection PayFeeCollection = new PayFeeCollection();
        StringBuilder Builder = new StringBuilder();

        public string FilePath = @"C:\Users\emma\source\repos\InlamningsuppgiftOOAD\InlamningsuppgiftOOAD\Files\Logger.txt";

        public string GetWinnerOfSpecificContest(string name)
        {
            List<Scores> ScoresList = new List<Scores>();
            List<Game> GamesList = new List<Game>();
            List<ScoreStatus> ScoresStatusList = new List<ScoreStatus>();

            ScoreCollection.Reading(); //läser in användarna
            GameCollection.Reading(); //läser in alla matcher
            PersonCollection.Reading();

            var getScores = ScoreCollection.GetEnumerator();
            var getGames = GameCollection.GetEnumerator();
            var getAllPersons = PersonCollection.GetEnumerator();

            foreach (var items in getScores)
            {
                ScoresList.Add(items);
            }

            foreach (var items in getGames)
            {
                if (items.Name == name)
                {
                    GamesList.Add(items);
                }
            }

            var percentage = 0.0;
            var amountScores = 0; //Hur många gånger en person återkommer i Gamesfilen
            var amountGames = 0;

            foreach (var items in getAllPersons)
            {
                var text = $"{items.ContestNumber} {items.FirstName} {items.LastName}";

                amountScores = ScoresList.Where(x => x.Winner == text).Count();

                amountGames = GamesList.Where(x => x.PersonOne == text || x.PersonTwo == text).Count();

                // Create math proxy
                MathProxy proxy = new MathProxy();

                if (amountGames >= 10)
                {
                    if (amountScores == 0)
                        percentage = proxy.Mul(amountScores, amountGames);

                    percentage = proxy.Div((amountScores * 100), amountGames);

                    var ScoresStatus = new ScoreStatus(amountGames, amountScores, items.FirstName, items.LastName, percentage, items.ContestNumber);
                    ScoresStatusList.Add(ScoresStatus);
                }
            }


            if (ScoresStatusList.Count > 0)
            {
                var sort = ScoresStatusList.OrderByDescending(x => x.Percentage).FirstOrDefault();

                //return $"Årets champion: {sort.FirstName} {sort.LastName} vinnar andel: {sort.Percentage}%";
                return $"{sort.ContestNumber} {sort.FirstName} {sort.LastName}";
            }
            else
            {
                return "Ingen användare har spelat mer än 10 matcher";
            }

        }

        public bool GameUnitToFile(Game game)
        {
            var value = GameCollection.Writing(game);

            return value;
        }

        public Game GameToFile(Game game)
        {
            GameCollection.Writing(game);

            return game;
        }

        public string PathToFile(int number, string personOne, string personTwo, string path, int enviroPath)
        {
            PathCollection.Writing(number, personOne, personTwo, path, enviroPath);

            Builder.Append($"\n{DateTime.Now} - Användaren {personOne} har skrivit upp sig på en match med {personTwo} ");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return "";
        }

        public IEnumerable<Game> GetGames()
        {
            GameCollection.Reading();
            var list = GameCollection.GetEnumerator();

            Builder.Append($"\n{DateTime.Now} - Användare får alla matcher utskrivna");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return list;
        }

        public PathClass GetMatches(int matchId)
        {
            PathCollection.Find();
            var list = PathCollection.GetEnumerator();
            PathClass game = new PathClass();

            foreach (var items in list)
            {
                if (items.GameNumber == matchId)
                {
                    game = items;
                }
            }

            if (game != null)
            {
                Builder.Append($"\n{DateTime.Now} - Användare söker match efter med id: {matchId}");
            }

            else Builder.Append($"\n{DateTime.Now} - Användare sökte efter ett ogiltigt match nummer");

            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return game;
        }

        public IEnumerable<Contest> GetContests()
        {
            ContestCollection.Reading();

            var list = ContestCollection.GetEnumerator();

            foreach (var values in list)
            {
                if (DateTime.Now > values.Ending) //Om dagens datum är större än när tävlingen avslutas
                {
                    ContestCollection.RemoveContest(values);
                }
            }

            Builder.Append($"\n{DateTime.Now} - Användaren får alla tävlingar utskrivna ");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return ContestCollection.GetEnumerator();
        }

        public Scores GetGameScores(int matchId)
        {
            ScoreCollection.Reading();
            var scoresList = ScoreCollection.GetEnumerator();
            Scores selected = new Scores();

            foreach (var items in scoresList)
            {
                if (items.GameNumber == matchId)
                    selected = items;
            }

            Builder.Append($"\n{DateTime.Now} - Användare får en match med nummer: {matchId}  utskrivet ");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return selected;
        }

        public List<ScoreStatus> GetWinner() //kan vara fler än en vinnare 
        {
            List<Scores> ScoresList = new List<Scores>();
            List<Game> GamesList = new List<Game>();
            List<ScoreStatus> ScoresStatusList = new List<ScoreStatus>();

            ScoreCollection.Reading(); //läser in användarna
            GameCollection.Reading(); //läser in alla matcher
            PersonCollection.Reading();

            var getScores = ScoreCollection.GetEnumerator();
            var getGames = GameCollection.GetEnumerator();
            var getAllPersons = PersonCollection.GetEnumerator();

            foreach (var items in getScores)
            {
                ScoresList.Add(items);
            }

            foreach (var items in getGames)
            {
                GamesList.Add(items);
            }

            var percentage = 0.0;
            var amountScores = 0; //Hur många gånger en person återkommer i Gamesfilen
            var amountGames = 0;

            foreach (var items in getAllPersons)
            {
                var text = $"{items.ContestNumber} {items.FirstName} {items.LastName}";

                amountScores = ScoresList.Where(x => x.Winner == text).Count();

                amountGames = GamesList.Where(x => x.PersonOne == text || x.PersonTwo == text).Count();

                // Create math proxy
                MathProxy proxy = new MathProxy();

                if (amountGames >= 10)
                {
                    if (amountScores == 0)
                        percentage = proxy.Mul(amountScores, amountGames);

                    percentage = proxy.Div((amountScores * 100), amountGames);

                    var ScoresStatus = new ScoreStatus(amountGames, amountScores, items.FirstName, items.LastName, percentage, items.ContestNumber);
                    ScoresStatusList.Add(ScoresStatus);
                }
            }

            Builder.Append($"\n{DateTime.Now} - Användaren får den slutgiltiga vinnaren utskriven ");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return ScoresStatusList;
        }

        public IEnumerable<Game> GetGamesOnName(string name)
        {
            GameCollection.Reading();
            ScoreCollection.Reading();

            var games = GameCollection.GetEnumerator();
            var scores = ScoreCollection.GetEnumerator();
            var arrayValue = new int[300];

            List<Game> unplayedGames = new List<Game>();
            int i = 0;

            foreach (var scoreValues in scores)
            {
                arrayValue[i] = scoreValues.GameNumber;
                i++;
            }

            foreach (var gameValues in games)
            {
                if (!arrayValue.Contains(gameValues.GameNumber))
                {
                    unplayedGames.Add(gameValues);
                }
            }


            return unplayedGames;
        }

        public bool Existing(int id)
        {
            var number = true;

            var selected = GetGameScores(id);

            if (selected.GameNumber != 0)
            {
                number = false;
            }

            return number;
        }

        public string CreateScores(Scores scores)
        {
            var number = scores.GameNumber;
            var winner = scores.Winner;

            var newScore = new Scores(number, winner);

            ScoreCollection.Writing(newScore);

            var personOne = Regex.Replace(scores.PersonOne, @"[\d-]", "");
            var personTwo = Regex.Replace(scores.PersonTwo, @"[\d-]", "");

            Builder.Append($"\n{DateTime.Now} -Mellan spelare 1: {personOne} spelare 2: {personTwo} blev vinnaren: {scores.Winner} ");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return $"Vinnaren blev {scores.Winner}";
        }

        public string Calculator(int roundOne, int roundTwo, int pointOne, int pointTwo, string firstPerson, string secondPerson)
        {
            var winner = "";

            MathProxy proxy = new MathProxy();

            var one = proxy.Sub(pointOne, pointTwo);
            var two = proxy.Sub(pointTwo, pointOne);

            if (roundOne == 0 && roundTwo == 0) //Om totalpoäng för spelet
            {
                if (one > two) winner = firstPerson;

                else if (two > one) winner = secondPerson;
            }

            else
            {
                if (roundOne > roundTwo) winner = firstPerson;
                else if (roundTwo > roundOne) winner = secondPerson;
            }

            return winner;
        }

        public string RequestMessageToSystem(string first, string last, int contestNr)
        {
            var values = Builder.Append($"\n{DateTime.Now} - Användaren {first} {last} med tävlingsnummer {contestNr} är uppskriven i Request-filen för att spela ytterliggare en match över 10 ");
            File.AppendAllText(FilePath, values.ToString());
            Builder.Clear();

            return values.ToString();
        }

        public string PathWriting(string first, string last, int row, int contestNumber)
        {
            var items = new Request(first, last, row, contestNumber);
            RequestCollections.Writing(items);

            return "Du är uppskriven på att spela ytterliggare en match";
        }

        public string AddContest(Contest contest)
        {
            ContestCollection.Writing(contest);

            Builder.Append($"\n{DateTime.Now} - Admin har lagt till en ny tävling i cupen.");
            File.AppendAllText(FilePath, Builder.ToString());
            Builder.Clear();

            return $"{contest.Name} är tilllagd i tävlingslistan";
        }
    }
}
