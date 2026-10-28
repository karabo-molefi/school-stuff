using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;

namespace Employee
{
    internal class DatabaseManagement
    {
        SqlConnection con = null;

        public DatabaseManagement()
        {
            con = new SqlConnection(@"Server=WIN-3MTLQE2B0CL\SQLEXPRESS02; Initial Catalog=Northwind; Integrated Security=SSPI");
            con.Open();
        }

        public void InsertUserData(string user, string password, string image)
        {
            string query = @"insert into Users(username, password, picture) VALUES";


            using (SqlCommand cmd = new SqlCommand(query, con))
            {
               
            }

        }

        public SqlDataReader ReadUserdata()
        {
            string query = @"SELECT * from users";
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    MessageBox.Show("");
                }
                return reader;
            }
            catch(Exception ex)
            {
                MessageBox.Show("query error: " + ex.Message);
                return null;
            }
    
        }
        
    }
}
