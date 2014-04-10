using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.DataEntity;
using Persons.Accessors;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
            MyOrmAccessor<Person> pa = new MyOrmAccessor<Person>();

            foreach (Person p in pa.GetAll())
                Console.WriteLine("Id: {0}, Age: {1}, Name: {2}", p.Id, p.Age, p.FullName);


            pa.Insert(new Person("Кузнецова А.В.", 23));
            pa.DeleteById(2);
            Console.WriteLine();


            foreach (Person p in pa.GetAll())
                Console.WriteLine("Id: {0}, Age: {1}, Name: {2}", p.Id, p.Age, p.FullName);

            Console.ReadKey();
        }
    }
}
