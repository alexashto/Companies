using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Data;
using Persons.DataEntity;

namespace Persons.Accessors
{
    public class DBPersonAccessor<T> : IEntityAccessor<T> where T : Person
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

        public List<T> GetAll()
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PersonTable";
                SqlCeDataReader reader = cmd.ExecuteReader();


                List<T> result = new List<T>();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fullName = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    Person readPerson = new Person(id, fullName, age);
                    result.Add((T) readPerson);
                }


                
                cmd.ExecuteNonQuery();
                connection.Close();
                reader.Close();
                

                return result;
            }
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

        public void Insert(T item)
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {

                using (SqlCeCommand cmd = new SqlCeCommand("INSERT INTO PersonTable (NameField, AgeField) VALUES (@Name, @Age)", connection))
                {

                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 60).Value = item.FullName;
                    cmd.Parameters.Add("@Age", SqlDbType.Int, 4).Value = item.Age;
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

            }
        }




        public T GetById(int id)
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM PersonTable WHERE IdField = @Id";
                cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;

                SqlCeDataReader reader = cmd.ExecuteReader();

                Person resultPerson = null;
                
                if (reader.Read())
                {
                    string fullName = reader.GetString(1);
                    int age = reader.GetInt32(2);
                    resultPerson = new Person(id, fullName, age);
                }



                cmd.ExecuteNonQuery();
                connection.Close();
                reader.Close();


                return (T)resultPerson;
            }
        }

    }


 
}
	
 
