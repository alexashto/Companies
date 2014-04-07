using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;

namespace Persons
{
    class DBPersonAccessor : IPersonAccessor
    {
        private SqlCeConnection connection;
        private const string CONNECTION_CONFIGURATION = "Data Source = DataStorage/AppDB.sdf; Password = ''";

        public DBPersonAccessor()
        {
 
        }

        ~DBPersonAccessor()
        {
            connection.Close();
        }

        public List<Person> GetAll()
        {

            string query = "SELECT * FROM PersonTable";
            return GetPersonListByQuery(query);
        }

        public List<Person> GetByName(string name)
        {
            string query = "SELECT * FROM PersonTable WHERE NameField LIKE '%" + name + "%'";
            return GetPersonListByQuery(query);
            
        }

        public void DeleteById(int Id) 
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {

                using (SqlCeCommand cmd = new SqlCeCommand("DELETE FROM PersonTable WHERE IdField = @Id", connection))
                {
                    cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public void Insert(Person person)
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {

                using (SqlCeCommand cmd = new SqlCeCommand("INSERT INTO PersonTable (NameField, AgeField) VALUES (@Name, @Age)", connection))
                {
                   
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = person.FullName;
                    cmd.Parameters.Add("@Age", SqlDbType.Int, 4).Value = person.Age;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }


        public List<Person> GetPersonListByQuery(string query)
        {

            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                SqlCeDataReader reader = cmd.ExecuteReader();


                List<Person> result = new List<Person>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fullName = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    Person readPerson = new Person(id, fullName, age);
                    result.Add(readPerson);
                }



                cmd.ExecuteNonQuery();
                reader.Close();
                connection.Close();

                return result;
            }
            
        }





        public Person GetById(int id)
        {
            string query = "SELECT * FROM PersonTable WHERE IdField = ";
            return GetPersonListByQuery(query)[0];
        }

    }


 
}
	
 
