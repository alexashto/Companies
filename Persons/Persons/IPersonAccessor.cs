using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    interface IPersonAccessor
    {
        List<Person> GetAll();
        List<Person> GetByName(string name);
        void DeleteByName(string name);
        void Insert(Person person);
    }
}
