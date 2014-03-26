using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class MemoryPersonAccessor : IPersonAccessor
    {
        public List<Person> GetAll()
        {
            return MemoryDB.Database;
        }

        public List<Person> GetByName(string name)
        {

            return (List <Person>) MemoryDB.Database.Where(p => p.FullName == name);
        }

        public void DeleteByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
