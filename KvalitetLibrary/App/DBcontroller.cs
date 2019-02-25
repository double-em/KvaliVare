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
                        resultString += reader[i] + ",";
                    }
                    result.Add(resultString);
                }
                return result;
            }
        }
    }
}
