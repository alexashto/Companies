using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Persons.DataEntity;


namespace Persons.Accessors
{
    class XMLPersonAccessor<T> : IEntityAccessor<T> where T : BaseEntity
    {

        private List<T> personList;
        private string fileName;

        public XMLPersonAccessor(string fileName)
        {
            this.fileName = fileName;
        }

        private void SaveToXML()
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                xmlSerializer.Serialize(fileStream, personList);
            }
        }

        private List<T> LoadFromXML()
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                personList = (List<T>)xmlSerializer.Deserialize(fileStream);
                return personList;
            }
        }

        public List<T> GetAll()
        {
            return LoadFromXML();
        }



        public void DeleteById(int id)
        {
            var item = GetById(id);
            personList.Remove(item);

            SaveToXML();
        }

        public void Insert(T item)
        {
            item.Id = this.personList.Any(x => true) ? this.personList.Select(x => x.Id).Max() + 1 : 1;
            personList.Add(item);

            SaveToXML();
        }


        public T GetById(int id)
        {
            return LoadFromXML().Find(x => x.Id == id);
        }


        
    }
}
