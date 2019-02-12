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
    public partial class Register : Form
    {
        Form1 login;
        public Register(Form1 lf)
        {
            login = lf;
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            //Connects to MYSQL database
            connection();
            this.Close();
        }

        private void connection() 
        {
            //This code checks if the username is blank
            if (username.Text == "")
                return;
            //This code checks if the password field is blank
            if (password.Text == "")
                return;
            //This code checks if the email field is blank
            if (email.Text == "")
                return;
            //This code checks if the mobile field is blank
            if (mobile.Text == "")
                return;

            //This code attempts the take the text entered into the year of birth field and test if the user entered an integer
            try 
            {
                int.Parse(yob.Text);
            }
            catch 
            {
                //This alerts the user they have entered an incorrect variable for the year of birth
                MessageBox.Show("Please correct your year of birth.");
                return;
            }

            //This code builds a connection to the database
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);

            //This will insert all of the values entered by the user into all of the correct fields, all the checks have been made beforehand to make sure no errors will occur
            string userscript = "INSERT INTO table_one (username, password, email, yob, mobile) VALUES ('" + username.Text.Trim().ToLower() + "','" + password.Text.Trim().ToLower() + "','" + email.Text.Trim().ToLower() + "','" + yob.Text.Trim().ToLower() + "','" + mobile.Text.Trim().ToLower() + "');";
            MySqlCommand command = new MySqlCommand(userscript, con);
            con.Open();
            try{
            command.ExecuteNonQuery();
            MessageBox.Show("The User has been created successfully!", "welcome " + username.Text);
            }catch{
            MessageBox.Show("Error! Username already in use");
            }
        }
    }
}
