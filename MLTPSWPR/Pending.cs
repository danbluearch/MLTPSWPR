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
    public partial class Pending : Form
    {
        public static string name, agency, package, position, gender, destination;
        public static int age;
        public Pending()
        {
            InitializeComponent();
        }
        private void Pending_Load(object sender, EventArgs e)
        {
            FetchPatient fp = new FetchPatient();
            fp.spfetchPending();
            tbName.Text = name;
            tbAgency.Text = agency;
            tbAge.Text = Convert.ToString(age);
            tbApplied.Text = position;
            tbDestination.Text = destination;
            tbGender.Text = gender;
            tbPackage.Text = package;
            dataGridView1.DataSource = fp.fetchPending();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Close();
        }
    }
}
