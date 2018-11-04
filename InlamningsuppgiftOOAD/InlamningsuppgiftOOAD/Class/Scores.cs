using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class Scores : Game
    {
        public string Winner { get; set; }

        public Scores()
        { }

        public Scores(int gameNumber, string winner, string personOne, string personTwo)
        {
            GameNumber = gameNumber; //Från Game
            Winner = winner;
            PersonOne = personOne;
            PersonTwo = personTwo;
        }

        public Scores(int gameNumber, string winner)
        {
            GameNumber = gameNumber; //Från Game
            Winner = winner;
        }


        public override string ToString()
        {
            return GameNumber + ";" + Winner;
        }
    }
}
