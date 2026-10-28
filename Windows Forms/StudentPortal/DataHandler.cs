using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentPortal
{
    internal class DataHandler
    {
        // sql connection
        static SqlConnection con;

        public DataHandler() { 
            con = new SqlConnection(@"Server=KARABO\SQLEXPRESS; Initial Catalog=StudentPortal; Integrated Security=true");
            con.Open(); }

        public void Delete(int sID)
        {
            string query = $"DELETE Students WHERE StudentID = '{sID}' ";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("Deletion Sucess");
                else
                    MessageBox.Show("Something went wrong");
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
        }

        public void Update(int sID, string name, string lname, string cID) 
        {
            string query = $"UPDATE Students SET FirstName = '{name}', LastName = '{lname}', CourseID = '{cID}' WHERE StudentID = '{sID}'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                if (cmd.ExecuteNonQuery() > 0) { MessageBox.Show("Updated Successfully"); }
                else
                    MessageBox.Show("Something went wrong.");
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }
            finally{ con.Close(); }

        }

        public void Register(int sID, string name, string lname, string cID)
        {
            // adding to db
            string query = $"INSERT INTO Students VALUES('{sID}', '{name}','{lname}','{cID}')";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("User Registered Successfully");
                else
                    MessageBox.Show("Something went wrong");
            }
            catch (Exception ex) {MessageBox.Show(ex.Message); return; }
        }

        public SqlDataReader Search(int sID)
        {
            // search 
            string query = $"SELECT * FROM Students WHERE StudentID = '{sID}'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);

                // data reader
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                    MessageBox.Show("No data to display");
                return reader;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); return null;}
            
            finally { con.Close(); }
        }

        public DataTable SearchStudent(int studentID)
        {
            string query = $"SELECT * FROM Students WHERE StudentID = '{studentID}'";

            try
            {
                DataTable dt = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                

                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Student Found");
                    return dt;
                }
                else
                {
                    MessageBox.Show($"Student {studentID} not found");
                    return null;
                }
                

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); return null; }
        }

       
        public void DeleteStudent(int studentID)
        {
            string query = $"DELETE FROM Students WHERE StudentID = '{studentID}'";

            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                if (cmd.ExecuteNonQuery() > 0)
                    MessageBox.Show("User Deleted Successfully");
                else
                    MessageBox.Show("Something went wrong");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

    }

}
