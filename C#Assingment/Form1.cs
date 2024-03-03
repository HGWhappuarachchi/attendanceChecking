using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Assingment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string Username = bunifuTextBox1.Text;
            string Passsword = bunifuTextBox2.Text;

            if(Username =="admin" && Passsword =="admin")
            {
                dashboard objdash = new dashboard();
                this.Hide();
                objdash.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Username or Password");
            }

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuTextBox1.Text = " ";
            bunifuTextBox2.Text = " ";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
