using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class MemoryDB
    {
        public static List<Person> Database = new List<Person> {

            new Person(1 ,"Медведев В.В.", 20),
            new Person(2, "Петров А.В.", 25),
            new Person(3, "Сидоров Б.Е.", 24),
            new Person(4, "Петрова В.П.", 18),
            new Person(5, "Сорокин М.М.", 29),
            new Person(6, "Шестакова Д.А.", 20),
            new Person(7, "Демидов И.П.", 21),
            new Person(8, "Досумов Ф.В.", 24),
            new Person(9, "Андрианов Д.П.", 22),
            new Person(10, "Голубева А.В.", 22),
        };


    }
}
