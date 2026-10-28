using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCDataSetAnddataTable
{
    public partial class Form1 : Form
    {
        DataHandler handler = new DataHandler();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = handler.loadDataSet().Tables[0];
            dataGridView2.DataSource = handler.loadDataSet().Tables[1];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = handler.loadDataTable();
        }
    }
}
