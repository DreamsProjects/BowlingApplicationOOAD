using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class PathDesider
    {
        protected string _name { get; set; }
        public int _paths { get; set; }
        protected string _enviroment { get; set; }

        public PathDesider(string name)
        {
            _name = name;
        }

        public PathDesider()
        {
        }

        public virtual void Display()
        {
            if (_name == "1") _name = "bowling discos";
            else if (_name == "2") _name = "monas bowlinghall";
            else if (_name == "3") _name = "lunabowl";

            Console.WriteLine("Du valde platsen: {0}", _name);

        }
    }

    class PathCompound : PathDesider
    {
        private Paths _pathsComp;

        public PathCompound(string name)
            : base(name)
        {
        }

        public override void Display()
        {
            _pathsComp = new Paths();

            _paths = _pathsComp.GetPaths(_name);
            _enviroment = _pathsComp.GetName(_name);


            base.Display();
        }
    }

    class Paths
    {
        public int GetPaths(string enviromentName)
        {
            var rand = new Random();

            switch (enviromentName.ToLower())
            {
                case "bowling discos": return rand.Next(1, 7);
                case "monas bowlinghall": return 1;
                case "lunabowl": return rand.Next(1, 9);
                case "1": enviromentName = "bowling discos"; return rand.Next(1, 7);
                case "2": enviromentName = "monas bowlinghall"; return 1;
                case "3": enviromentName = "lunabowl"; return rand.Next(1, 10);
                default: return 1;
            }
        }

        public string GetName(string enviromentName)
        {
            switch (enviromentName.ToLower())
            {
                case "bowling discos": return "bowling discos";
                case "monas bowlinghall": return "monad bowlinghall";
                case "lunabowl": return "lunabowl";
                case "1": return "bowling discos";
                case "2": return "monad bowlinghall";
                case "3": return "lunabowl";
                default: return "lunabowl";
            }
        }
    }
}
