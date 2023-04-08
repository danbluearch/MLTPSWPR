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
    public partial class ChangePass : Form
    {
        public ChangePass()
        {
            InitializeComponent();
        }

        public static string username = "", password = "";

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            m.toolStripTextBox1.Text = username;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Fill up all fields");
                }
                else if (textBox1.Text != password)
                {
                    MessageBox.Show("Invalid password");
                }
                else if (textBox2.Text == password)
                {
                    MessageBox.Show("Choose another password");
                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Password does not match");
                }
                else if (textBox1.Text == password && textBox2.Text == textBox3.Text)
                {
                    FetchPatient fp = new FetchPatient();
                    FetchPatient.username = username;
                    FetchPatient.pword = textBox2.Text;
                    fp.spupdatePassword();
                    MessageBox.Show("Successfully changed");
                    Main m = new Main();
                    m.toolStripTextBox1.Text = username;
                    m.Show();
                    this.Hide();
                }
            }
            catch
            {

            }
        }
    }
}
