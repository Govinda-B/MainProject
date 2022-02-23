using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    class Classes
    {

    }
    record Person(string FirstName, string LastName);
    record Pet(string Name, Person Owner);
    record Employee(string FirstName, string LastName, int EmployeeID);
    record Cat(string Name, Person Owner) : Pet(Name, Owner);
    record Dog(string Name, Person Owner) : Pet(Name, Owner);
}
