using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalListView
{
    internal class DataHandler
    {
     
        string con = @"Server=WIN-3MTLQE2B0CL\SQLEXPRESS02; Initial Catalog = BelgiumCampus; Integrated Security=true";
        public DataHandler() { }

        public DataTable displayStudents()
        {
            string query = "SELECT * FROM Students";

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(query, con);

            da.Fill(dt);

            return dt;
        }
    }
}
