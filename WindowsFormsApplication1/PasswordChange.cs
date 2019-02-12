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
    public partial class PasswordChange : Form
    {
        String user_string;
        public PasswordChange(String username)
        {
            InitializeComponent();
            user_string = username;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript;
            MySqlCommand command;
            if (passwordBox.Text == "")
            {
                MessageBox.Show("Sorry, Please fill in the box");
                return;
            }

            try
            {
                userscript = "UPDATE table_one SET password='" + passwordBox.Text + "' WHERE username='" + user_string + "';";
                command = new MySqlCommand(userscript, con);
                //email.Text = userscript;
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Update is complete, password set");
            }
            catch
            {
            }
            return;
        }
    }
}
