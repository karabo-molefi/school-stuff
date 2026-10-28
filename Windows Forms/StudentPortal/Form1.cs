using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            int sID = int.Parse(StudentIDText.Text);
            string sName = StudentNameText.Text;
            string lName = LastNameText.Text;
            string cID = CourseIDText.Text;

            // add to database
            try
            {
                DataHandler data = new DataHandler();

                data.Register(sID, sName, lName, cID);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int sID = int.Parse(StudentIDText.Text);
            string sName = StudentNameText.Text;
            string lName = LastNameText.Text;
            string cID = CourseIDText.Text;


            try
            {
                DataHandler data = new DataHandler();

                data.Update(sID, sName, lName, cID);

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            Form2 searchForm = new Form2();
            searchForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Form3 deleteForm = new Form3();
            deleteForm.ShowDialog();
        }
    }
}
