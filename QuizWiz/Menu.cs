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
    public partial class Menu : Form
    {
        string id;
        public Menu(string s )
        {
            InitializeComponent();
            id = s;                         //it is the email id of player 
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Play pl = new Play(3,id);     //passing 3 for mathematics 
            pl.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Play pl = new Play(1,id);    //passing 1 for physics 
            pl.Show();
            this.Close();

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string F_name = "select Name from Player_Details where Email_ID ='" + id + "' ";
            OleDbDataAdapter od = new OleDbDataAdapter(F_name, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

            richTextBox2.Text = dt.Rows[0]["Name"].ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           Play pl = new Play(2,id);     //passing 2 for chemistry 
            pl.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
