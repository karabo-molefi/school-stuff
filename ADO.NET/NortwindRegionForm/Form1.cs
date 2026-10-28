using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NortwindRegionForm
{
    public partial class Form1 : Form
    {
        SqlConnection con;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(@"Server=KARABO\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security=SSPI");
           
      
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MessageBox.Show("connection opened");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // query + sql command
            string query = "SELECT * FROM Region";

            SqlCommand cmd = new SqlCommand(query, con);

            // data reader
            SqlDataReader reader = cmd.ExecuteReader();

            // binding source
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = reader;

            // datagrid source
            dataGridView1.DataSource = bindingSource;

            // close
            con.Close();
        }
    }
}
