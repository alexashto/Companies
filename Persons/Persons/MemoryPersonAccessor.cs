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
            return MemoryDB.Database.FindAll(x => x.FullName.Contains(name));
        }

        public void DeleteByName(string name)
        {
            MemoryDB.Database.RemoveAll(x => x.FullName.Contains(name));
        }

        public void Insert(Person person)
        {
            MemoryDB.Database.Add(person);
        }
    }
}
