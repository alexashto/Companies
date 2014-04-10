using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.DataEntity;

namespace Persons.Accessors
{
    public interface IEntityAccessor<T> where T: BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void DeleteById(int id);
        void Insert(T item);
    }
}
