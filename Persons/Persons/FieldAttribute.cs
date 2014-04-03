using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class FieldAttribute : Attribute
    {
        public string fieldName { get; set; }
        public Type fieldType { get; set; }

        public FieldAttribute() { }
    }
}
