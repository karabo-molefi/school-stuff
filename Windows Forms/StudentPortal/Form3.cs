using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int sID = int.Parse(deleteStudentTxt.Text);

            DataHandler handler = new DataHandler();

            handler.DeleteStudent(sID);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int sID = int.Parse(deleteStudentTxt.Text);

            DataHandler handler = new DataHandler();

            dataGridViewDeleteStudent.DataSource = handler.SearchStudent(sID);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
