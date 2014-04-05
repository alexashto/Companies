using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public interface IPersonAccessor
    {
        List<Person> GetAll();
        List<Person> GetByName(string name);
        Person GetById(int id);
        void DeleteById(int id);
        void Insert(Person person);
    }
}
