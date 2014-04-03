using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;


namespace Persons
{
    class XMLPersonAccessor : IPersonAccessor
    {

        private List<Person> personList;
        private string fileName;

        public XMLPersonAccessor(string fileName)
        {
            this.fileName = fileName;
        }

        private void SaveToXML()
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                xmlSerializer.Serialize(fileStream, personList);
            }
        }

        private List<Person> loadFromXML()
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                personList = (List<Person>)xmlSerializer.Deserialize(fileStream);
                return personList;
            }
        }

        public List<Person> GetAll()
        {
            return loadFromXML();
        }

        public List<Person> GetByName(string name)
        {
            personList = loadFromXML();
            return personList.FindAll(x => x.FullName.Contains(name));
        }

        public void DeleteByName(string name)
        {
            personList = loadFromXML();
            personList.RemoveAll(x => x.FullName.Contains(name));
            SaveToXML();
        }

        public void Insert(Person person)
        {
            personList = loadFromXML();
            personList.Add(person);
            SaveToXML();
        }
    }
}
