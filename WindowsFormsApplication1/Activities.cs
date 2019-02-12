using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

//This will specify the class the application is running from
namespace WindowsFormsApplication1
{
    ///<summary>
    ///This class defines the activities form</summary>
    ///<remarks>
    ///This is the remarks, This will allow the XML documentation to find my code and export it
    ///</remarks>
    public partial class Activities : Form
    {
      
        public Activities() //The main component of the program, this will initialise everything
        {
            InitializeComponent();  //This will initialise the entire form
            connection();
        }
        //Generic connection to database, this should be used by running to determine the calories burnt based on a calculated speed
        //The method takes the input of speed and the table which it is referencing this is good code and can aid work in the future
        public static double connection(double speed, String table)
        {
            Math.Round(speed);  //This method will round the speed from its double to its closest usable integer
            double calories;    //This generates the double calories

            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");    //This specifies what database to access and the username/password for that
                MySqlConnection con = new MySqlConnection(connectionString);
                string userscript = "SELECT calories FROM " + table + " WHERE speed<='" + speed + "';"; //This is the action to be performed on the table
            
            con.Open(); //Opens the connection to the database/table
            
            //This completes the command specified by the "userscript"
            MySqlCommand command = new MySqlCommand(userscript, con);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                calories = Double.Parse(reader["calories"].ToString()); //This will take the outputted calories and store it in our variable calories which is to be returned
                reader.Close();
            

            con.Close();
            return calories;    //This finally returns the variable calories back to the main function of the program
        }

        private void button1_Click(object sender, EventArgs e)  //When the calculate_running button is clicked it will complete this method
        {
            //Double and Time generated as methods due to the fact they need calculations to be performed on them
            double Time;
            double Distance;

            //The program will attempt to convert the string entered into 2 textboxes into doubles
            try
            {
                Time = Convert.ToDouble(textBox2.Text);
                Distance = Convert.ToDouble(textBox1.Text);
                //if it works successfully the the time and distance will be logged later in the method
            }
            catch
            {
                MessageBox.Show("Entered incorrect value for time/distance"); //If the user did not enter a valid double the program will correct this mistake without crashing
                return;
            }

            //Convert their distance and time to integers
            double Speed;
            if (Time==0||Distance==0) 
            {
                MessageBox.Show("You have entered an incorrect Value for Distance/Time. Correct This and Try Again.");  //if the distance or the time entered is equal to one, no operation can be performed therefore this is an error
                return;//Return the user to try again
            }

            Speed = Distance / (Time / 60); //This will use the equation to calculate MPH, by dividing the minutes by 60 you find the hours
            
            if (Speed < 5) 
            {
                MessageBox.Show("Your speed is too slow to be logged.");    //A speed lower than five is most likely an error and is treated as such
                return; //return the user to try again
            }
            else if (Speed > 10)
            {
                MessageBox.Show("You are going too fast for this data to be logged."); //Any speed faster than ten is very quick and most likely an error and is treated as such
                return; //return the user to try again
            }

            //These two lines will take the speed and the calories and output them in text boxes to the user
            textBox3.Text = Convert.ToString(connection(Speed, "running_table_"));
            textBox4.Text = Convert.ToString(Speed);
            
            //The username is generated from a temporary text file created at setup and is stored in the variable "username"
            String username = File.ReadAllText("System.FileType.txt");
            //All of the users data even including their date is logged into the database
            Log_data_cycling(username, "Running", Time, Distance, Speed, connection(Speed, "running_table_"));

            //All databases are cleared and emptied for later use, it is also to avoid any of the users "spamming" the table with information that could cause errors
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            //After the user has entered there information it will refresh the team picker and the connection
            this.sports_logTableAdapter5.Fill(this.traininglogDataSet5.sports_log);
            this.sports_logTableAdapter7.Fill(this.traininglogDataSet7.sports_log);
            connection();
        }

        public static double connection_cycling(double speed)
        {

            Math.Round(speed);  //This method will round the speed from its double to its closest usable integer
            double calories;    //This will create a variable of type "double" called calories

            //This will create the connection with the database
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");    //This takes in details such as the databases username and password in order to connect
            MySqlConnection con = new MySqlConnection(connectionString);

            //The userscript is SQL query code that is sent to the data to parse the information for our program
            string userscript = "SELECT calories FROM cycling_table_ WHERE start_speed<='" + speed + "' AND end_speed>='" + speed + "';";

            //this opens the connection to the database
            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);

            MySqlDataReader reader = command.ExecuteReader();   //The reader is used to itterate through each row in the database and complete an action
            reader.Read();  //This tells the reader to execute and complete commands below
                calories = Double.Parse(reader["calories"].ToString());     //The calories are parsed from type string into type Double and then returned to the user.

            reader.Close(); //This closes the reader and is needed to stop any further errors caused by an unclosed reader

            con.Close();
            return calories;    //This will return the variable calories back to the user
        }

        private void button4_Click(object sender, EventArgs e)  //When cycling_button is clicked it will execute this method
        {
            //Time, Speed and Distance are created or converted from text boxes this is good code as it allows programmers to see what exact variables are going to be used in the method
            double Time = Convert.ToDouble(textBox14.Text);
            double Distance = Convert.ToDouble(textBox15.Text);
            double Speed;

            //If time or Distance are set to 0 this must be a mistake so the user is alerted of their mistake and asked to try and ammend this
            if (Time == 0 || Distance == 0)
            {
                //This will pop-up a window for the user alerting them exactly of their mistake and this will prevent the program from crashing since you cannot divide by 0
                MessageBox.Show("You have entered an incorrect Value for Distance/Time. Correct This and Try Again.");
                return;
            }

            //This will generate a miles per hour for user since speed is equal to distance over time
            Speed = Distance / (Time / 60); //Since the user inputs time in minutes, time/60 gives you hours
            
            //If the speed is less than 5 then clearly this speed is too slow to be logged into the table
            if (Speed < 5)
            {
                MessageBox.Show("Your speed is too slow to be logged.");
                return;
            }
            else if (Speed > 10)    //If the speed is greater than 10 then it is most likely too fast to be logged.
            {
                MessageBox.Show("You are going too fast for this data to be logged.");
                return;
            }

            //The user who is currently logged in, their username is needed to be entered into the table. This will find that
            String username = File.ReadAllText("System.FileType.txt");
            //This will connect with the database and find calories burnt and the speed and output it to the text boxes
            textBox13.Text = Convert.ToString(connection_cycling(Speed)*(Time/60));
            textBox9.Text = Convert.ToString(Speed);

            //This will log the data from the user entered and refresh all of the data grid's so the user can compare their new times
            Log_data_cycling(username, "Cycling", Time, Distance, Speed, connection_cycling(Speed));
            this.sports_logTableAdapter5.Fill(this.traininglogDataSet5.sports_log);
            this.sports_logTableAdapter7.Fill(this.traininglogDataSet7.sports_log);
            connection();

        }

        private void button3_Click(object sender, EventArgs e)  //When the swimming_button is clicked it will execute this code
        {
            //This will set the selected choice of the user equal to a string variable
            string selection = comboBox1.Text.ToLower();
            double time = double.Parse(textBox11.Text);

            //If a user enters 0 as a time this will be flagged as an incorrect value and will request the user to try again before returning to avoid a crash.
            if (time == 0)
            {
                MessageBox.Show("You have entered an incorrect Value for Time. Correct This and Try Again.");
                return; //Returns the user to attempt with correct data
            }

            //This will make sure time is in hours not minutes
            time = time / 60;

            //This code will take a user friendly string the user selects and convert it to a computer friendly string for the computer
            if (selection == "freestyle (fast)") {
                selection = "freestyle_fast";   //The computer can understand freestyle_fast it cannot understand "freestyle (fast)"
            }else if(selection == "freestyle (slow)"){
                selection="freestyle_slow";
            }
            
            //This will set the swimming text box for calories burnt by sending a query to the database with users information
            textBox10.Text = (connection_swimming(selection, "swimming_table_")*time).ToString();
            //This will find the user's username for the database
            String username = File.ReadAllText("System.FileType.txt");

            //This code will log all of the users information and refresh all of the data grids for the users new time
            Log_data_cycling(username, "Swimming", time*60, 0, 0, (connection_swimming(selection,"swimming_table_")*time));
            this.sports_logTableAdapter5.Fill(this.traininglogDataSet5.sports_log);
            this.sports_logTableAdapter7.Fill(this.traininglogDataSet7.sports_log);
            connection();
        }
        public static double connection_swimming(String selection, String table)
        {
            
            double calories;    //Creates a variable names calories and makes it a double

            //This will set the swimming text box for calories burnt by sending a query to the database with users information
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");    

            //This will generate the connection to the database
            MySqlConnection con = new MySqlConnection(connectionString);

            //The userscript is the query sent to the database to be parsed by the program
            string userscript = "SELECT calories FROM " + table + " WHERE style='" + selection + "';";

            //This code opens the connection
            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            calories = Double.Parse(reader["calories"].ToString());
            reader.Close();
            con.Close();
            return calories;

        }

        private void Activities_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'traininglogDataSet7.sports_log' table. You can move, or remove it, as needed.
            this.sports_logTableAdapter7.Fill(this.traininglogDataSet7.sports_log);
            
            // TODO: This line of code loads data into the 'traininglogDataSet5.sports_log' table. You can move, or remove it, as needed.
            this.sports_logTableAdapter5.Fill(this.traininglogDataSet5.sports_log);
        }

        public void Log_data_cycling(String username, String sport, double time, double distance, double speed, double calories) {
            //This code generates the Date Variable by taking in the current time the data is logged
            String date = DateTime.Now.ToString();
            
            //This code builds the connection to the database and takes in all information of the traininglog
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);

            //The userscript is used to send a query to the mySQL database
            string userscript = "INSERT INTO sports_log (user_string, sport, date, time, speed, distance, calories) VALUES ('" + username.Trim() + "','" + sport + "','" + date + "','" + time + "','" + speed + "','" + distance + "','" + calories + "');";
            MySqlCommand command = new MySqlCommand(userscript, con);
            con.Open();
            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("The Data has been logged");
                this.sports_logTableAdapter5.Fill(this.traininglogDataSet5.sports_log);
                this.sports_logTableAdapter7.Fill(this.traininglogDataSet7.sports_log);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unknown Error " + e);
            }
        }

        //The connection function is used to build a connection to the traininglog database and to display the team pick
        public void connection()
        {
            //Builds the connection that selects the top 8 users based on calories
            string connectionString = ("Server=localhost;user id=db_user;password=microsoft;Database=traininglog;");
            MySqlConnection con = new MySqlConnection(connectionString);

            //Distinct user_string makes sure the same username isnt selected twice
            string userscript = "SELECT DISTINCT user_string FROM traininglog.sports_log ORDER BY 'calories' DESC LIMIT 8;";

            //Opens a connection to the Mysql Database
            con.Open();
            MySqlCommand command = new MySqlCommand(userscript, con);

            //Creates the reader which will itterate through each of the rows in the table designated by the userscript
            MySqlDataReader reader = command.ExecuteReader();
            int i = 1;
            while (reader.Read())
            {
                //Itterate through each of the rows in the table and set each line of the text box to the column username
                
                textBox12.Text = textBox12.Text + Environment.NewLine + i + ". " + reader["user_string"].ToString();
                i = i + 1;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
               // File.CreateText("teampick.txt");
                //File.WriteAllText("teampick.txt", textBox12.Text);
                File.WriteAllText("C:/Users/" + Environment.UserName + "/Desktop/teampick.txt", "_TEAM PICK_");
                File.AppendAllText("C:/Users/" + Environment.UserName + "/Desktop/teampick.txt", textBox12.Text);
                MessageBox.Show("Task Complete");

            }
            catch { 
            }
        }
    }
}
