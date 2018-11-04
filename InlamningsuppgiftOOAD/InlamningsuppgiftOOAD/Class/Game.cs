
namespace InlamningsuppgiftOOAD.Class
{
    public class Game : Contest
    {
        public int GameNumber { get; set; }

        public string PersonOne { get; set; }

        public string PersonTwo { get; set; }

        public Game()
        { }

        public Game(string match, int gameNumber, string personone, string persontwo)
        {
            Name = match;
            GameNumber = gameNumber;
            PersonOne = personone;
            PersonTwo = persontwo;
        }

        public override string ToString()
        {
            return Name + ";" + GameNumber + ";" + PersonOne + ";" + PersonTwo + ";";
        }
    }
}
