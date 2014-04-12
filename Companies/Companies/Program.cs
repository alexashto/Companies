using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Companies.DataEntity;
using Companies.Accessors;

namespace Companies
{
    class Program
    {
        static void Main(string[] args)
        {
            IEntityAccessor<Company> ca = new XMLFileAccessor<Company>("db.xml");

            foreach (var c in ca.GetAll())
                WriteCompany(c);

            ca.Insert(new Company("ООО РСВ", "sadasd", "123123"));
            ca.Insert(new Company("asd asd", "cvb", "345"));

            Console.WriteLine();

            WriteCompany(ca.GetById(2));

            Console.WriteLine();

            ca.Insert(new Company(" cvbcvb", "cvbcvb", "cvbcvb"));

            Console.WriteLine();

            foreach (var c in ca.GetAll())
                WriteCompany(c);

            ca.DeleteById(3);
            Console.WriteLine();
            foreach (var c in ca.GetAll())
                WriteCompany(c);

            Console.ReadKey();
        }



        static void WriteEmployee(Employee e)
        {
            Console.WriteLine("Id: {0}, First Name: {1}, Last Name: {2}, Birth Date: {3}\nCompany Id: {4}, Position: {5}, Employment Date: {6}", 
                               e.Id, e.FirstName, e.LastName, e.BirthDate.ToShortDateString(), e.CompanyId, e.Position, e.EmploymentDate.ToShortDateString());
        }

        static void WriteCompany(Company c)
        {
            Console.WriteLine("Id: {0}, Name: {1}, Address: {2}, Phone: {3}", c.Id, c.Name, c.Address, c.Phone);
        }

    }


}
