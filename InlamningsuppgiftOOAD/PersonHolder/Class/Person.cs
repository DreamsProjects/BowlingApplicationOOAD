using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHolder.Class
{
    public class Person
    {
        public int ContestNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public Person()
        {
        }

        public Person(int personId, string firstName, string lastName, string email)
        {
            ContestNumber = personId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return ContestNumber + ";" + FirstName + ";" +
                   LastName + ";" + Email;
        }
    }
}
