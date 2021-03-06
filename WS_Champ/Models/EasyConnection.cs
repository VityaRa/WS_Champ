using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WS_Champ.Models
{
    public class EasyConnection
    {
        public static List<Region> GetRegionData(List<Region> listToFill, string sqlCommand)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sqlCommand, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listToFill.Add(new Region (Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString())); 
                    }
                }

            }
            return listToFill;
        }
        public static Region GetRegionDataById(string sqlCommand, int id)
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string ByIdCommand = sqlCommand + " WHERE [Код] = " + id.ToString();
                SqlCommand cmd = new SqlCommand(ByIdCommand, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return (new Region (Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), reader[3].ToString())); 
                    }
                }
            }
            return new Region();
        }
        public static void AddRegion (string name, string capital, string district)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(Region.InsertRegionCommand(), connection);
                sqlCommand.Parameters.AddWithValue("name", name);
                sqlCommand.Parameters.AddWithValue("capital", capital);
                sqlCommand.Parameters.AddWithValue("district", district);
                sqlCommand.ExecuteNonQuery();
            }
            
        }
        public static void DeleteRegion (int id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(Region.DeleteRegionCommand(), connection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
            }
        }
        public static void UpdateRegion(int id, string newName)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = GetConnectionString();
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(Region.UpdateRegionCommand(), connection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.Parameters.AddWithValue("name", newName);
                sqlCommand.ExecuteNonQuery();
            }
        }
        static private string GetConnectionString()
        {
            return "Data Source=localhost\\SQLEXPRESS;Initial Catalog=lobanov;"
                + "Integrated Security=true;";
        }
    }
}