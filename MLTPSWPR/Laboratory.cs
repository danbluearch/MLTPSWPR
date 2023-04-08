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

namespace MLTPSWPR
{
    public partial class Laboratory : Form
    {
        DBConnection cs = new DBConnection();
        public Laboratory()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            FetchPatient FP = new FetchPatient();
            dataGridView1.DataSource = FP.spviewLaboratory();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UrineForm uf = new UrineForm();
            uf.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
