namespace InlamningsuppgiftOOAD.Class
{
    public class PathClass : Game
    {
        public string Place { get; set; }
        public int PathOnPlace { get; set; }

        public PathClass(int matchid, string personOne, string personTwo, string _name, int number)
        {
            GameNumber = matchid;
            PersonOne = personOne;
            PersonTwo = personTwo;
            Place = _name;
            PathOnPlace = number;
        }

        public PathClass()
        {
        }
    }
}
