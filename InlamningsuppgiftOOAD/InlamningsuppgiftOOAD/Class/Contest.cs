using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.Class
{
    public class Contest
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ending { get; set; }
        public string ContestDesider { get; set; }

        public Contest(string name, DateTime start, DateTime end, string contest)
        {
            Name = name;
            Start = start;
            Ending = end;
            ContestDesider = contest;
        }

        public Contest()
        {
        }


        public override string ToString()
        {
            return Name + ';' + Start + ';' + Ending + ';' + ContestDesider;
        }
    }
}
