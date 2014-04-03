using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Program
    {
        static void Main(string[] args)
        {
           IPersonAccessor pa = new DBPersonAccessor();
            foreach (Person p in pa.GetAll())
                Console.WriteLine("{0}    {1}    {2}",p.FullName, p.Id, p.BirthDate.ToShortDateString());
             
            foreach (Person p in pa.GetByName("Петров"))
                Console.WriteLine("{0}    {1}    {2}", p.FullName, p.Id, p.BirthDate.ToShortDateString());
            pa.DeleteByName("Петров");
            pa.Insert(new Person(5, "Бондаренко Р.А.", DateTime.Parse("01.01.1985")));

            foreach (Person p in pa.GetAll())
                Console.WriteLine("{0}    {1}    {2}",p.FullName, p.Id, p.BirthDate.ToShortDateString());
            Console.ReadKey(); 
        }
    }
}
