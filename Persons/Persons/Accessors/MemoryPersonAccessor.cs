using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.DataEntity;
using Persons.Data;

namespace Persons.Accessors
{
    public class MemoryPersonAccessor<T> : IEntityAccessor<T> where T : Person
    {
        private List<T> persons = new List<T>();

        public MemoryPersonAccessor()
        {
            foreach (Person p in MemoryDB.Database)
            {
                persons.Add((T) p);
            }
        }


        public List<T> GetAll()
        {
            return persons;
        }


        public void DeleteById(int id)
        {
            persons.RemoveAll(x => x.Id.Equals(id));
        }

        public void Insert(T item)
        {
            persons.Add(item);
        }


        public T GetById(int id)
        {
            return persons.Find(x => x.Id.Equals(id));
        }


    }
}
