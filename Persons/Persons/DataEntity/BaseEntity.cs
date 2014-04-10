using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.DataEntity
{
    public class BaseEntity
    {
        [Field(FieldName = "IdField", FieldType = "int")]
        public int Id { get; set; }
    }
}
