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
            XMLPersonAccessor xmlpa = new XMLPersonAccessor("/db.xml");
        }
    }
}
