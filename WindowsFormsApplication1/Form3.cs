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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            connection();
        }

        public void connection() {
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript = "SELECT DISTINCT username FROM table_one;";
            MySqlCommand command = new MySqlCommand(userscript, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                comboBox1.Items.Add(reader["username"].ToString());


            }
        }
        private void button1_Click(object sender, EventArgs e)
            {
                String username;
                username = comboBox1.SelectedItem.ToString();
                File.WriteAllText("System.FileType.txt", username);
                MessageBox.Show("Welcome, " + username.Trim());
                SystemApplication sa = new SystemApplication();
                sa.ShowDialog();
                return;
            }
        private void button2_Click(object sender, EventArgs e)
        {
            Form pC = new PasswordChange(comboBox1.SelectedItem.ToString());
            pC.ShowDialog();
           

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}
