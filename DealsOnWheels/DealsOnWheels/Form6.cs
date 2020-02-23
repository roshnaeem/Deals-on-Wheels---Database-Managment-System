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
    public partial class Form6 : Form
    {
        DBConnect Connect = new DBConnect();
        public Form6()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text.Length == 16)
            {
                string query = "INSERT INTO DEALSONWHEELS.cars(carID, yearr, price, carname, category,BranchNo) VALUES(" + textBox8.Text + ","  + textBox7.Text + "," + textBox6.Text + ",'" + textBox10.Text + "','" + textBox4.Text+"'," + textBox5.Text+")";
                Connect.Insert(query);
                string query1 = "Insert INTO DEALSONWHEELS.cars_specs(carID, power, eng_size, transmission,eng_type,speed) VALUES (" + textBox8.Text + "," + textBox11.Text + "," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox9.Text + "'," + textBox1.Text + ")";
                Connect.Insert(query1);
                MessageBox.Show(null, "Transaction complete your car has been sold", "Transaction Sucessful");
              


            }
            else
            {
                MessageBox.Show(null, "Please enter a account No of 16 digits", "Enter 16 digits");
            };
            

            
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Visible = false;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
