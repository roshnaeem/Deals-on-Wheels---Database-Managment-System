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

namespace DealsOnWheels
{
    public partial class Form1 : Form
    {
        DBConnect connect = new DBConnect();
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           /* Form2 frm2 = new Form2();
            frm2.Show();
            this.Visible = false;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "Select password1 from DEALSONWHEELS.login where username='" + textBox1.Text + "'";
            string[] att = { "password1" };
            List<string>[] result = connect.Select(query, att);
            string password;
            bool wrongpas = true;
            try
            {
                password = result[0][0];
            }
            catch(Exception ex)
            {
                password = "LadyOompaLoompa";
                MessageBox.Show(null, "The username entered is not registered","Invalid User");
                textBox1.Text = "";
                wrongpas = false;
            }
            if (textBox2.Text == password)
            {
                Form5 men = new Form5();
                men.Show();
                this.Visible = false;
                wrongpas = false;
                
            }
            else
            {
                if (wrongpas)
                {
                    MessageBox.Show(null, "The password entered is invalid", "Invalid password");
                }
                
                textBox2.Text = "";
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Visible = false;
        }
    }
    class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "MySQL Community Server (GPL)";
            database = "DEALSONWHEELS";
            uid = "root";
            password = "seecs@123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "PORT=" + "3306" + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert(string query)
        {
            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        
        

        //Delete statement
        public void Delete(string query)
        {
            //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public List<string>[] Select(string query, string[] attributes)
        {


            //Create a list to store the result
            List<string>[] list = new List<string>[attributes.Length];
            for (int x = 0; x < attributes.Length; x++)
            {
                list[x] = new List<string>();
            }

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    for (int x = 0; x < attributes.Length; x++)
                    {
                        list[x].Add(dataReader[attributes[x]] + "");
                    }
                }
                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed

                
                return list;
            }
            else { return list; }
        }
    }
}
