using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Person
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }
    }
}
