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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_Assingment
{
    // CURD එක සම්පූර් ණ කර අවසන් වන අතර දත්ත සමුදාය  ඉතිරිව පවතී 
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }


        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marked");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("dasboard");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("add");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marking");
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("update");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("about");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("add");
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marking");
        }

        private void bunifuTileButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("marked");
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("update");
        }

        private void bunifuTileButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("about");
        }

        private void bunifuTextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // only images
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif, *.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            //check dialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // path of selected file
                string imagePath = openFileDialog.FileName;


            }
        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            // Check for empty fields
            if (string.IsNullOrEmpty(StID.Text) ||
                string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(email.Text) ||
                string.IsNullOrEmpty(number.Text) ||
                string.IsNullOrEmpty(parent.Text) ||
                string.IsNullOrEmpty(Pnum.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Check for "@" sign in email
            if (!email.Text.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Check for valid contact number format
            if (number.Text.Length != 10 || !int.TryParse(number.Text, out _))
            {
                MessageBox.Show("Please enter a 10-digit number for the contact number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Check for valid parent's contact number format
            if (Pnum.Text.Length != 10 || !int.TryParse(Pnum.Text, out _))
            {
                MessageBox.Show("Please enter a 10-digit number for the parent's contact number.", "Check the number", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                // Establish  connection
                string connectionString = "Your_Connection_String";
                // Replace connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Save 
                    string query = "INSERT INTO Students (StID, Name, Email, ContactNumber, ParentName, ParentContactNumber) " +
                                   "VALUES (@StID, @Name, @Email, @ContactNumber, @ParentName, @ParentContactNumber)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@StID", StID.Text);
                        command.Parameters.AddWithValue("@Name", Name.Text);
                        command.Parameters.AddWithValue("@Email", email.Text);
                        command.Parameters.AddWithValue("@ContactNumber", number.Text);
                        command.Parameters.AddWithValue("@ParentName", parent.Text);
                        command.Parameters.AddWithValue("@ParentContactNumber", Pnum.Text);

                        command.ExecuteNonQuery();
                    }

                    // Close database connection
                    connection.Close();
                }

                MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }



        private void bunifuTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            //  dialog box
            DialogResult result = MessageBox.Show("Are you sure you want to clear all text boxes?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {///okay event
                StID.Text = string.Empty;
                Name.Text = string.Empty;
                email.Text = string.Empty;
                number.Text = string.Empty;
                parent.Text = string.Empty;
                Pnum.Text = string.Empty;
            }
        }

    }
}
