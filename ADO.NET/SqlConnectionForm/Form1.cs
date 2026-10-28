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

namespace SqlConnectionForm
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();

            con = new SqlConnection(@"Server=KARABO\SQLEXPRESS; Initial Catalog=Northwind; Integrated Security =SSPI");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MessageBox.Show("Connection Open");
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // sql command
            string query = "SELECT * FROM Categories";
            SqlCommand cmd = new SqlCommand(query, con);

            //sql data reader
            SqlDataReader reader = cmd.ExecuteReader();

            // binding source
            BindingSource bindingSource = new BindingSource();

            // bind binding source it to the reader
            bindingSource.DataSource = reader;

            // bind datagrid to binding source
            dataGridView1.DataSource = bindingSource;

            con.Close();
        }
    }
}
