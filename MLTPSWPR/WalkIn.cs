using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace MLTPSWPR
{
    public partial class WalkIn : Form
    {
        public WalkIn()
        {
            InitializeComponent();
        }

        

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Back")
            {
                Reception f1 = new Reception();
                f1.Show();
                this.Hide();
            }
            else if (button1.Text == "Cancel")
            {
                Reserve rsv = new Reserve();
                rsv.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 14;
            try
            {
                if (textBox1.Text == "")
                {
                    counter--;
                }
                if (textBox2.Text == "")
                {
                    counter--;
                }
                if (textBox3.Text == "")
                {
                    counter--;
                }
                if (textBox4.Text == "")
                {
                    counter--;
                }
                if (textBox5.Text == "")
                {
                    counter--;
                }
                if (textBox6.Text == "")
                {
                    counter--;
                }
                if (textBox7.Text == "")
                {
                    counter--;
                }
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    counter--;
                }
                if (comboBox1.Text == "")
                {
                    counter--;
                }
                if (textBox10.Text == "")
                {
                    counter--;
                }
                if (textBox11.Text == "")
                {
                    counter--;
                }
                if (dtpBday.Checked == false)
                {
                    counter--;
                }
                if (comboBox2.Text == "")
                {
                    counter--;
                }
                if (pictureBox1.Image == null)
                {
                    counter--;
                }

                if (counter != 14)
                {
                    MessageBox.Show("Please fill up all information");
                }
                else
                {
                    if (button2.Text == "Save")
                    {
                        int age;
                        InsertTest it = new InsertTest();
                        InsertTest.pFname = textBox5.Text.ToString();
                        InsertTest.pMname = textBox6.Text.ToString();
                        InsertTest.pLname = textBox4.Text.ToString();
                        InsertTest.pAge = age = int.Parse(textBox7.Text);

                        if (radioButton1.Checked == true)
                        {
                            InsertTest.pGender = radioButton1.Text.ToString();
                        }
                        else if (radioButton2.Checked == true)
                        {
                            InsertTest.pGender = radioButton2.Text.ToString();
                        }

                        InsertTest.pCivilStatus = comboBox1.Text.ToString();
                        InsertTest.pNOE = textBox1.Text.ToString();
                        InsertTest.pNOA = textBox2.Text.ToString();
                        InsertTest.pDestination = textBox3.Text.ToString();
                        InsertTest.pPosition = textBox10.Text.ToString();
                        InsertTest.pAddress = textBox11.Text.ToString();
                        InsertTest.pDateOfBirth = dtpBday.Value;
                        InsertTest.pexam = comboBox2.Text.ToString();
                        
                        MemoryStream ams = new MemoryStream();
                        pictureBox1.Image.Save(ams, System.Drawing.Imaging.ImageFormat.Jpeg);
                        InsertTest.ms = ams;

                        it.InsertPatient();

                        Reception form = new Reception();
                        form.Show();
                        this.Hide();
                    }
                    else if (button2.Text == "Continue")
                    {
                        int age;
                        InsertTest it = new InsertTest();
                        InsertTest.pFname = textBox5.Text.ToString();
                        InsertTest.pMname = textBox6.Text.ToString();
                        InsertTest.pLname = textBox4.Text.ToString();
                        InsertTest.pAge = age = int.Parse(textBox7.Text);

                        if (radioButton1.Checked == true)
                        {
                            InsertTest.pGender = radioButton1.Text.ToString();
                        }
                        else if (radioButton2.Checked == true)
                        {
                            InsertTest.pGender = radioButton2.Text.ToString();
                        }

                        InsertTest.pCivilStatus = comboBox1.Text.ToString();
                        InsertTest.pNOE = textBox1.Text.ToString();
                        InsertTest.pNOA = textBox2.Text.ToString();
                        InsertTest.pDestination = textBox3.Text.ToString();
                        InsertTest.pPosition = textBox10.Text.ToString();
                        InsertTest.pAddress = textBox11.Text.ToString();
                        InsertTest.pDateOfBirth = dtpBday.Value;
                        InsertTest.pexam = comboBox2.Text.ToString();

                        MemoryStream ams = new MemoryStream();
                        pictureBox1.Image.Save(ams, System.Drawing.Imaging.ImageFormat.Jpeg);
                        InsertTest.ms = ams;

                        it.InsertPatient();

                        InsertTest.rID = Convert.ToInt32(Reserve.temp);
                        it.DeleteReserve();

                        Reception form = new Reception();
                        form.Show();
                        this.Hide();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid data type.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                pictureBox1.Image = img.GetThumbnailImage(100, 100, null, new IntPtr());
            }
            else
            {
                MessageBox.Show("Invalid type of image");
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "PREMED")
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;

                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
            else if(comboBox2.Text == "COMPLETE"){
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;
                
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
            }
            else if (comboBox2.Text == "PHASE 1")
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;

                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
            else if (comboBox2.Text == "PHASE 2")
            {
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;

                checkBox2.Checked = true;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
            else if(comboBox2.Text == "OTHERS")
            {
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;

                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void WalkIn_Load(object sender, EventArgs e)
        {

        }
    }
}
