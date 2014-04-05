using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class MemoryPersonAccessor : IPersonAccessor
    {
 

        public List<Person> GetAll()
        {
            return MemoryDB.Database;
        }

        public List<Person> GetByName(string name)
        {
            return MemoryDB.Database.FindAll(x => x.FullName.Contains(name));
        }

        public void DeleteById(int id)
        {
            MemoryDB.Database.RemoveAll(x => x.Id.Equals(id));
        }

        public void Insert(Person person)
        {
            MemoryDB.Database.Add(person);
        }


        public Person GetById(int id)
        {
            return MemoryDB.Database.Find(x => x.Id.Equals(id));
        }


    }
}
