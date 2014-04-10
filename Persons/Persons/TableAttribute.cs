using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class TableAttribute : Attribute
    {
        public string  TableName { get; set; }
        public TableAttribute(string name)
        {
            TableName = name;
        }

        public TableAttribute()
        {

        }
    }
}
