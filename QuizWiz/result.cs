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
    public partial class result : Form
    {
        int Total_correct_ans;
        int Total_wrong_ans;
        string sbjt_name;
        string st_id;
        int sbjt;
        int current_level;
        string current_level_name;
        int cleared_level;
        int not_attempted; // it is to calculate the number of questions not attempted 
        int Total_attempted;
        double accuracy_percentage;


        // path of all the subjects (put it here globally )        
        OleDbConnection ph = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
        OleDbConnection ch = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
        OleDbConnection mat = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");






        public result(int correct ,int wrong, string id , int sub,int level,string level_name)    // if we wanted we could have passed more informations like - "Total no of wrong answers" , "current level " etc but more the informations we pass harder it will be for the page to load itself (sir said )
        {
            InitializeComponent();
            Total_correct_ans = correct;
            st_id = id;
            sbjt = sub;
            current_level = level;
            current_level_name = level_name;
            Total_wrong_ans = wrong;
            
        }




        // function for updating "Z" in all the rows of table which is completed 
        void update_z()
        {
            if (sbjt == 1)
            {
                string upz = "update " + current_level_name + " set User_ans = 'Z'";
                OleDbCommand od = new OleDbCommand(upz, ph);
                ph.Open();
                od.ExecuteNonQuery();
                ph.Close();
            }
            else if (sbjt == 2)
            {
                string upz = "update " + current_level_name + " set User_ans = 'Z'";
                OleDbCommand od = new OleDbCommand(upz, ch);
                ch.Open();
                od.ExecuteNonQuery();
                ch.Close();
            }
            else if (sbjt == 3)
            {
                string upz = "update " + current_level_name + " set User_ans = 'Z'";
                OleDbCommand od = new OleDbCommand(upz, mat);
                mat.Open();
                od.ExecuteNonQuery();
                mat.Close();
            }
        }












        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //updating the cleared_level of player in database if the current_level (in which user is playing ) is equals to cleared_level  (last level which was cleared by user )
            if (current_level == cleared_level)
            {
                cleared_level++;
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
                string lvl_update = "update Player_Details set " + sbjt_name + "=" + cleared_level + " where Email_ID='"+st_id+"'";     
                OleDbCommand od = new OleDbCommand(lvl_update,oc);
                oc.Open();
                od.ExecuteNonQuery();
                oc.Close();
                

;            }

            //for updating  Z in recently completed level 
            update_z();


            Play pl = new Play(sbjt,st_id);     // again returning to the playing page (to going to that page we have to again passs the arguments ) sbjt is subject no  (1- phy , 2 -chem,3-maths) "id" is emaail id of  user 
            pl.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //for updating  Z in recently completed level before we close the app 
            update_z();
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void result_Load(object sender, EventArgs e)
        {


            if (sbjt == 1)
            {
                label10.Text = "Physics";
                sbjt_name = "Physics";
            }
            else if (sbjt == 2)
            {
                label10.Text = "Chemistry";
                sbjt_name = "Chemistry";
            }
            else if (sbjt == 3)
            {
                label10.Text = "Mathematics";
                sbjt_name = "Mathematics";
            }

            ////accessing the level tabel of particular subject in which the user was currently playing to calculate the total not attempted questions and many more things 
            //if (sbjt == 1)
            //{
            //    label10.Text = "Physics";
            //    sbjt_name = "Physics";

            //    OleDbConnection om = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
            //    string answer_fetch = "select User_ans from "+current_level_name+" where User_ans ='Z'";
            //    OleDbDataAdapter ot = new OleDbDataAdapter(answer_fetch, om);
            //    DataTable dt1 = new DataTable();

            //    ot.Fill(dt1);

            //    //counting total numbre of not attempted questions 
            //    not_attempted = Convert.ToInt32(dt1.Rows.Count);


            //}
            //else if (sbjt == 2)
            //{

            //    label10.Text = "Chemistry";
            //    sbjt_name = "Chemistry";

            //    OleDbConnection om = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
            //    string answer_fetch = "select User_ans from " + current_level_name + " where User_ans ='Z'";
            //    OleDbDataAdapter ot = new OleDbDataAdapter(answer_fetch, om);
            //    DataTable dt1 = new DataTable();

            //    ot.Fill(dt1);

            //    //counting total numbre of not attempted questions 
            //    not_attempted = dt1.Rows.Count;

            //}
            //else if (sbjt == 3)
            //{
            //    label10.Text = "Mathematics";
            //    sbjt_name = "Mathematics";

            //    OleDbConnection om = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
            //    string answer_fetch = "select User_ans from " + current_level_name + " where User_ans ='Z'";
            //    OleDbDataAdapter ot = new OleDbDataAdapter(answer_fetch, om);
            //    DataTable dt1 = new DataTable();
            //    ot.Fill(dt1);

            //    //counting total numbre of not attempted questions 
            //    not_attempted = dt1.Rows.Count;
            //    MessageBox.Show(dt1.Rows.Count.ToString());

            //}




            //CALCULATION PART


            //To print how many questions are not attempted out of 10 
           Total_attempted = Total_wrong_ans+Total_correct_ans;

            //calculating total not attempted questions 
            not_attempted = 10 - Total_attempted;
                                                                      
            // calculating the accuracy percentage 
            accuracy_percentage = ((float)Total_correct_ans/Total_attempted)*100;  // while calculating i did typcast the "Total_correct_ans" variable to "float" datatype otherwise
                                                                                   // the answer of division of two integer values would have come in integer (and mostly it was coming 0 and then multiplying it with 100 was giving 0 )
                                                                                   // now the result will be in float value 



            //PRINTING PART

            // TO print how many questions are not attempted 
            label20.Text = not_attempted.ToString();

           
            //To print how many questions are attempted out of 10  
            label19.Text = Total_attempted.ToString();

            //To print how many correct answer was given by player 
            label21.Text = Total_correct_ans.ToString();
                  
            //TO print how many wrong answer was given by player
            label22.Text = Total_wrong_ans.ToString();

            //for current level
            label11.Text = current_level.ToString();

            // printing accuracy percentage 
            label23.Text = accuracy_percentage.ToString("0.00")+"%";         //here "0.00" is a format specifier which means only two digits will be printed after decimal for ex - 5.67

            //fetching the details of currently playing player 
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string F_name = "select * from Player_Details where Email_ID ='" + st_id + "' ";    //fetching all the details of player 
            OleDbDataAdapter od = new OleDbDataAdapter(F_name, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

            cleared_level = Convert.ToInt32(dt.Rows[0][sbjt_name].ToString());   //fetching  the cleared level of student in strng 



            //MessageBox.Show("cleared_level ="+cleared_level.ToString());
            //MessageBox.Show("current_level="+current_level.ToString());


            //disabling next level button if player fails to get the minimum score 
            if (current_level<=3 && accuracy_percentage >= 40.00)
            {
                button2.Enabled = true;
              
            }
            else if (current_level<=5 && accuracy_percentage >= 50.00)
            {
                button2.Enabled = true;
               
            }
            else if (current_level<=8 && accuracy_percentage >= 75.00)
            {

                button2.Enabled = true;
               
            }
            else if (current_level<=10 && accuracy_percentage >= 85.00)
            {

                button2.Enabled = true;
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //for updating  Z in recently completed level 
            update_z();  

            Menu mn = new Menu(st_id);
            mn.Show();
            this.Close();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //for updating  Z in recently completed level 
            update_z();

            Play pl = new Play(sbjt, st_id);     // again returning to the playing page (to going to that page we have to again passs the arguments ) sbjt is subject no  (1- phy , 2 -chem,3-maths) "id" is emaail id of  user 
            pl.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
