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
    public partial class Form2 : Form
    {
        DBConnection cs = new DBConnection();
        
        public Form2()
        {
            InitializeComponent();
        }

        

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox8.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void phnumTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = true;
            groupBox2.Enabled = true;
            textBox21.Enabled = true;
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = false;
            groupBox2.Enabled = false;
            textBox21.Enabled = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox8.Enabled = false;
            dateTimePicker2.Enabled = false;
            groupBox2.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox24.Enabled = false;
            textBox25.Enabled = false;
            textBox26.Enabled = false;
            textBox27.Enabled = false;
            textBox28.Enabled = false;
            textBox29.Enabled = false;
            textBox30.Enabled = false;
            textBox32.Enabled = false;
            textBox33.Enabled = false;
            dateTimePicker3.Enabled = false;
            textBox35.Enabled = false;
            textBox36.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                textBox22.Enabled = true;
            }
            else
            {
                textBox22.Enabled = false;
            }
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            textBox23.Enabled = false;
        }

        private void radioButton23_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox23.Enabled = true;
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            textBox24.Enabled = false;
        }

        private void radioButton25_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox24.Enabled = true;
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            textBox25.Enabled = false;
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            textBox25.Enabled = true;
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            textBox26.Enabled = false;
        }

        private void radioButton29_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox26.Enabled = true;
        }

        private void radioButton32_CheckedChanged_1(object sender, EventArgs e)
        {
            textBox27.Enabled = false;
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            textBox27.Enabled = true;
        }

        private void radioButton34_CheckedChanged(object sender, EventArgs e)
        {
            textBox28.Enabled = false;
        }

        private void radioButton33_CheckedChanged(object sender, EventArgs e)
        {
            textBox28.Enabled = true;
        }

        private void radioButton36_CheckedChanged(object sender, EventArgs e)
        {
            textBox29.Enabled = false;
        }

        private void radioButton35_CheckedChanged(object sender, EventArgs e)
        {
            textBox29.Enabled = true;
        }

        private void radioButton38_CheckedChanged(object sender, EventArgs e)
        {
            textBox30.Enabled = false;
        }

        private void radioButton37_CheckedChanged(object sender, EventArgs e)
        {
            textBox30.Enabled = true;
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            if (textBox31.Text == "" || Convert.ToInt32(textBox31.Text) == 0)
            {
                textBox32.Enabled = false;
            }
            else
            {
                textBox32.Enabled = true;
            }
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            if (textBox34.Text == "" || Convert.ToInt32(textBox34.Text) == 0)
            {
                textBox33.Enabled = false;
            }
            else
            {
                textBox33.Enabled = true;
            }
        }

        private void radioButton39_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Enabled = false;
            textBox35.Enabled = false;
            textBox36.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void radioButton40_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Enabled = true;
            textBox35.Enabled = true;
            textBox36.Enabled = true;
            groupBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WalkIn f3 = new WalkIn();
            
            f3.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            
            f1.Show();
            this.Hide();
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || Convert.ToInt32(textBox8.Text) == 0)
            {
                textBox9.Enabled = true;
            }
            else
            {
                textBox9.Enabled = false;
            }
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }
    }
}
