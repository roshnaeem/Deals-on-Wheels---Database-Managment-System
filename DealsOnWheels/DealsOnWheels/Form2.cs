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
    public partial class Form2 : Form
    {
        DBConnect connect = new DBConnect();
        public Form2()
        {
            InitializeComponent();
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
           // label15.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            Menu men = new Menu();
            men.Show();
            this.Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = "Select * from DEALSONWHEELS.employee where ssn=" + textBox1.Text;
                string[] att = { "ssn", "salary", "working_hours", "BranchNo" };
                List<string>[] result = connect.Select(query, att);
                try
                {
                    //label2.Text = result[0][0];
                    label4.Text = result[0][0];
                    label5.Text = result[1][0];
                    label6.Text = result[2][0];
                    label7.Text = result[3][0];
                    //label2.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    //label15.Visible = true;
                    string query1 = "Select * from DEALSONWHEELS.person where ssn=" + textBox1.Text;
                    string[] att1 = { "Fname" };
                    List<string>[] result1 = connect.Select(query1, att1);
                    try
                    {
                        label2.Text = result1[0][0];

                        label2.Visible = true;


                    }
                    catch (Exception ex)
                    {
                        //SORRY THIS CAR IS NOT AVAILABLE
                        MessageBox.Show(null, "SORRY WRONG SSN", "Wrong SSN");
                        textBox1.Text = "";
                        // label15.Visible = false;
                        label2.Visible = false;
                        label4.Visible = false;
                        label5.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        //label15.Visible = false;

                    }

                }



                catch (Exception ex)
                {
                    //SORRY THIS CAR IS NOT AVAILABLE
                    MessageBox.Show(null, "SORRY WRONG SSN", "Wrong SSN");
                    textBox1.Text = "";
                    label2.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    label7.Visible = false;
                    //label15.Visible = false;
                }
            }
            else
            {
                MessageBox.Show(null, "SORRY WRONG SSN", "Wrong SSN");
            }
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
