using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    
    record Person(string FirstName, string LastName);
    record Pet(string Name, Person Owner);
    record Employee(string FirstName, string LastName, int EmployeeID);
    record Cat(string Name, Person Owner) : Pet(Name, Owner);
    record Dog(string Name, Person Owner) : Pet(Name, Owner);

    record Product(string Name, int CategoryID);
    record NewProduct(string PName, int CategoryID);
    record Category(string Name, int ID);
}
