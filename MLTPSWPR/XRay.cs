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
    public partial class XRay : Form
    {
        
      //  SqlDataReader dr = new SqlDataReader();
        string exam;
        DBConnection cs = new DBConnection();
        public XRay()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Form6_Load(object sender, EventArgs e)
        {
            //dataGridView1.
            FetchPatient fp = new FetchPatient();
            fp.spviewXray();
            tbPatientId.Text =FetchPatient.id;
            tbName.Text = FetchPatient.name;
            tbGender.Text = FetchPatient.gender;
            tbAge.Text = Convert.ToString(FetchPatient.age);
            tbStatus.Text = FetchPatient.status;
            dtpDateOfBirth.Value = FetchPatient.dob;
            tbAgency.Text = FetchPatient.agency;

            fp.spFetchXray();
            dtpDateOfExam.Value = FetchPatient.doe;
            
            rtbRR.Text = FetchPatient.radio;
            rtbImpression.Text = FetchPatient.impress;

            FetchPatient.exam = "";
            FetchPatient.radio = "";
            FetchPatient.impress = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (button2.Text == "Save")
                {
                    InsertTest ii = new InsertTest();
                    InsertTest.patientID = Convert.ToInt32(tbPatientId.Text.ToString());
                    InsertTest.XrDOE = dtpDateOfExam.Value;
                    InsertTest.Xrr = rtbRR.Text.ToString();
                    InsertTest.Ximpression = rtbImpression.Text.ToString();
                    ii.InsertXray();
                    InsertTest.Xexamination = "";
                }
                else if (button2.Text == "Update")
                {
                    InsertTest ii = new InsertTest();
                    InsertTest.patientID = Convert.ToInt32(tbPatientId.Text.ToString());
                    InsertTest.XrDOE = dtpDateOfExam.Value;
                    InsertTest.Xrr = rtbRR.Text.ToString();
                    InsertTest.Ximpression = rtbImpression.Text.ToString();
                    ii.UpdateXray();
                    InsertTest.Xexamination = "";
                }
            }
            catch 
            {
                MessageBox.Show("");
            }
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string tempexam;

                tempexam = checkedListBox1.SelectedItem.ToString();
                InsertTest.Xexamination = InsertTest.Xexamination +","+ tempexam;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
