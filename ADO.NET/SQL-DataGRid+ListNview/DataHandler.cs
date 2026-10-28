using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace SQL_DataGRid_ListNview
{
    
    internal class DataHandler
    {
        SqlConnection conn;
        string connectionString = @"Server=KARABO\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=true";

        // fill datagrid view
        public DataTable fillDGV()
        {
            DataTable dt = new DataTable();

            string query = "SELECT TOP 5 * FROM Products";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }





    }
}
