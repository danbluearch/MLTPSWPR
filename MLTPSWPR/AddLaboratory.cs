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
    public partial class AddLaboratory : Form
    {
        public AddLaboratory()
        {
            InitializeComponent();
        }

        InsertTest it = new InsertTest();

        private void button1_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                    InsertTest.department = textBox1.Text.ToString();
                    InsertTest.price = Convert.ToInt32(textBox2.Text.ToString());
                    it.spaddLab();
                    Admin a = new Admin();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please fill up all fields");
                }
            }
            catch
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void AddLaboratory_Load(object sender, EventArgs e)
        {

        }
    }
}
