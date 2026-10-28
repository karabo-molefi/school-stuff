using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BCDataSetAnddataTable
{
    
    internal class DataHandler
    {
        SqlConnection connection = null;
        public DataHandler()
        {
            connection = new SqlConnection(@"Server=KARABO\SQLEXPRESS; Initial Catalog = BelgiumCampus; Integrated Security = true"); 
            connection.Open();
        }

        public DataSet loadDataSet()
        {
            string query1 = "SELECT * FROM Students";
            string query2 = "SELECT * FROM Course";

            DataSet dataSet = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(query1, connection);

            adapter.Fill(dataSet, "Students");

            adapter = new SqlDataAdapter(query2, connection);

            adapter.Fill(dataSet, "Courses");

            return dataSet;


        }

        public DataTable loadDataTable()
        {
            string query = "SELECT * FROM Lecturers";

            DataTable dataTable = new DataTable();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

            dataAdapter.Fill(dataTable);

            return dataTable;
        }
    }
}
