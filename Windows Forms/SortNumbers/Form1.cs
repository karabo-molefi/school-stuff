using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SortNumbers
{
    public partial class Form1 : Form
    {
        List<int> sorted = new List<int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            // load data from text file to listview
            var filelines = File.ReadAllLines(@"C:\\Users\\Karabo\\OneDrive - belgiumcampus.ac.za\\2026\\PRG282\\Exercises\\SortNumbers\\Numbers.txt");

            foreach (var line in filelines)
            {
                listViewRead.Items.Add(line);

                // add to sorted list
                sorted.Add(int.Parse(line));
                
            }
            
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            // sort list
            sorted.Sort();
            // sort data from text file and load to listview
            foreach (var item in sorted)
            {
                listViewSort.Items.Add(item.ToString());
            }

        }
    }
}
