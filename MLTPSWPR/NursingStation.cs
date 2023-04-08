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
    public partial class NursingStation : Form
    {
        DBConnection cs = new DBConnection();
        
        public NursingStation()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            tbECG.Text = "";
            tbBlood.Text = "";
            tbHeight.Text = "";
            tbWeight.Text = "";
            tbAudio.Text = "";
            FetchPatient fp = new FetchPatient();
            fp.spviewNurse();
            tbPatientid.Text = FetchPatient.id;
            tbName.Text = FetchPatient.name;
            tbGender.Text = FetchPatient.gender;
            tbAge.Text = Convert.ToString(FetchPatient.age);
            dtpDoB.Value = FetchPatient.dob;
            tbAgency.Text = FetchPatient.agency;
            if (btnSave.Text == "Update")
            {
                fp.spFetchUpdateNurse();
                tbBlood.Text = FetchPatient.nblood;
                tbHeight.Text = FetchPatient.nheight;
                tbWeight.Text = FetchPatient.nweight;
                tbAudio.Text = FetchPatient.naudio;
                tbECG.Text = FetchPatient.necg;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            InsertTest ii = new InsertTest();
            InsertTest.patientID = Convert.ToInt32(tbPatientid.Text.ToString());
            InsertTest.NBloodPressure = tbBlood.Text.ToString();
            InsertTest.NHeight = tbHeight.Text.ToString();
            InsertTest.NWeight = tbWeight.Text.ToString();
            InsertTest.NAudio = tbAudio.Text.ToString();
            InsertTest.NECG = tbHeight.Text.ToString();
            if (btnSave.Text == "Save")
            {
                ii.InsertNurse();
                m.Show();
                this.Close();
            }
            else if (btnSave.Text == "Update")
            {
                ii.spUpdateNurse();
                m.Show();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }
    }
}
