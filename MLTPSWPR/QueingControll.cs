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
    public partial class QueingControll : Form
    {
        public static string login;
        public QueingControll()
        {
            if (login == "Close")
            {
                this.Close();
            }
            InitializeComponent();
            
        }

        private void QueingControll_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            for(int x =0;x<=2;x++)
            {
                if (FetchPatient.Stat == "donthave")
                {
                    FetchPatient.Qnum = Convert.ToInt32(textBox1.Text.ToString());
                    FetchPatient fp = new FetchPatient();
                    textBox1.Text = fp.spQueuing();
                    x = 0;
                }
                else
                {
                    FetchPatient.Stat = "donthave";
                    break;
                }
                if (FetchPatient.stat1 == "empty")
                {
                    MessageBox.Show("There's no more Patient. Please Wait");
                    FetchPatient.stat1 = "Not";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
