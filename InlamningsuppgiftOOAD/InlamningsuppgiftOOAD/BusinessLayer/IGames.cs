using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.BusinessLayer
{
    public interface IGames
    {
        string NewPerson(); //Registrera

        string NewPerson(Person person);

        IEnumerable<Person> GetPersons();

        IEnumerable<Game> GetGames();

        PathClass GetMatches(int matchId);

        Scores GetGameScores(int matchId);

        IEnumerable<Request> AnyRequest();

        List<ScoreStatus> GetWinner();

        IEnumerable<Contest> GetContests();

        string AddContest(Contest contest);

        IEnumerable<Game> GetGamesOnName(string name);

        bool Existing(int matchId);

        Game GameToFile(Game game);

        bool GameUnitToFile(Game game);

        IEnumerable<Person> PayFee();

        string AddPerson(Person person);

        string RemoveFromFee(List<Person> person);

        string PathWriting(string first, string last, int row, int contestNumber);

        string RequestMessageToSystem(string first, string last, int contestNr);

        string PathToFile(int number, string personOne, string personTwo, string path, int enviroPath);

        string CreateScores(Scores values); //Val 7 när resultat ska göras

        string Calculator(int roundOne, int roundTwo, int pointOne, int pointTwo, string firstPerson, string secondPerson);

        string GetWinnerOfSpecificContest(string name);
    }
}
