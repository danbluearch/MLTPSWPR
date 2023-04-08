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

namespace MLTPSWPR
{
    public partial class Login : Form
    {
        DBConnection cs = new DBConnection();
        
        public Login()
        {
           
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
        //    Queing q = new Queing();
        //    q.Show();
            try
            {
                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Please enter your username and password");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Please enter your username");
                    textBox1.Clear();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please enter your password");
                    textBox2.Clear();
                }
                else
                {
                    loginacc.username = textBox1.Text;
                    loginacc.password = textBox2.Text;
                    loginacc la = new loginacc();
                    string account = la.verify();
                    la.spLogin();
                    if (account == "Admin")
                    {
                        Admin f1 = new Admin();
                        this.Hide();
                        MessageBox.Show("Sucessfully Login");
                        f1.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    //else if (account == "Laboratory")
                    //{
                    //    Laboratory l = new Laboratory();
                    //    l.Show();
                    //    this.Close();
                    //    textBox1.Clear();
                    //    textBox2.Clear();
                    //    MessageBox.Show("Sucessfully Login");
                    //}
                    else if (account == "Cashier")
                    {
                        Cashier f2 = new Cashier();
                        MessageBox.Show("Sucessfully Login");
                        f2.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                    }
                    else if (account == "Reception")
                    {
                        Reception form = new Reception();
                        MessageBox.Show("Sucessfully Login");
                        form.Show();
                        textBox1.Clear();
                        textBox2.Clear();
                        this.Hide();
                    }
                    else if (account != "")
                    {
                        MessageBox.Show("Succesfully Login");
                        Main m = new Main();
                        m.Show();
                        m.toolStripTextBox1.Text = textBox1.Text;
                        this.Hide();
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Invalid account");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid account");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
