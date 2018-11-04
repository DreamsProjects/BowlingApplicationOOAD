using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class ScoreStatus : Person
    {
        public int AmountOfGames { get; set; }

        public int AmountOfWins { get; set; }

        public double Percentage { get; set; }

        public ScoreStatus()
        {
        }

        public ScoreStatus(int amountOfGames, int amountOfWins, string person, string personlast, double percent, int personId)
        {
            AmountOfGames = amountOfGames;
            AmountOfWins = amountOfWins;
            FirstName = person;
            LastName = personlast;
            Percentage = percent;
            ContestNumber = personId;
        }
    }
}
