using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class Request : Person
    {
        public int Games { get; set; }

        public Request(string name, string lastname, int game, int personId)
        {
            FirstName = name;
            LastName = lastname;
            Games = game;
            ContestNumber = personId;
        }

        public Request()
        {
        }

        public override string ToString()
        {
            return ContestNumber + ";" + FirstName + ';' + LastName + ';' + Games;
        }
    }
}
