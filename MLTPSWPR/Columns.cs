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
    public partial class Columns : Form
    {
        public Columns()
        {
            InitializeComponent();
        }

        private void Columns_Load(object sender, EventArgs e)
        {
            FetchPatient fp = new FetchPatient();
            comboBox1.DataSource = fp.spfetchDepartment().DefaultView;
            comboBox1.DisplayMember = "departmentName";
            comboBox1.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchPatient fp = new FetchPatient();
            FetchPatient.tableName = comboBox1.Text;
            dataGridView1.DataSource = fp.spfetchColumns();
        }
    }
}
