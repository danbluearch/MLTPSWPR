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
    public partial class Optha : Form
    {
        public static string id, eyes, vision, ishi, uodF, aodF, uosF, aosF, uodN, aodN, uosN, aosN,remarks,Uishivis,Aishivis;
        DBConnection cs = new DBConnection();
        public Optha()
        {
            InitializeComponent();

            rbBothEye.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbLefteye.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbRighteye.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbBothVis.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbNearVis.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            rbFarVis.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if(rbBothEye.Checked == true && rbBothVis.Checked == true){
                txtUODF.Enabled = true;
                txtAODF.Enabled = true;
                txtUOSF.Enabled = true;
                txtAOSF.Enabled = true;
                txtUODN.Enabled = true;
                txtAODN.Enabled = true;
                txtUOSN.Enabled = true;
                txtAOSN.Enabled = true;
                eyes = "Both";
                vision = "Both";
            }
            else if (rbBothEye.Checked == true && rbNearVis.Checked == true)
            {
                txtUODF.Enabled = false;
                txtAODF.Enabled = false;
                txtUOSF.Enabled = false;
                txtAOSF.Enabled = false;
                txtUODN.Enabled = true;
                txtAODN.Enabled = true;
                txtUOSN.Enabled = true;
                txtAOSN.Enabled = true;
                eyes = "Both";
                vision = "Near";
                uodF = "0";
                uosF = "0";
                aodF = "0";
                aosF = "0";
            }
            else if (rbBothEye.Checked == true && rbFarVis.Checked == true)
            {
                txtUODF.Enabled = true;
                txtAODF.Enabled = true;
                txtUOSF.Enabled = true;
                txtAOSF.Enabled = true;
                txtUODN.Enabled = false;
                txtAODN.Enabled = false;
                txtUOSN.Enabled = false;
                txtAOSN.Enabled = false;
                eyes = "Both";
                vision = "Far";
                uodN = "0";
                uosN = "0";
                aodN = "0";
                aosN = "0";
            }
            else if (rbLefteye.Checked == true && rbBothVis.Checked == true)
            {
                txtUODF.Enabled = false;
                txtAODF.Enabled = false;
                txtUOSF.Enabled = true;
                txtAOSF.Enabled = true;
                txtUODN.Enabled = false;
                txtAODN.Enabled = false;
                txtUOSN.Enabled = true;
                txtAOSN.Enabled = true;
                eyes = "Left";
                vision = "Both";
                uodF = "0";
                uodN = "0";
                aodF = "0";
                aodN = "0";
            }
            else if (rbLefteye.Checked == true && rbNearVis.Checked == true)
            {
                txtUODF.Enabled = false;
                txtAODF.Enabled = false;
                txtUOSF.Enabled = false;
                txtAOSF.Enabled = false;
                txtUODN.Enabled = false;
                txtAODN.Enabled = false;
                txtUOSN.Enabled = true;
                txtAOSN.Enabled = true;
                eyes = "Left";
                vision = "Near";
                uodF = "0";
                uodN = "0";
                aodN = "0";
                aodF = "0";
                uosF = "0";
                aosF = "0";
            }
            else if (rbLefteye.Checked == true && rbFarVis.Checked == true)
            {
                txtUODF.Enabled = false;
                txtAODF.Enabled = false;
                txtUOSF.Enabled = true;
                txtAOSF.Enabled = true;
                txtUODN.Enabled = false;
                txtAODN.Enabled = false;
                txtUOSN.Enabled = false;
                txtAOSN.Enabled = false;
                eyes = "Left";
                vision = "Far";
                uodF = "0";
                uodN = "0";
                aodN = "0";
                aodF = "0";
                aosN = "0";
                aosN = "0";
            }
            else if (rbRighteye.Checked == true && rbBothVis.Checked == true)
            {
                txtUODF.Enabled = true;
                txtAODF.Enabled = true;
                txtUOSF.Enabled = false;
                txtAOSF.Enabled = false;
                txtUODN.Enabled = true;
                txtAODN.Enabled = true;
                txtUOSN.Enabled = false;
                txtAOSN.Enabled = false;
                eyes = "Right";
                vision = "Both";
                uosF = "0";
                uosN = "0";
                aosN = "0";
                aosF = "0";
            }
            else if (rbRighteye.Checked == true && rbNearVis.Checked == true)
            {
                txtUODF.Enabled = false;
                txtAODF.Enabled = false;
                txtUOSF.Enabled = false;
                txtAOSF.Enabled = false;
                txtUODN.Enabled = true;
                txtAODN.Enabled = true;
                txtUOSN.Enabled = false;
                txtAOSN.Enabled = false;
                eyes = "Right";
                vision = "Near";
                uosF = "0";
                uosN = "0";
                aosN = "0";
                aosF = "0";
                uodF = "0";
                aodF = "0";
            }
            else if (rbRighteye.Checked == true && rbFarVis.Checked == true)
            {
                txtUODF.Enabled = true;
                txtAODF.Enabled = true;
                txtUOSF.Enabled = false;
                txtAOSF.Enabled = false;
                txtUODN.Enabled = false;
                txtAODN.Enabled = false;
                txtUOSN.Enabled = false;
                txtAOSN.Enabled = false;
                eyes = "Right";
                vision = "Far";
                uosF = "0";
                uosN = "0";
                aosN = "0";
                aosF = "0";
                uodN = "0";
                aodN = "0";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                InsertTest IT = new InsertTest();
                id = tbPatientid.Text.ToString();
                uodF = txtUODF.Text.ToString();
                uosF = txtUOSF.Text.ToString();
                uodN = txtUODN.Text.ToString();
                uosN = txtUOSN.Text.ToString();
                aodF = txtAODF.Text.ToString();
                aosF = txtAOSF.Text.ToString();
                aodN = txtAODN.Text.ToString();
                aosN = txtAOSN.Text.ToString();
                if (button2.Text == "Save")
                {
                    IT.insertOptha();
                    Main m = new Main();
                    m.Show();
                    this.Close();
                }
                else if (button2.Text == "Update")
                {
                    IT.spUpdateOptha();
                    Main m = new Main();
                    m.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Please fill all the information");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void rbOthers_CheckedChanged(object sender, EventArgs e)
        {
            
            txtRemarks.Enabled = true;
            remarks = txtRemarks.Text.ToString();
        }

        private void Optha_Load(object sender, EventArgs e)
        {
                FetchPatient fp = new FetchPatient();
                fp.spviewOptha();
                tbPatientid.Text = FetchPatient.oid;
                tbName.Text = FetchPatient.oname;
                tbAge.Text = Convert.ToString(FetchPatient.oage);
                tbAgency.Text = FetchPatient.oagency;
                tbDestin.Text = FetchPatient.odestination;
            if (button2.Text == "Update")
            {
                fp.spfetchUpdateOptha();
                //----------------------------
                if (ishi == "With Ishihara")
                {
                    rbWishi.Checked = true;
                }
                else 
                {
                    rbWOishi.Checked = true;
                }
                //----------------------------
                if (eyes == "Both")
                {
                    rbBothEye.Checked = true;
                }
                else if (eyes == "Left")
                {
                    rbLefteye.Checked = true;
                }
                else if (eyes == "Right")
                {
                    rbRighteye.Checked = true;
                }
                //----------------------------
                if (vision == "Both")
                {
                    rbBothVis.Checked = true;
                }
                else if (vision == "Near")
                {
                    rbNearVis.Checked = true;
                }
                else if (vision == "Far")
                {
                    rbFarVis.Checked = true;
                }
                txtAODF.Text = aodF;
                txtAODN.Text = aodN;
                txtAOSF.Text = aosF;
                txtAOSN.Text = aosN;
                txtUODF.Text = uodF;
                txtUODN.Text = uodN;
                txtUOSF.Text = uosF;
                txtUOSN.Text = uosN;
                if (Uishivis == "Normal")
                    rbNormal.Checked = true;
                else if (Uishivis == "Defective")
                    rbDefective.Checked = true;
                //---------------------------------
                if (Aishivis == "NA")
                    rbNA.Checked = true;
                else if (Aishivis == "ND")
                    rbND.Checked = true;
               //----------------------------------
                if (remarks == "Fit")
                    rbFit.Checked = true;
                else if (remarks == "Unfit")
                    rbUnfit.Checked = true;
                else if (remarks == "For Compliance")
                    rbForComp.Checked = true;
                else
                    txtRemarks.Text = remarks;
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWishi.Checked == true)
            {
                groupBox6.Enabled = true;
                groupBox5.Enabled = true;
                ishi = "With Ishihara";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWOishi.Checked == true)
            {
                rbNormal.Checked = false;
                rbDefective.Checked = false;
                rbNA.Checked = false;
                rbND.Checked = false;
                groupBox5.Enabled = false;
                groupBox6.Enabled = false;
                ishi = "Without Ishihara";
                Uishivis = "None";
                Aishivis = "None";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtRemarks.Enabled = false;
            remarks = "Fit";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtRemarks.Enabled = false;
            remarks = "Unfit";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtRemarks.Enabled = false;   
            remarks = "For Compliance";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            Uishivis = "Normal";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            Uishivis = "Defective";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            Aishivis = "NA";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            Aishivis = "ND";
        }
    }
}
