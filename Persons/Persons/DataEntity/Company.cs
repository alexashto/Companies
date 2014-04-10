using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons.DataEntity
{
    [Table(TableName = "CompanyTable")]
    class Company
    {
        [Field(FieldName = "NameField", FieldType = "string")]
        public string Name { get; set; }

        [Field(FieldName = "AddressField", FieldType = "string")]
        public string Address { get; set; }
    }
}
