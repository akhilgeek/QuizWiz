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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration rs = new Registration();
            rs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About ab = new About();
            ab.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contact ct = new contact();
            ct.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thankyou tk = new Thankyou();
            tk.Show();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Instruction inn = new Instruction();
            inn.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string id = "";
            Play pl = new Play(0,id);     // here pasing 0 in play constructor beacuse - 
            pl.Show();
            this.Hide();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Menu men = new Menu("a");
            men.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Rough rs = new Rough();
            rs.Show();
            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //result rs = new result(5,"akhil",1,5);
            //rs.Show();
            //this.Hide();
        }
    }
}
