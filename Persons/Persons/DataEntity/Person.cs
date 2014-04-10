using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Persons.DataEntity
{
    
    [Table(TableName = "PersonTable")]
    public class Person : BaseEntity
    {


        [Field(FieldName = "NameField", FieldType = "string")]
        public string FullName { get; set; }

        [Field(FieldName = "AgeField", FieldType = "string")]
        public int Age { get; set; }

        public Person() { }

        public Person(int id, string fullName, int age)
        {
            Id = id;
            FullName = fullName;
            Age = age;
        }

        public Person(string fullName, int age) : this( 0, fullName, age )
	    {
                
	    }
    }
}
