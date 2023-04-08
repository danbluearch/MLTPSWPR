using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLTPSWPR
{
    public partial class AddReserve : Form
    {
        int count;

        public AddReserve()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reserve form = new Reserve();
            form.Show();
            this.Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "8:30 AM")
            {
                textBox1.Text = "9:00 AM";
            }
            else if (comboBox2.Text == "9:00 AM")
            {
                textBox1.Text = "9:30 AM";
            }
            else if (comboBox2.Text == "9:30 AM")
            {
                textBox1.Text = "10:00 AM";
            }
            else if (comboBox2.Text == "10:00 AM")
            {
                textBox1.Text = "10:30 AM";
            }
            else if (comboBox2.Text == "10:30 AM")
            {
                textBox1.Text = "11:00 AM";
            }
            else if (comboBox2.Text == "11:00 AM")
            {
                textBox1.Text = "11:30 AM";
            }
            else if (comboBox2.Text == "11:30 AM")
            {
                textBox1.Text = "12:00 PM";
            }
            else if (comboBox2.Text == "12:00 PM")
            {
                textBox1.Text = "12:30 PM";
            }
            else if (comboBox2.Text == "12:30 PM")
            {
                textBox1.Text = "1:00 PM";
            }
            else if (comboBox2.Text == "1:00 PM")
            {
                textBox1.Text = "1:30 PM";
            }
            else if (comboBox2.Text == "1:30 PM")
            {
                textBox1.Text = "2:00 PM";
            }
            else if (comboBox2.Text == "2:00 PM")
            {
                textBox1.Text = "2:30 PM";
            }
            else if (comboBox2.Text == "2:30 PM")
            {
                textBox1.Text = "3:00 PM";
            }
            else if (comboBox2.Text == "3:00 PM")
            {
                textBox1.Text = "3:30 PM";
            }
            else if (comboBox2.Text == "3:30 PM")
            {
                textBox1.Text = "4:00 PM";
            }
            else if (comboBox2.Text == "4:00 PM")
            {
                textBox1.Text = "4:30 PM";
            }
            else
            {
                textBox1.Text = "5:00 PM";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            count = 9;

            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter last name.");
                count--;
            }
            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter first name.");
                count--;
            }
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter middle name.");
                count--;
            }
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter age.");
                count--;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Enter gender.");
                count--;
            }
            if (dateTimePicker1.Checked == false)
            {
                MessageBox.Show("Enter birthdate.");
                count--;
            }
            if (dateTimePicker2.Checked == false)
            {
                MessageBox.Show("Enter date of appointment.");
                count--;
            }
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Enter time.");
                count--;
            }

            FetchPatient fp = new FetchPatient();
            fp.spdeleteTime();
            DataTable dt = fp.spdeleteTime();

            foreach (DataRow row in dt.Rows)
            {
                DateTime d = Convert.ToDateTime(row["DateOfApp"].ToString());
                string date = d.Date.ToString();
                string time = row["MinTime"].ToString();
                if (dateTimePicker2.Value.Date.ToString() == date && comboBox2.Text.ToString() == time)
                {
                    MessageBox.Show("This time is occupied");
                    count--;
                }
            }

            if (count == 9)
            {
                
                if (button1.Text == "Reserve")
                {
                    int age;
                    InsertTest it = new InsertTest();
                    InsertTest.rLname = textBox4.Text.ToString();
                    InsertTest.rFname = textBox5.Text.ToString();
                    InsertTest.rMname = textBox6.Text.ToString();
                    InsertTest.rAge = age = int.Parse(textBox7.Text);

                    if (radioButton1.Checked == true)
                    {
                        InsertTest.rGender = radioButton1.Text.ToString();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        InsertTest.rGender = radioButton2.Text.ToString();
                    }

                    InsertTest.rDateOfBirth = dateTimePicker1.Value;
                    InsertTest.rDateOfApp = dateTimePicker2.Value;
                    InsertTest.rMinTime = comboBox2.SelectedItem.ToString();
                    InsertTest.rMaxTime = textBox1.Text.ToString();
                    it.InsertReserve();

                    Reserve form = new Reserve();
                    form.Show();
                    this.Hide();
                }
                else if (button1.Text == "Update")
                {
                    int age;
                    InsertTest it = new InsertTest();
                    InsertTest.rID = Convert.ToInt32(Reserve.temp);
                    InsertTest.rLname = textBox4.Text.ToString();
                    InsertTest.rFname = textBox5.Text.ToString();
                    InsertTest.rMname = textBox6.Text.ToString();
                    InsertTest.rAge = age = int.Parse(textBox7.Text);

                    if (radioButton1.Checked == true)
                    {
                        InsertTest.rGender = radioButton1.Text.ToString();
                    }
                    else if (radioButton2.Checked == true)
                    {
                        InsertTest.rGender = radioButton2.Text.ToString();
                    }

                    InsertTest.rDateOfBirth = dateTimePicker1.Value;
                    InsertTest.rDateOfApp = dateTimePicker2.Value;
                    InsertTest.rMinTime = comboBox2.SelectedItem.ToString();
                    InsertTest.rMaxTime = textBox1.Text.ToString();
                    it.UpdateReserve();

                    Reserve form = new Reserve();
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void AddReserve_Load(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            dateTimePicker2.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked == true)
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Long;
            }
            else
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker2.Checked == true)
            {
                dateTimePicker2.CustomFormat = " ";
                dateTimePicker2.Format = DateTimePickerFormat.Long;
            }
            else
            {
                dateTimePicker2.CustomFormat = " ";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
            }

            
        }
    }
}
