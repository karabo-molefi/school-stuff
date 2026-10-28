using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks; 

namespace ADO.NET
{
    internal class DataHandler
    {
        public DataHandler() { }

        // connection string

        string con = @"Server=KARABO\SQLEXPRESS;Initial Catalog=NORTHWIND;Integrated Security=SSPI;Connection Timeout=30";

        public void getCategories()
        {
            SqlConnection connection = new SqlConnection(con);

            try
            {
                connection.Open();
                Console.WriteLine("Connection opened");
            }
            catch (Exception ex)
            {
                Console.WriteLine("not connected");
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            // sql query
            string query = @"SELECT * FROM Categories";

            // sql command object
            SqlCommand cmd = new SqlCommand(query, connection);

            // execute command with data reader to read row by row
            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine();
            Console.WriteLine("Data fetched successfully! Find it below:\n");

            // displaying data

            Console.WriteLine("==================================================");
            Console.WriteLine();
            Console.WriteLine("ID\tCategory Name");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}\t{reader.GetString(1)}");
                }
            }
            else
            {
                Console.WriteLine("no rows found.");
            }

            reader.Close();
            connection.Close();
        }

            // INSERTING DATA
            public void insertData()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connection opened");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("not connected");
                    Console.WriteLine(ex.Message);
                    return;
                }

                string query = @"INSERT INTO Categories (CategoryName, Description) VALUES ('Vegan', 'Nice Food')";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("insert successfull!");
                }

            }

            
        }

        // UPDATING DATA

        public void updateCategories()
        {
            using(SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("connection opened");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.Message);
                }

                string query = @"UPDATE Categories SET CategoryName = 'Exotic Foods' WHERE CategoryName = 'Vegan'";

                using(SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("success!");
                    Console.WriteLine();
                }
            }
        }

        public void deleteCategory()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
               /* try
                {
                    connection.Open();
                }
                catch( Exception ex)
                {
                    Console.WriteLine("Error");
                    Console.WriteLine(ex.Message);
                    return; ;
                }*/

                string query = "delete from categories where CategoryName = 'Other'";

                using ( SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    connection.Open();

                    cmd.ExecuteNonQuery ();

                    Console.WriteLine("delete successful");
                    Console.ReadLine();
                }
            }
        }

        // SINGLE VALUE
        // get number of categories

        public void getNumberofCategories()
        {
            using (SqlConnection connection = new SqlConnection(con))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("connection opened");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error");
                    Console.WriteLine(ex.Message);
                }

                string query = "SELECT count(*) from Categories";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int count = (int)command.ExecuteScalar();
                    Console.WriteLine("There are {0} categories", count);
                }
            }
        }

    }
}
