using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persons.DataEntity;
using System.Data.SqlServerCe;
using System.Data;
using System.Reflection;

namespace Persons.Accessors
{
    class MyOrmAccessor<T> where T: BaseEntity
    {
        private SqlCeConnection connection;
        private const string CONNECTION_CONFIGURATION = "Data Source = DataStorage/AppDB.sdf; Password = ''";
        private string tableName;
        private List<string> fieldNames = new List<string>();
        private List<string> fieldTypes = new List<string>();
        private List<PropertyInfo> objProps = new List<PropertyInfo>();
        int idFieldIndex;

        public MyOrmAccessor()
        {
            GetTableInfo();

        }

        ~MyOrmAccessor()
        {
            connection.Close();
        }

        private void GetTableInfo()
        {

            Type entityType = typeof(T);

            tableName = ((TableAttribute)entityType.GetCustomAttribute(typeof(TableAttribute), false)).TableName;

            PropertyInfo[] props = entityType.GetProperties();

            foreach (var p in props)
            {
                FieldAttribute fieldAttr = (FieldAttribute)p.GetCustomAttribute(typeof(FieldAttribute), false);

                fieldNames.Add(fieldAttr.FieldName);
                fieldTypes.Add(fieldAttr.FieldType);
                objProps.Add(p);
 
            }


            for (int i = 0; i < objProps.Count; i++)
            {
                if (objProps[i].Name.ToLower().Contains("id"))
                {
                    idFieldIndex = i;
                    break;
                }
            }

        }
   

        public List<T> GetAll()
        {
            using (connection = new SqlCeConnection(CONNECTION_CONFIGURATION))
            {
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT {0} FROM {1}", string.Join(", ", fieldNames), tableName);
                SqlCeDataReader reader = cmd.ExecuteReader();


                List<T> result = new List<T>();

                while (reader.Read())
                {
                    var item = Activator.CreateInstance(typeof(T));

                    for (int i = 0; i < fieldNames.Count; i++)
                    {
                        objProps[i].SetValue(item, reader[fieldNames[i]]);
                    }

                    result.Add((T) item);
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

                string query = string.Format("DELETE FROM {0} WHERE {1} = @Id", tableName, fieldNames[idFieldIndex]);

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
                string[] fldNames = fieldNames.ToArray();
                fldNames = fldNames.Where(w => w != fldNames[idFieldIndex]).ToArray();
                string query = string.Format("INSERT INTO {0} ({1}) VALUES (@{2})", tableName, string.Join(", ", fldNames), string.Join(", @", fldNames));
                using (SqlCeCommand cmd = new SqlCeCommand(query, connection))
                {
                    for (int i = 0; i < fieldNames.Count; i++)
                    {
                        if (i != idFieldIndex)
                        {
                            cmd.Parameters.AddWithValue("@" + fieldNames[i], objProps[i].GetValue(item)); 
                        }
                    }
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

                string query = string.Format("SELECT {0} FROM {1} WHERE {2} = @Id", string.Join(", ", fieldNames), tableName, fieldNames[idFieldIndex]);

                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;

                SqlCeDataReader reader = cmd.ExecuteReader();

                var result = Activator.CreateInstance(typeof(T));

                if (reader.Read())
                {
                    for (int i = 0; i < fieldNames.Count; i++)
                    {
                        objProps[i].SetValue(result, reader[fieldNames[i]]);
                    }
 
                }
                
               
                cmd.ExecuteNonQuery();
                connection.Close();
                reader.Close();


                return (T) result;
            }
        }



    }
}
