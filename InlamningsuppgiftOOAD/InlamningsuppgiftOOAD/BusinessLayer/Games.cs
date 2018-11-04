using InlamningsuppgiftOOAD.Class;
using InlamningsuppgiftOOAD.DataLayer;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.BusinessLayer
{
    public class Games : IGames
    {
        private IPersonRepo _personRepo = new PersonRepo();
        private IScoreRepo _scoreRepo = new ScoresRepo();

        public string NewPerson(Person person)
        {
            return _personRepo.NewPerson(person);
        }

        public bool GameUnitToFile(Game game)
        {
            return _scoreRepo.GameUnitToFile(game);
        }

        public IEnumerable<Request> AnyRequest()
        {
            return _personRepo.AnyRequest();
        }

        public IEnumerable<Game> GetGamesOnName(string name)
        {
            return _scoreRepo.GetGamesOnName(name);
        }

        public string PathWriting(string first, string last, int row, int contestNumber)
        {
            return _scoreRepo.PathWriting(first, last, row, contestNumber);
        }

        public bool Existing(int id)
        {
            return _scoreRepo.Existing(id);
        }

        public string NewPerson()
        {
            return _personRepo.NewPerson();

        }

        public string RequestMessageToSystem(string first, string last, int contestNr)
        {
            return _scoreRepo.RequestMessageToSystem(first, last, contestNr);
        }

        public IEnumerable<Person> GetPersons()
        {
            return _personRepo.GetPersons();
        }

        public IEnumerable<Person> PayFee()
        {
            return _personRepo.PayFee();
        }

        public string AddPerson(Person person)
        {
            return _personRepo.AddPerson(person);
        }

        public string RemoveFromFee(List<Person> person)
        {
            return _personRepo.RemoveFromFee(person);
        }

        //Spelen och Scores

        public string AddContest(Contest contest)
        {
            return _scoreRepo.AddContest(contest);
        }

        public string PathToFile(int number, string personOne, string personTwo, string path, int enviroPath)
        {
            return _scoreRepo.PathToFile(number, personOne, personTwo, path, enviroPath);
        }

        public Game GameToFile(Game game)
        {
            return _scoreRepo.GameToFile(game);
        }

        public IEnumerable<Game> GetGames()
        {
            return _scoreRepo.GetGames();
        }

        public PathClass GetMatches(int matchId)
        {
            return _scoreRepo.GetMatches(matchId);
        }

        public Scores GetGameScores(int matchId)
        {
            return _scoreRepo.GetGameScores(matchId);
        }

        public string GetWinnerOfSpecificContest(string name)
        {
            return _scoreRepo.GetWinnerOfSpecificContest(name);
        }

        public List<ScoreStatus> GetWinner()
        {
            return _scoreRepo.GetWinner();
        }

        public IEnumerable<Contest> GetContests()
        {
            return _scoreRepo.GetContests();
        }

        public string CreateScores(Scores values)
        {
            return _scoreRepo.CreateScores(values);
        }

        public string Calculator(int roundOne, int roundTwo, int pointOne, int pointTwo, string firstPerson, string secondPerson)
        {
            return _scoreRepo.Calculator(roundOne, roundTwo, pointOne, pointTwo, firstPerson, secondPerson);
        }
    }
}
