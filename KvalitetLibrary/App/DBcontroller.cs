using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KvalitetLibrary.App
{
    public class DBcontroller
    {
        private string connectionString;

        public DBcontroller()
        {
            this.connectionString = "Server=EALSQL1.eal.local;Database=B_DB24_2018;User Id=B_STUDENT24;Password=B_OPENDB24;";
        }

        public SqlConnection GetDatabaseConnection()
        {
            return new SqlConnection(connectionString);
        }

        public List<string> GetAllCustomers()
        {
            using (SqlConnection connection = GetDatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllCustomers", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    return ListResult(cmd);
                }
            }
        }

        public List<string> GetAllProducts()
        {
            using (SqlConnection connection = GetDatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllProducts", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    return ListResult(cmd);
                }
            }
        }

        public int RegisterUser(string name, string address, string zip, string town, string telephone)
        {
            using (SqlConnection connection = GetDatabaseConnection())
            {
                using (SqlCommand cmd = new SqlCommand("spRegisterUser", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
                    cmd.Parameters.Add("@zip", SqlDbType.NVarChar).Value = zip;
                    cmd.Parameters.Add("@town", SqlDbType.NVarChar).Value = town;
                    cmd.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = telephone;

                    connection.Open();

                    return int.Parse(ListResult(cmd)[0]);
                }
            }
        }

        List<string> ListResult(SqlCommand cmd)
        {
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                List<string> result = new List<string>();

                while (reader.Read())
                {
                    string resultString = "";
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (reader.FieldCount == 1)
                        {
                            resultString += reader[i];
                        }
                        else
                        {
                            resultString += reader[i] + ",";
                        }
                    }
                    result.Add(resultString);
                }
                return result;
            }
        }
    }
}
