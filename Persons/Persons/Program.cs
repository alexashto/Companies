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
 

         
           
            //
            //pa.Insert(new Person("Бондаренко Р.А.", 25));

            Console.WriteLine();

            foreach (Person p in pa.GetAll())
                Console.WriteLine("{0}    {1}    {2}",p.FullName, p.Id, p.Age.ToString());

            Console.WriteLine();

            Person prs = pa.GetById(1);



             
            Console.WriteLine("{0}    {1}    {2}", prs.FullName, prs.Id, prs.Age.ToString());



            Console.ReadKey();
        }
    }
}
