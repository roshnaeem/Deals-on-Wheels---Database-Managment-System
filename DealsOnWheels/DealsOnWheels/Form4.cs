using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealsOnWheels
{
    public partial class Form4 : Form
    {
        DBConnect connect = new DBConnect();
        public Form4()
        {
            
            InitializeComponent();
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            string carprize = "" ;
            string carname = "";
            string query0 = "Select * from DEALSONWHEELS.cars where carId= " + textBox3.Text;
            string[] att1 = { "carname" , "price" };
        
            List<string>[] result1 = connect.Select(query0, att1);

            try {
                carprize = result1[1][0];
                carname = result1[0][0];

               }
            catch (Exception ex) {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                textBox3.Text = "";
                MessageBox.Show(null, "This is not a valid car", "Invalid Car");

            }
                

            
            if (textBox1.Text.Length == 16)
            {
                string query = "Select * from DEALSONWHEELS.credit_card where bankNo = '" +textBox1.Text.Substring(0,4) + "'";
                string[] att = { "bankNo" };
                List<string>[] result = connect.Select(query, att);
                string bank;
              
                try
                {
                    bank = result[0][0];
                    label4.Text = "Transaction is completed";
                    label5.Text = "You Bought the car: " + carname;
                    label6.Text = "For: $" + carprize;
                    
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    string query23 = "DELETE FROM cars WHERE carname ='" + carname+"'";
                    connect.Delete(query23);
                }
                catch (Exception ex) {
                    MessageBox.Show(null, "The credit card no does not belong to any bank", "Invalid cardID");
                    textBox1.Text = "";
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                }; 
                    
                
            }
            else
            {
                MessageBox.Show(null, "Please enter a creditNo of 16 digits", "Enter 16 digits"); 
            };

            //  string query = "DELETE FROM tableinfo WHERE name = 'John Smith'";
        


    }

        private void label14_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Visible = false;
        }
    }
}
