using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace TimetableAPI.Database
{
    public class Database
    {
        public static DataTable readTable(string StoredProcedureName, Dictionary<string, object> param = null)
        {
            try
            {
                // Create connection
                string connectionString = ConfigurationManager.ConnectionStrings["QLBSConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create and Assign properties for command
                    SqlCommand command = new SqlCommand(StoredProcedureName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    // Check parameters in Stored Procedure
                    if (param != null)
                    {
                        foreach (KeyValuePair<string, object> data in param)
                        {
                            command.Parameters.AddWithValue("@" + data.Key, data.Value ?? DBNull.Value);
                        }
                    }

                    // Result variable
                    DataTable resultTable = new DataTable("DT");

                    // Execute sqlCommand and Assign to result variable
                    command.Connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(resultTable);
                        return resultTable;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static object ExecCommand(string StoredProcedureName, Dictionary<string, object> param = null)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QLBSConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Start a local transaction.
                    SqlCommand command = new SqlCommand(StoredProcedureName, connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (param != null)
                    {
                        foreach (KeyValuePair<string, object> data in param)
                        {
                            command.Parameters.AddWithValue("@" + data.Key, data.Value ?? DBNull.Value);
                        }
                    }

                    // Attempt to commit the transaction.
                    command.Connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}