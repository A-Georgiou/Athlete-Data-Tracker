using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    public partial class AccountDetails : Form
    {
        SystemApplication sa = new SystemApplication();

        public AccountDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IMPORTANT
            //CODE NEEDS TO BE UPDATED TO DATABASE
            //IMPORTANT
            string[] usernamefilearray = File.ReadAllLines(Environment.CurrentDirectory + "\\System.FileType.txt");
            string username = usernamefilearray[0].ToString().Trim();


            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript;
            MySqlCommand command;
          //  if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "") {
           //     MessageBox.Show("Sorry, Please fill in all boxes before updating");
            //    return;
           // }

            try
            {
                if (textBox4.Text != "")
                {
                    userscript = "UPDATE table_one SET email='" + textBox4.Text + "' WHERE username='" + username + "';";
                    command = new MySqlCommand(userscript, con);
                    //email.Text = userscript;
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    sa.connection();
                }
                
            }
            catch { }

            try
            {
                if (textBox3.Text != "")
                {
                    userscript = "UPDATE table_one SET yob='" + int.Parse(textBox3.Text) + "' WHERE username='" + username + "';";
                    //email.Text = userscript;
                    con.Open();
                    command = new MySqlCommand(userscript, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    sa.yearOfBirth();
                }
            }
            catch { }
            
            try
            {
                if (textBox1.Text != "")
                {
                    userscript = "UPDATE table_one SET username='" + textBox1.Text + "'  WHERE username='" + username + "';";
                    //email.Text = userscript;
                    File.WriteAllText("System.FileType.txt", textBox1.Text);
                    con.Open();
                    command = new MySqlCommand(userscript, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
            catch { }
            
            try
            {
                if (mobile.Text != "")
                {
                    userscript = "UPDATE table_one SET mobile='" + mobiletext.Text + "'  WHERE username='" + username + "';";
                    con.Open();
                    command = new MySqlCommand(userscript, con);
                    command.ExecuteNonQuery();
                    con.Close();
                    sa.mobilenumber();
                }
            }
            catch 
            {
 
            }

        }
    }
}
