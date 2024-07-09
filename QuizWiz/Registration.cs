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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        //Declaring it globally beacause i have to access these variable's value to thankyou page 
        public static string name;
        public static string gender;
        public static string password;
        public static string email;
        public static string phone_no;


        private void Registration_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //to show the pictures in picturebox one by one (like animationn )
        //int count = 0;
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (count < 8)       //there are total 9 photos in imagelist so took 8 here coz indexing starts with 0 in imagelist 
        //    {
        //        pictureBox2.Image = imageList1.Images[count];    //now the diff. pictures will be displayed in picturebox as "count" increments 
        //        count++;
        //    }
        //    else
        //    {
        //        count = 0;                    //after 8 the image display will be stoped so again made it 0 to start the animation again form starting 
        //    }
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;   //to minimize the window

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.ToString();
            email = textBox2.Text.ToString();
            phone_no = textBox3.Text.ToString();
            password= textBox4.Text.ToString();

            //checking all the textboxes are filled correctly  ---- 
            //if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text != "")





            //database connection and data entry part ---

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");

            string insert = "insert into Player_Details(Email_ID,Name,Gender,Mobile_no,Physics,Chemistry,Mathematics) values ('" + email + "','" + name + "','" + gender + "','" + phone_no + "','" + 1 + "','" + 1 + "','" + 1 + "')";
            OleDbCommand od = new OleDbCommand(insert, oc);

            oc.Open();
            od.ExecuteNonQuery();
            oc.Close();


            string authen = "insert into Authentication values ('" + email + "','" + password + "')";
            OleDbCommand ok = new OleDbCommand(authen, oc);
            oc.Open();
            ok.ExecuteNonQuery();
            oc.Close();


            Thankyou tk = new Thankyou();
            tk.Show();
            this.Close();

            //MessageBox.Show("data entered");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

           
         
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;

            pictureBox3.Visible = true;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox3.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;
            

            pictureBox6.Visible = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Your Name ");
                textBox1.Focus();
                textBox1.Focus();
            }
            
        }

        private void textBox1_Leave(object sender, EventArgs e)    //this is  the leave event of textBox1 , here we have coded that  - if someone leaves textbox1 blank then it will show message right away . (this is why we have done it inside leave event )
        {
            //if (textBox1.Text == "")
            //{
            //    MessageBox.Show("Please Enter your Name");     
            //    textBox1.Focus();
            //}
            //else
            //{
            //    textBox2.Focus();
            //}
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;

            pictureBox8.Visible = true;

            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Your Email ID ");
                textBox1.Focus();

            }
            
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;


            pictureBox4.Visible = true;

        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;

            pictureBox5.Visible = true;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {

            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox10.Visible = false;

            pictureBox9.Visible = true;

            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Enter Your Phone no.  ");
                textBox3.Focus();

            }
            
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;

            pictureBox10.Visible = true;
        }

        private void textBox5_TabIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.ToString() != textBox5.Text.ToString())
            {
                MessageBox.Show("Password and Confirmed Password not matched");
                textBox4.Text = "";
                textBox5.Text = "";
                textBox4.Focus();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

// Important Points -  1 . leave event of textbox is generated only when its click event has occured(means if you have clicked that textbox ) if we simply skip that text box without clicking it then its leave event will not be generated (NO CLICK EVENT THEN NO LEAVE EVENT)
