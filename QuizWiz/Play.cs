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
    public partial class Play : Form
    { int sub;
        string id;
        int q = 1;
        int a = 1;
        int lvl;       // it is to determine the level (of all three subjects . will put conditions to determine which subjects's lvl we are talkinng about )
        int panelindex=0;   // this one is for changing panel color 
        int labelindex =0;   // this one is for changing label color 
        string uanswer;
        int Total_correct;   // for counting all the correct answers given by player
        int Total_wrong;     // for counting all the wrong answer given by player 
        int current_level;   //it will store the current level in which user is playing at ..()

        //for timer 
        int counter;
        bool isTimerRunning = false;

        string T_level;    // in this we will put the name of particular table (a/c to condition) to fetch the question from it (and it will be helpful in various condtions like - while updating the user answer ) 
        char clicked_opt;

        //this for the operation when we have used flip the question option
        int temp;
        

      


        public Play(int l,string s)     // 
        {
            InitializeComponent();
            sub = l;         //this is for subject i.e phy , chem , maths 
            id = s;         //id means email_id 
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;





            //timer 
             if(!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }

           





            current_level = 1; //for current level in which user is playing 



            T_level = "Level_1";  // it is to define the table namefrom  where other tasks (like - options updation , answer fetch ) will be done 
           
            //for physics 
            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string fetch = "select * from Level_1";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();

            }
            //for chemistry 
            if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string fetch = "select * from Level_1";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            //for mathematics  
            if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
                string fetch = "select * from Level_1";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Play_Load(object sender, EventArgs e)
        {
            //richTextBox1.AutoSize = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }




        //FUNCTIONS OF EACH SUBJECTS TO UPDATE THE USER ANSWER 

        //for answer updation in physics's tables 
        void opt_physics()
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
            string update = "update "+T_level+" set User_ans='"+clicked_opt+"' where Q_no=" + q;      // as the table name i.e "T_level" is already assigned in the click of 
            oc.Open();
            OleDbCommand od = new OleDbCommand(update, oc);
            od.ExecuteNonQuery();
            oc.Close();
        }

        //for answer updation in chemistry's tables 
        void opt_Chemistry()
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
            string update = "update " + T_level + " set User_ans='" + clicked_opt + "' where Q_no=" + q;
            oc.Open();
            OleDbCommand od = new OleDbCommand(update, oc);
            od.ExecuteNonQuery();
            oc.Close();
        }


        //for answer updation in mathematics's tables 
        void opt_Mathematics()
        {

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
            string update = "update " + T_level + " set User_ans= '" + clicked_opt + "' where Q_no=" + q;
            oc.Open();
            OleDbCommand od = new OleDbCommand(update, oc);
            od.ExecuteNonQuery();
            oc.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Tan;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.PapayaWhip;




            if (sub == 1)
            {
                clicked_opt = 'A';
                opt_physics();

            }
            else if (sub == 2)
            {
                clicked_opt = 'A';
                opt_Chemistry();
            }else if (sub == 3)
            {
                clicked_opt = 'A';
                opt_Mathematics();
            }


        }



        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.Tan;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.PapayaWhip;




            if (sub == 1)
            {
                clicked_opt = 'B';
                opt_physics();

            }
            else if (sub == 2)
            {
                clicked_opt = 'B';
                opt_Chemistry();
            }
            else if (sub == 3)
            {
                clicked_opt = 'B';
                opt_Mathematics();
            }


           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.Tan;
            button4.BackColor = Color.PapayaWhip;



            if (sub == 1)
            {
                clicked_opt = 'C';
                opt_physics();

            }
            else if (sub == 2)
            {
                clicked_opt = 'C';
                opt_Chemistry();
            }
            else if (sub == 3)
            {
                clicked_opt = 'C';
                opt_Mathematics();
            }


           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.Tan;





             if (sub == 1)
            {
                clicked_opt = 'D';
                opt_physics();

            }
            else if (sub == 2)
            {
                clicked_opt = 'D';
                opt_Chemistry();
            }
            else if (sub == 3)
            {
                clicked_opt = 'D';
                opt_Mathematics();
            }






        }

        // For operations in Physics database 
        void Nxt_Physics()
        {
            //this code is for when we have used "flip_the_question" lifeline 
            // whats happening here - as we click to "flip_the_Q" lifeline , first the value of "q" will be stored in a "temp" variable and 15 will be assigned in "q" (coz we have stored that extra lifeline question in Q_no 15)
            // now first we will check if the user has given the correct answer of the Question which is appeared after using lifline . if the answer is correct then we will go and fetch the correct answer of that question in which we used lifeline (flip_the_q)
            // so now if the flipped question's asswer is correct then that particular qustion's (q_no at which we have used lifeline ) User_ans will be updated with correct answer(it will also help to change the panel color according to the answer ) . and then we will assign the value of "temp" back to "q"
            // so that we will easily move to next question 



            if (q == 15)
            {
                OleDbConnection ott = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb"); // this path will be useful for both the queris i.e "uans" and "fetch"

              
                string uanss = "select Answer , User_ans from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter odd = new OleDbDataAdapter(uanss, ott);
                DataTable dt15 = new DataTable();
                odd.Fill(dt15);

                if (dt15.Rows[0]["User_ans"].ToString() == dt15.Rows[0]["Answer"].ToString())
                {


                    string qr = "select Answer from " + T_level + " where Q_no=" + temp;       //temp contains the question number in which we have used flip_the _question ww
                    OleDbDataAdapter odr = new OleDbDataAdapter(qr, ott);
                    DataTable dtr = new DataTable();
                    odr.Fill(dtr);

                    string temp_ans = dtr.Rows[0]["Answer"].ToString();
                    MessageBox.Show(temp_ans);

                    string upr = "update " + T_level + " set User_ans='" + temp_ans + "'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();


                }

                else if (dt15.Rows[0]["User_ans"].ToString() != dt15.Rows[0]["Answer"].ToString() && dt15.Rows[0]["User_ans"].ToString() != "Z") 
                {

                   
                    string upr = "update " + T_level + " set User_ans='L'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();
                }

                //after doing all the processes of lifeline assigning back the value of "q"(which was stored in "temp") so that we will fetch the next questions in ongoing sequence 
                q = temp;
            }

           
            //from here on all the usual process of next button 
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb"); // this path will be useful for both the queris i.e "uans" and "fetch"

            // mathcing user answer and correct answer and changing the color of panel according to user answer 
            string uans = "select Answer , User_ans from " + T_level + " where Q_no="+q;
            OleDbDataAdapter ot = new OleDbDataAdapter(uans, oc);
            DataTable dt1 = new DataTable();
            ot.Fill(dt1);
            

            if (dt1.Rows[0]["User_ans"].ToString() == "Z")

            {
                uanswer = "no_answer";
            }
           else  if (dt1.Rows[0]["User_ans"].ToString() == dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "correct";
                Total_correct++;
            }
            else if (dt1.Rows[0]["User_ans"].ToString() != dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "wrong";
                Total_wrong++;
               

            }

            // now incrementing the value of "q" (for fetchig the next question) and fetching the question 
            ++q;

            try
            {
           
                string fetch = "select * from "+T_level+" where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
                if (q == 10)
                {
                    button5.Text = "Submit";
                }


            }
            catch (Exception)
            {
                timer1.Stop();
               
                result rs = new result(Total_correct,Total_wrong,id,sub,current_level,T_level);
                rs.Show();
                this.Hide();
            }

        }




        // For operations in Chemistry database 
        void Nxt_Chemistry()
        {


            if (q == 15)
            {
                OleDbConnection ott = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");


                string uanss = "select Answer , User_ans from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter odd = new OleDbDataAdapter(uanss, ott);
                DataTable dt15 = new DataTable();
                odd.Fill(dt15);

                if (dt15.Rows[0]["User_ans"].ToString() == dt15.Rows[0]["Answer"].ToString())
                {


                    string qr = "select Answer from " + T_level + " where Q_no=" + temp;       //temp contains the question number in which we have used flip_the _question ww
                    OleDbDataAdapter odr = new OleDbDataAdapter(qr, ott);
                    DataTable dtr = new DataTable();
                    odr.Fill(dtr);

                    string temp_ans = dtr.Rows[0]["Answer"].ToString();
                    MessageBox.Show(temp_ans);

                    string upr = "update " + T_level + " set User_ans='" + temp_ans + "'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();


                }

                else if (dt15.Rows[0]["User_ans"].ToString() != dt15.Rows[0]["Answer"].ToString() && dt15.Rows[0]["User_ans"].ToString() != "Z")
                {


                    string upr = "update " + T_level + " set User_ans='L'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();
                }

                //after doing all the processes of lifeline assigning back the value of "q"(which was stored in "temp") so that we will fetch the next questions in ongoing sequence 
                q = temp;
            }

                                                                                                                                                
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");  // this path will be useful for both the queris i.e "uans" and "fetch"

            // mathcing user answer and correct answer and changing the color of panel according to user answer 
            string uans = "select Answer , User_ans from " + T_level + " where Q_no=" + q;
            OleDbDataAdapter ot = new OleDbDataAdapter(uans, oc);
            DataTable dt1 = new DataTable();
            ot.Fill(dt1);


            if (dt1.Rows[0]["User_ans"].ToString() == "Z")

            {
                uanswer = "no_answer";
            }
            else if (dt1.Rows[0]["User_ans"].ToString() == dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "correct";
                Total_correct++;
            }
            else if (dt1.Rows[0]["User_ans"].ToString() != dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "wrong";
                Total_wrong++;


            }


            // now incrementing the value of "q" (for fetchig the next question) and fetching the question 
            ++q;

                try
                   {
                
                   
                    string fetch = "select * from " + T_level + " where Q_no =" + q;
                    OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                    DataTable dt = new DataTable();
                    od.Fill(dt);

                    richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                    button1.Text = dt.Rows[0]["opt_1"].ToString();
                    button2.Text = dt.Rows[0]["opt_2"].ToString();
                    button3.Text = dt.Rows[0]["opt_3"].ToString();
                    button4.Text = dt.Rows[0]["opt_4"].ToString();
                    if (q == 10)
                    {
                        button5.Text = "Submit";
                    }

                
                   }
            catch (Exception)
            {
                timer1.Stop();
                result rs = new result(Total_correct,Total_wrong, id, sub,current_level,T_level);
                rs.Show();
                this.Hide();
            }
        }





        // For operations in Mathematics  database 
        void Nxt_Mathematics()
        {

            if (q == 15)
            {

                OleDbConnection ott = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");

                string uanss = "select Answer , User_ans from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter odd = new OleDbDataAdapter(uanss, ott);
                DataTable dt15 = new DataTable();
                odd.Fill(dt15);

                if (dt15.Rows[0]["User_ans"].ToString() == dt15.Rows[0]["Answer"].ToString())
                {

                   
                    string qr = "select Answer from " + T_level + " where Q_no=" + temp;       //temp contains the question number in which we have used flip_the _question ww
                    OleDbDataAdapter odr = new OleDbDataAdapter(qr, ott);
                    DataTable dtr = new DataTable();
                    odr.Fill(dtr);

                    string temp_ans = dtr.Rows[0]["Answer"].ToString();
                    MessageBox.Show(temp_ans);

                    string upr = "update " + T_level + " set User_ans='" + temp_ans + "'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();


                }

                else if (dt15.Rows[0]["User_ans"].ToString() != dt15.Rows[0]["Answer"].ToString() && dt15.Rows[0]["User_ans"].ToString() != "Z")
                {


                    string upr = "update " + T_level + " set User_ans='L'where Q_no=" + temp;
                    OleDbCommand odc = new OleDbCommand(upr, ott);
                    ott.Open();
                    odc.ExecuteNonQuery();
                    ott.Close();
                }

                //after doing all the processes of lifeline assigning back the value of "q"(which was stored in "temp") so that we will fetch the next questions in ongoing sequence 
                q = temp;
            }

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb"); // this path will be useful for both the queris i.e "uans" and "fetch"

            // mathcing user answer and correct answer and changing the color of panel according to user answer 
            string uans = "select Answer , User_ans from " + T_level + " where Q_no=" + q;
            OleDbDataAdapter ot = new OleDbDataAdapter(uans, oc);
            DataTable dt1 = new DataTable();
            ot.Fill(dt1);

            if (dt1.Rows[0]["User_ans"].ToString() == "Z")

            {
                uanswer = "no_answer";
            }
           else  if (dt1.Rows[0]["User_ans"].ToString() == dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "correct";
                Total_correct++;
            }
            else if (dt1.Rows[0]["User_ans"].ToString() != dt1.Rows[0]["Answer"].ToString())
            {
                uanswer = "wrong";
                Total_wrong++;

            }


            // now incrementing the value of "q" (for fetchig the next question) and fetching the question 
            ++q;
            try
            {
               
                   
                    string fetch = "select * from " + T_level + " where Q_no=" + q;
                    OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                    DataTable dt = new DataTable();
                    od.Fill(dt);

                    richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                    button1.Text = dt.Rows[0]["opt_1"].ToString();
                    button2.Text = dt.Rows[0]["opt_2"].ToString();
                    button3.Text = dt.Rows[0]["opt_3"].ToString();
                    button4.Text = dt.Rows[0]["opt_4"].ToString();
                    if (q == 10)
                    {
                        button5.Text = "Submit";
                    }

               
            }
            catch (Exception)
            {
                timer1.Stop();
                result rs = new result(Total_correct,Total_wrong, id, sub, current_level,T_level );
                rs.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            
            counter = 61;
            //timer 
            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }



            //turning on the visibility of all the 4 buttons in case if they were hid because of lifeline
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;






            //for physics 
            if (sub == 1)
            {
                Nxt_Physics();
            }
            else if (sub == 2)
            {
                Nxt_Chemistry();
            }
            else if (sub == 3)
            {
                Nxt_Mathematics();
            }




            //for bringing back the original color of buttons 
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.PapayaWhip;





            Panel[] panels = { panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20, panel21, panel22 };    //it is an array of type "panel" (which means we can store multiple panels inside it . just like in an array of integer we can store multiple integer values )in C# windowws form we can make arrays of different controls 
            Label[] labels = { label12, label13, label14, label15, label16, label17, label18, label19, label20, label21 };    // it is an array of type "label" we can store multiple labels  inside it 



            if (uanswer == "correct")
            {
                panels[panelindex].BackColor = Color.Green;

            }
            else if (uanswer == "wrong")
            {
                panels[panelindex].BackColor = Color.Firebrick;
            }
            else if (uanswer == "no_answer")
            {
                panels[panelindex].BackColor = Color.LightGoldenrodYellow;
            }
            ++panelindex;
            ++labelindex;





            

            


            // FOR CHANGING THE PANEL COLOR ACCORDIND TO USER ANSWER 









        }

        private void button7_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }






            T_level = "Level_2";
            current_level = 2;

            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string fetch = "select * from Level_2";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();

            }
            //for chemistry 
            if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string fetch = "select * from Level_2";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            //for mathematics  
            if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
                string fetch = "select * from Level_2";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
        }

        //FOR UPDATING USER ANSWER "Z" WHEN USER CLICKS "CLEAR" BUTTON
        
        //For physics
        void Z_physics()
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
            string update = "update "+T_level+" set User_ans='Z' where Q_no=" + q;
            OleDbCommand od = new OleDbCommand(update, oc);
            oc.Open();
            od.ExecuteNonQuery();
            oc.Close();
        }

        //For chemistry
        void Z_chemistry()
        {
            OleDbConnection oc = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = E:\\QuizWiz_Database\\Chemistry.accdb");
            string update = "update " + T_level + " set User_ans='Z' where Q_no=" + q;
            OleDbCommand od = new OleDbCommand(update, oc);
            oc.Open();
            od.ExecuteNonQuery();
            oc.Close();
        }

        //for mathematics
        void Z_mathematics()
        {
            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
            string update = "update " + T_level + " set User_ans='Z' where Q_no=" + q;
            OleDbCommand od = new OleDbCommand(update, oc);
            oc.Open();
            od.ExecuteNonQuery();
            oc.Close();
        }






        private void button17_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.PapayaWhip;

            if (sub == 1)
            {
                Z_physics();
            }
            else if (sub == 2)
            {
                Z_chemistry();
            }
            else if (sub == 3)
            {
                Z_mathematics();
            }

           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }



            T_level = "Level_3";
            current_level = 3;

            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string fetch = "select * from Level_3";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();

            }
            //for chemistry 
            if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string fetch = "select * from Level_3";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            //for mathematics  
            if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
                string fetch = "select * from Level_3";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }


            T_level = "Level_4";
            current_level = 4;

            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string fetch = "select * from Level_4";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();

            }
            //for chemistry 
            if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string fetch = "select * from Level_4";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            //for mathematics  
            if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
                string fetch = "select * from Level_4";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {


            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 100;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 100;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }





            T_level = "Level_5";
            current_level = 5;
            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string fetch = "select * from Level_5";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();

            }
            //for chemistry 
            if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string fetch = "select * from Level_5";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            //for mathematics  
            if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");
                string fetch = "select * from Level_5";
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Play_Load_1(object sender, EventArgs e)
        {


            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string F_name = "select Name from Player_Details where Email_ID ='" + id + "' ";
            OleDbDataAdapter od = new OleDbDataAdapter(F_name, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

            richTextBox2.Text = dt.Rows[0]["Name"].ToString();

            if (sub == 1)  //for physics 
            {
                Physics();
            }
            else if (sub == 2)  //for chemistry 
            {
                Chemistry();
            }
            else if (sub == 3)  // for mathematics 
                {
                Mathematics();
                } 



        }
         void Physics()
        {

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string fetch = "select Physics from Player_Details where Email_ID='" + id + "'";     //there  are columns in databse {Player_details} i.e Physics , Chemistry , Mathematics  which will store the current level of each player  . Here we are fetching the level of physics 
            OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

            lvl = Convert.ToInt32(dt.Rows[0]["Physics"].ToString());   // it will fetch the level of subject physics of a particular player (in physics , chemistry , mathematics column each player's level is stored which will be fethched by their email id )



            //enabling the start button according to the current level of user 
            if (lvl == 1)
                button6.Enabled = true;
            else if (lvl == 2)
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else if (lvl == 3)
            {

                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
            else if (lvl == 4)
            {


                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
            else if (lvl == 5)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else if (lvl == 6)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
            }
            else if (lvl == 7)

            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
            }
            else if (lvl == 8)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
            }
            else if (lvl == 9)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
            }
            else if (lvl == 10)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
            }
        }
        void Chemistry()
        {

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string fetch = "select Chemistry from Player_Details where Email_ID='" + id + "'";
            OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

             lvl = Convert.ToInt32(dt.Rows[0]["Chemistry"].ToString());



            //enabling the start button according to the current level of user 
            if (lvl == 1)
                button6.Enabled = true;
            else if (lvl == 2)
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else if (lvl == 3)
            {

                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
            else if (lvl == 4)
            {


                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
            else if (lvl == 5)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else if (lvl == 6)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
            }
            else if (lvl == 7)

            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
            }
            else if (lvl == 8)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
            }
            else if (lvl == 9)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
            }
            else if (lvl == 10)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
            }

        }
        void Mathematics()
        {

            OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Quiz_Authentication.accdb");
            string fetch = "select Mathematics from Player_Details where Email_ID='" + id + "'";
            OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
            DataTable dt = new DataTable();
            od.Fill(dt);

            int lvl = Convert.ToInt32(dt.Rows[0]["Mathematics"].ToString());

            //enabling the start button according to the current level of user 
            if (lvl == 1)
                button6.Enabled = true;
            else if (lvl == 2)
            {
                button6.Enabled = true;
                button7.Enabled = true;
            }
            else if (lvl == 3)
            {

                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
            else if (lvl == 4)
            {


                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
            else if (lvl == 5)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
            else if (lvl == 6)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
            }
            else if (lvl == 7)

            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
            }
            else if (lvl == 8)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
            }
            else if (lvl == 9)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
            }
            else if (lvl == 10)
            {
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                button14.Enabled = true;
                button15.Enabled = true;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {


            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 100;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 100;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }


            T_level = "Level_6";
            current_level = 6;
        }

        private void button12_Click(object sender, EventArgs e)
        {

            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 100;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 100;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }



            T_level = "Level_7";
            current_level=7;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;


            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 100;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 100;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }




            T_level = "Level_8";
            current_level = 8;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 100;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 100;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }



            T_level = "Level_9";
            current_level = 9;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            panel23.Visible = false;
            label25.Visible = false;
            label22.Visible = false;

            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }





            T_level = "Level_10";
            current_level = 10;
        }



        void next()
        {
            if (sub == 1)
            {
                Nxt_Physics();
            }
            else if (sub == 2)
            {
                Nxt_Chemistry();
            }
            else if (sub == 3)
            {
                Nxt_Mathematics();
            }



            //turning on the visibility of all the 4 buttons in case if they were hid because of lifeline
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;






            //for bringing back the original color of buttons 
            button1.BackColor = Color.PapayaWhip;
            button2.BackColor = Color.PapayaWhip;
            button3.BackColor = Color.PapayaWhip;
            button4.BackColor = Color.PapayaWhip;








            Panel[] panels = { panel13, panel14, panel15, panel16, panel17, panel18, panel19, panel20, panel21, panel22 };    //it is an array of type "panel" (which means we can store multiple panels inside it . just like in an array of integer we can store multiple integer values )in C# windowws form we can make arrays of different controls 
            Label[] labels = { label12, label13, label14, label15, label16, label17, label18, label19, label20, label21 };    // it is an array of type "label" we can store multiple labels  inside it 



            if (uanswer == "correct")
            {
                panels[panelindex].BackColor = Color.Green;

            }
            else if (uanswer == "wrong")
            {
                panels[panelindex].BackColor = Color.Firebrick;
            }
            else if (uanswer == "no_answer")
            {
                panels[panelindex].BackColor = Color.LightGoldenrodYellow;
            }
            ++panelindex;
            ++labelindex;


            if (!isTimerRunning)
            {
                if (counter == 0) // start a new timer if there is no time remaining
                {
                    counter = 60;
                    timer1.Interval = 1000;
                    // label1.Text = counter.ToString();
                }
                else // resume from the remaining time
                {
                    timer1.Interval = 1000;
                    // label1.Text = remainingTime.ToString();
                }
                timer1.Start();
                isTimerRunning = true;
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter--;  // so initially the value of  "counter" variable  is 60 and then after each second timer will decrease its value till 0 
            label24.Text = counter.ToString();   // the updated value of "counter" will be displayed in label24

            if (counter == 0) //when the value of counter comes to 0 then it will enter in this if condition and execute following tasks  
            {
                timer1.Stop();     //it will stop the timer 
                MessageBox.Show("Time's up!");
                counter = 60;        //we will again initialize the value of "counter" with 60 (for next question )

                next();       // now this method will be called . basically we have fetched the next question in this method , which means when the time limit of one questions is completed i.e 2 min (when timer comes to 0 ) then we will initialize the counter with 120 and fetch the next question  

                if (q < 11)
                {
                    timer1.Start();   //after fetching the next question we will again start the timer (counter = 120 is done already so countdown will again start with 120 )
                }
            }
        }






        private void button18_Click(object sender, EventArgs e)
        {


            button18.Enabled = false;
            
            // making visible all the option buttons in case if user has used "double down" lifeline before using fip_the_q in the same question 

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;


           




            temp = q;
            q = 15;
            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");

                string fetch = "select * from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            else if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");

                string fetch = "select * from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }
            else if (sub==3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Mathematics.accdb");

                string fetch = "select * from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(fetch, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);

                richTextBox1.Text = dt.Rows[0]["Questions"].ToString();
                button1.Text = dt.Rows[0]["opt_1"].ToString();
                button2.Text = dt.Rows[0]["opt_2"].ToString();
                button3.Text = dt.Rows[0]["opt_3"].ToString();
                button4.Text = dt.Rows[0]["opt_4"].ToString();
            }


        }

        private void button19_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            counter = Convert.ToInt32(label24.Text.ToString()) + 60;
            timer1.Start();
            button19.Enabled = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string match="";

            if (sub == 1)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Physics.accdb");
                string uans = "select Answer  from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(uans, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);
                match = dt.Rows[0]["Answer"].ToString();

            }
            else if (sub == 2)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string uans = "select Answer  from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(uans, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);
                match = dt.Rows[0]["Answer"].ToString();
            }
            else if (sub == 3)
            {
                OleDbConnection oc = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\\QuizWiz_Database\\Chemistry.accdb");
                string uans = "select Answer  from " + T_level + " where Q_no=" + q;
                OleDbDataAdapter od = new OleDbDataAdapter(uans, oc);
                DataTable dt = new DataTable();
                od.Fill(dt);
                match = dt.Rows[0]["Answer"].ToString();
            }



            // hiding the two worng options 
            if (match == "A")
            {
                button2.Visible = false;
                button3.Visible = false;
            }
            else if (match == "B")
            {
                button3.Visible = false;
                button4.Visible = false;
            }
            else if (match == "C")
            {
                button4.Visible = false;
                button1.Visible = false;
                
            }else if (match == "D")
            {
                button1.Visible = false;
                button2.Visible = false;
            }

            button20.Enabled = false;
            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}




