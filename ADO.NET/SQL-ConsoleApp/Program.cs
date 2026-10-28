using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQL_ConsoleApp
{
    internal class Program
    {
        static SqlConnection connection;
        static string con = @"Server=KARABO\SQLEXPRESS; Initial Catalog = Northwind; Integrated Security=SSPI";
        static string query = "SELECT FirstName, LastName, Region FROM Employees WHERE Region IS NOT NULL";
        static void Main(string[] args)
        {

            // INSERT
            /*string query4 = "INSERT INTO Employees (FirstName, LastName, Region) VALUES ('Kat', 'Balq', 'TA')";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query4, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }*/



            // SELECT
            using (SqlConnection connection = new SqlConnection(con))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
                            }
                        }
                    }
                }
            }

            // DELETE

            string query5 = "DELETE FROM Employees WHERE Region = 'TA'";

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query5, conn))
                {
                    cmd.ExecuteNonQuery ();
                }
            }

            // update region to PA where region is null

            string query2 = "UPDATE Employees SET Region = 'PA' WHERE Region IS NULL";
            string query3 = "SELECT FirstName, LastName, Region FROM Employees";


            using (SqlConnection  conection2 = new SqlConnection(con))
            {
                conection2.Open();
                using (SqlCommand command = new SqlCommand(query2, conection2))
                {
                    command.ExecuteNonQuery();
                }
            }

            /* see changes
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query3, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
                            }
                        }
                    }
                }
            }*/
            




            
        }
    }
}
