using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizWiz
{
    public partial class Thankyou : Form
    {
        public Thankyou()
        {
            InitializeComponent();
        }

        private void Thankyou_Load(object sender, EventArgs e)
        {
            label7.Text = Registration.name;
            label8.Text = Registration.phone_no;
            label9.Text = Registration.gender;
            label10.Text = Registration.email;

            this.WindowState = FormWindowState.Maximized;    //to open the form in maximized state  

            //for picturebox 
            if (Registration.gender == "Male")
            {
                pictureBox4.Visible = false;
            }
            else
            {
                pictureBox3.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login ls = new Login();
            ls.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
