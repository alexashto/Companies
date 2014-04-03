using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace Persons
{
    class DBPersonAccessor : IPersonAccessor
    {
        private SqlCeConnection connection;

        public DBPersonAccessor()
        {
            connection = new SqlCeConnection("Data Source = AppDB.sdf; Password = ''");

            connection.Open();
        }

     /*   ~DBPersonAccessor()
        {
            connection.Close();
        } */

        public List<Person> GetAll()
        {
            
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PersonTable";
            SqlCeDataReader reader = cmd.ExecuteReader();
            
            List<Person> result = new List<Person>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string birthDate = reader.GetString(2);
                Person readPerson = new Person(id, name, DateTime.Parse(birthDate));
                result.Add(readPerson);
            }

            cmd.ExecuteNonQuery();
            //reader.Close();
           // connection.Close();
            return result;
        }

        public List<Person> GetByName(string name)
        {
            
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PersonTable WHERE NameField LIKE '%"+name+"%'";
            SqlCeDataReader reader = cmd.ExecuteReader();


            List<Person> result = new List<Person>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fullName = reader.GetString(1);
                string birthDate = reader.GetString(2);
                Person readPerson = new Person(id, name, DateTime.Parse(birthDate));
                result.Add(readPerson);
            }

            cmd.ExecuteNonQuery();
            reader.Close();
            connection.Close();
            return result;
        }

        public void DeleteByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersonListByQuery(string query)
        {

        }



    }


 
}
	
 
