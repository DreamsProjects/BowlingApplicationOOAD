using PersonHolder.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningsuppgiftOOAD.DataLayer
{
    public interface IPersonRepo
    {
        string NewPerson(); //Registrera

        IEnumerable<Person> GetPersons(); //Val 0

        IEnumerable<Person> PayFee();

        string AddPerson(Person person);

        string RemoveFromFee(List<Person> person);

        IEnumerable<Request> AnyRequest();

        string NewPerson(Person person);
    }
}
