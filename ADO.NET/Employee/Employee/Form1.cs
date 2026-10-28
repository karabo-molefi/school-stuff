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

namespace Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "File Type=|*.JPG;*.PNG;*.WEBP;*.GIF";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                // assign file name
                userImage.ImageLocation = dialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass1 = textBox2.Text;
            string pass2 = textBox3.Text;

            if(pass1 == pass2 && !string.IsNullOrEmpty(pass1)){
                try
                {
                    string path = userImage.ImageLocation;
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                    // buffered stream allows read and write
                    BufferedStream buffer = new BufferedStream(file);
                    Byte[] data = new byte[1024 * 100];//100kb image size
                    buffer.Read(data, 0, data.Length);// byte, from 0, to max length
                    string image = Convert.ToBase64String(data);

                    // call database management object
                    DatabaseManagement database = new DatabaseManagement();

                    database.InsertUserData(username, pass1, image);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine("Insertion error" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("password empty or incorrect");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
