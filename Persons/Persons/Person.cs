using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(int id, string fullName, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
        }
    }
}
