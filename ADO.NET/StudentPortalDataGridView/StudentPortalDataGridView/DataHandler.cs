using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalDataGridView
{
    internal class DataHandler
    {
        public DataHandler() { }
        
        SqlConnection con = new SqlConnection(@"Server=WIN-3MTLQE2B0CL\SQLEXPRESS02; Initial Catalog=Belgiumcampus; Integrated Security=true");

        public DataTable displayStudents()
        {
            string query = @"SELECT * FROM Students";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            adapter.Fill(dt);
            return dt;
        }
    }
}
