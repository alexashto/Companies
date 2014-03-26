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

            new Person("Медведев В.В.", DateTime.Parse("01.02.1989")),
            new Person("Петров А.В.", DateTime.Parse("08.04.1991")),
            new Person("Сидоров Б.Е.", DateTime.Parse("31.12.1992")),
            new Person("Башилов В.П.", DateTime.Parse("25.11.1991")),
            new Person("Сорокин М.М.", DateTime.Parse("14.06.1991")),
            new Person("Шестаков Д.А.", DateTime.Parse("18.01.1988")),
            new Person("Демидов И.П.", DateTime.Parse("04.09.1990")),
            new Person("Досумов Ф.В.", DateTime.Parse("23.04.1991")),
            new Person("Андрианов Д.П.", DateTime.Parse("28.05.1989")),
            new Person("Голубев А.В.", DateTime.Parse("19.03.1992")),
        };


    }
}
