using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace KubeSample.Data
{
    public class DataAccessLayer
    {

        public string get( string connectionStr)
        {
            MySqlConnection connection = null;
            try
            {
                string result = string.Empty;

                using (connection = new MySqlConnection(connectionStr))
                {
                    connection.Open();
                    var query = @"SELECT table_name  
                                FROM INFORMATION_SCHEMA.TABLES 
                                WHERE TABLE_TYPE = 'BASE TABLE';";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        //Create a data reader and Execute the command
                        using (MySqlDataReader dataReader = cmd.ExecuteReader())
                        {

                            //Read the data and store them in the list
                            var finalResults = new List<string>();
                            while (dataReader.Read())
                            {
                                result= result + dataReader["table_name"];
                            }

                            //close Data Reader
                            dataReader.Close();

                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
