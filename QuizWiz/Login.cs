using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace QuizWiz
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;    //to open the form in maximized state  (can also do it by properties)
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //to minimize the window
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("hello ");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Registration rg = new Registration();
            rg.Show();
            this.Close();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
           if  (count < 2)
            {
                pictureBox6.Image = imageList1.Images[count];
                count++;
            }
            else
            {
                count = 0;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.PasswordChar = '\0';
               
            }
            else
                textBox2.PasswordChar='*';
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string match = "select User_Id,Password from Authentication where User_ID='" + textBox1.Text + "' and Password='" + textBox2.Text + "'";
            OleDbDataAdapter od = new OleDbDataAdapter(match, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);


            if (dt.Rows.Count == 0)
            {
                MessageBox.Show(" Invalid information entered please enter valid details ");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                string id = textBox1.Text;
                Menu mp = new Menu(id);
                mp.Show();
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }
    }
}
