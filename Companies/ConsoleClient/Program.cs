using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.Accessors;
using Persons.DataEntity;

namespace ConsoleClient
{
    class Program
    {

        static private int mode;
        static private int entity;

        static private void Mode()
        {
            Console.WriteLine(@"Выберите хранилище данных:
    1 - ОП
    2 - Файл
    3 - БД ADO.NET
    4 - БД MyORM");
            while (!Int32.TryParse(Console.ReadLine(), out mode) || !((mode > 0) && (mode < 5)) )
            {
                Console.WriteLine("Ошибка ввода");
            }
        }


        static private void Entity()
        {
            Console.WriteLine(@"Выберите сущность:
    1 - Персоны
    2 - Компании");
            while (!Int32.TryParse(Console.ReadLine(), out entity) || !((entity > 0) && (entity < 3)))
            {
                Console.WriteLine("Ошибка ввода");
            }
        }

        static private IEntityAccessor<BaseEntity> Accessor()
        {
            switch (mode)
            {
              
            }
        }


        static void Main(string[] args)
        {
            Mode();
            Console.ReadKey();
        }


    }
}
