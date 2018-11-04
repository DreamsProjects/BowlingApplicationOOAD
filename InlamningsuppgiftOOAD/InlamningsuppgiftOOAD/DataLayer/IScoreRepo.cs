using InlamningsuppgiftOOAD.Class;
using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.DataLayer
{
    public interface IScoreRepo
    {
        IEnumerable<Game> GetGames(); //Val 1

        PathClass GetMatches(int matchId); //Val 2

        Scores GetGameScores(int matchId); //Val 3

        List<ScoreStatus> GetWinner(); //Val 4 -Årets vinnare

        IEnumerable<Contest> GetContests(); //Val 5

        string CreateScores(Scores values); //Val 7 när resultat ska göras

        IEnumerable<Game> GetGamesOnName(string name);

        bool Existing(int id);

        string Calculator(int roundOne, int roundTwo, int pointOne, int pointTwo, string firstPerson, string secondPerson);

        Game GameToFile(Game game);

        bool GameUnitToFile(Game game);

        string PathToFile(int number, string personOne, string personTwo, string path, int enviroPath);

        string RequestMessageToSystem(string first, string last, int contestNr);

        string PathWriting(string first, string last, int row, int contestNumber);

        string AddContest(Contest contest);

        string GetWinnerOfSpecificContest(string name);
    }
}
