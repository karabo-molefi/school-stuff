using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_DataGRid_ListNview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDGV_Click(object sender, EventArgs e)
        {
            DataHandler handler = new DataHandler();

            var src = handler.fillDGV();

            dataGridView1.DataSource = src;
        }
    }
}
