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
    public partial class SystemApplication : Form
    {
        public SystemApplication()
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText("System.FileType.txt");
            connection();
            yearOfBirth();
            mobilenumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountDetails ad = new AccountDetails();
            ad.ShowDialog();


        }

        private void SystemApplication_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void mobilenumber() {
            String[] usernamefilearray = File.ReadAllLines(Environment.CurrentDirectory + "\\System.FileType.txt");
            string username = usernamefilearray[0].ToString().Trim();

            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript = "SELECT mobile FROM table_one WHERE username='" + username + "';";

            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            mobile.Text = reader["mobile"].ToString();
        }

        public void connection() 
        {
            string[] usernamefilearray = File.ReadAllLines(Environment.CurrentDirectory + "\\System.FileType.txt");
            string username = usernamefilearray[0].ToString().Trim();

            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript = "SELECT email FROM table_one WHERE username='" + username + "';";
            //email.Text = userscript;
            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            email.Text = reader["email"].ToString();



            
        }
        public void yearOfBirth()
        {
            String[] usernamefilearray = File.ReadAllLines(Environment.CurrentDirectory + "\\System.FileType.txt");
            string username = usernamefilearray[0].ToString().Trim();

            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript = "SELECT yob FROM table_one WHERE username='" + username + "';";
            //email.Text = userscript;
            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            dob.Text = reader["yob"].ToString();
        
        }
        private void dob_TextChanged(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void runningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activities ac = new Activities();
            ac.ShowDialog();
        }
    }
}
