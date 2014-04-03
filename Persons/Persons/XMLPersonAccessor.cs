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
        private XmlDocument xmlDB = new XmlDocument();
        private XmlSerializer xmlSerializer;
        private List<Person> personList;
        private string fileName;

        public XMLPersonAccessor(string fileName)
        {
            this.fileName = fileName;
        }

        private void SaveToXML()
        {
             xmlSerializer = new XmlSerializer(typeof(Person));
             TextWriter writer = new StreamWriter(fileName);
             xmlSerializer.Serialize(writer, personList);
             writer.Close();
        }

        private List<Person> loadFromXML()
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            xmlSerializer = new XmlSerializer(typeof(Person));
            List<Person> resultPersonList = (List<Person>)xmlSerializer.Deserialize(fs);
            fs.Close();
            return resultPersonList;
        }

        public List<Person> GetAll()
        {
            personList = loadFromXML();
            return personList;
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
