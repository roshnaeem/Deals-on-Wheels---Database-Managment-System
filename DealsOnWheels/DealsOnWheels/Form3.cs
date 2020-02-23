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
    public partial class Form3 : Form
    {
        DBConnect connect = new DBConnect();
        
        public Form3()
        {
            InitializeComponent();
            
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label15.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "Select * from DEALSONWHEELS.cars where carname='"+textBox1.Text+"'";
            Console.WriteLine(query);
            string[] att = { "CarID", "yearr", "price", "carname", "category" };
            List<string>[] result = connect.Select(query, att);
            try
            {
                label2.Text = result[0][0];
                label5.Text = result[1][0];
                label6.Text = result[2][0];
                label4.Text = result[3][0];
                label7.Text = result[4][0];
                label2.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label15.Visible = true;
                string query1 = "Select power from DEALSONWHEELS.cars_specs where CarId="+ label2.Text;
                string[] att1 = { "power",};
                List<string>[] result1 = connect.Select(query1, att1);
                try
                {
                    label15.Text = result1[0][0];
                    
                    label15.Visible = true;
                    

                }
                catch (Exception ex)
                {
                    //SORRY THIS CAR IS NOT AVAILABLE
                    MessageBox.Show(null, "SORRY THIS CAR IS NOT AVAILABLE", "Unavailable car");
                    textBox1.Text = "";
                    label15.Visible = false;
                    label2.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    label15.Visible = false;

                }

            }


            
            catch(Exception ex)
            {
                //SORRY THIS CAR IS NOT AVAILABLE
                MessageBox.Show(null, "SORRY THIS CAR IS NOT AVAILABLE", "Unavailable car");
                textBox1.Text = "";
                label2.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label15.Visible = false;
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Visible = false;
        }
    }
}
