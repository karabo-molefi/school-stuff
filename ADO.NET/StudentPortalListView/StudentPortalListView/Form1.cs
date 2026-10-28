using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortalListView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataHandler handler = new DataHandler();

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow dr in handler.displayStudents().Rows)
            {
                ListViewItem item = new ListViewItem(dr["StudentID"].ToString());
                item.SubItems.Add(dr["Name"].ToString());
                item.SubItems.Add(dr["Surname"].ToString());
                item.SubItems.Add(dr["Course"].ToString());

                listView1.Items.Add(item);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            string stID = listView1.SelectedItems[0].SubItems[0].Text;
            string name = listView1.SelectedItems[0].SubItems[1].Text;
            string surname = listView1.SelectedItems[0].SubItems[2].Text;
            string course = listView1.SelectedItems[0].SubItems[3].Text;

            textBox1.Text = stID;
            textBox2.Text = name;
            textBox3.Text = surname;
            textBox4.Text = course;

        }
    }
}
