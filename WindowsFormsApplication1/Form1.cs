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
using System.Security.Cryptography;
using System.Security.AccessControl;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string path = "C:/Login.System";
        public Form1()
        {
            InitializeComponent();
        }

        private void connection()
        {   
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);
            string userscript = "SELECT password FROM table_one WHERE username='" + username.Text.Trim() +"';";
            MySqlCommand command = new MySqlCommand(userscript, con);
            con.Open();
            if (username.Text == "administrator")
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["password"].ToString() == password.Text.Trim())
                    {
                        File.WriteAllText("System.FileType.txt", username.Text);
                        MessageBox.Show("Welcome, " + username.Text.Trim());
                        Form form3 = new Form3();
                        form3.ShowDialog();
                        return;
                    }
                }
            }
            else
            {
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["password"].ToString() == password.Text.Trim())
                    {
                        File.WriteAllText("System.FileType.txt", username.Text);
                        MessageBox.Show("Welcome, " + username.Text.Trim());
                        SystemApplication sa = new SystemApplication();
                        sa.ShowDialog();
                        return;
                    }
                }
            }

            MessageBox.Show("Sorry, You have entered incorrect login information.");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            connection();  
        }

        private void register_Click(object sender, EventArgs e)
        {
            Register rf = new Register(this);
            rf.ShowDialog();
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
        }

        public string GetMD5(string text) {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < result.Length; i++) {
               str.Append(result[i].ToString("x2"));
            }
            return str.ToString();
        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
