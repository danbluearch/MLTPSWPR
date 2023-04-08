using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Data.Sql;
namespace MLTPSWPR
{
    public partial class Main : Form
    {

        Queing q = new Queing();
        public static string PID, Name, Age, Gender, Address,package;
        public static DateTime dob;
        public static int ID;
        DBConnection cs = new DBConnection();
        SqlCommand sc = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        public static string department;
        FetchPatient fp = new FetchPatient();
        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (department == "Nursing Station")
            {
                tsbView.Visible = true;
            }
            FetchPatient fp = new FetchPatient();
            FetchPatient.department = department;
            dataGridView1.DataSource = fp.spviewAll();
            dataGridView1.ClearSelection();
        }
       private void tsbNew_Click(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(tbPatientId.Text);
                if (department == "X-Ray")
                {
                    XRay x = new XRay();
                    x.button2.Text = "Save";
                    x.Show();
                    this.Hide();
                }
                else if (department == "Laboratory")
                {
                    Laboratory l = new Laboratory();
                    l.Show();
                    this.Close();
                }
                else if (department == "Nursing Station")
                {
                    NursingStation form = new NursingStation();
                    form.btnSave.Text = "Save";
                    form.Show();
                    this.Hide();
                }
                else if (department == "Optha")
                {
                    Optha form = new Optha();
                    form.button2.Text = "Save";
                    form.Show();
                    this.Hide();
                }
            }
            catch 
            {
                MessageBox.Show("Please select a patient");
            }
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
            loginacc la = new loginacc();
            la.spLogout();
            Login L = new Login();
            L.Show();
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbPatientId.Text = "";
                tbName.Text = "";
                tbGender.Text = "";
                tbAddress.Text = "";
                tbAge.Text = "";
                string lname, fname, mname, type = "Patient";
                int pID;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    pID = Convert.ToInt32(row.Cells["PatientID"].Value.ToString());
                    tbPatientId.Text = Convert.ToString(pID);
                    lname = row.Cells["Lname"].Value.ToString();
                    fname = row.Cells["Fname"].Value.ToString();
                    mname = row.Cells["Mname"].Value.ToString();
                    tbName.Text = lname + ", " + fname + " " + mname;
                    tbAge.Text = row.Cells["Age"].Value.ToString();
                    tbGender.Text = row.Cells["Gender"].Value.ToString();
                    tbAddress.Text = row.Cells["Address"].Value.ToString();
                    dtbBday.Value = Convert.ToDateTime(row.Cells["DateOfBirth"].Value);
                    cs.Connection();
                    sc = new SqlCommand("execute spPicture @ID, @type", DBConnection.conn);
                    sc.Parameters.Add("@ID", pID);
                    sc.Parameters.Add("@type", type);
                    SqlDataReader dr = sc.ExecuteReader();
                    MemoryStream ms = new MemoryStream();
                    while (dr.Read())
                    {
                        ms = new MemoryStream((byte[])dr["Picture"]);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    cs.CloseConnection();
                }
            }
            catch
            {

            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(tbPatientId.Text);
                if (department == "X-Ray")
                {
                    XRay xr = new XRay();
                    xr.button2.Text = "Update";
                    xr.Show();
                    this.Hide();
                }
                else if (department == "Optha")
                {
                    Optha form = new Optha();
                    form.button2.Text = "Update";
                    form.Show();
                    this.Hide();
                }
                else if (department == "Nursing Station")
                {
                    NursingStation form = new NursingStation();
                    form.btnSave.Text = "Update";
                    form.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Please select a patient");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            try
            {
                ID = Convert.ToInt32(tbPatientId.Text);
                Pending p = new Pending();
                p.Show();
                this.Close();
            }
            catch {
                MessageBox.Show("Please select a patient");
            }
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int b = fp.maxcount();
            if (FetchPatient.Qnum <= b)
            {
             //   MessageBox.Show(b.ToString());
                txtQnum.Text = FetchPatient.tempQnum.ToString();
                try
                {
                    if (FetchPatient.tempQnum != 0)
                    {
                        fp.fetchtemp1();
                    }
                    for (int x = 0; x <= 2; x++)
                    {
                        if (FetchPatient.Stat == "donthave")
                        {                   
                            FetchPatient.Qnum = Convert.ToInt32(txtQnum.Text.ToString());
                            //FetchPatient fp = new FetchPatient();
                            txtQnum.Text = fp.spQueuing();
                            fp.fetchQP();
                            tbPatientId.Text = PID;
                            tbName.Text = Name;
                            tbAge.Text = Age;
                            tbGender.Text = Gender;
                            tbAddress.Text = Address;
                            dtbBday.Value = dob;
                            //--------------------------------------------------
                            cs.Connection();
                            string type = "Patient";
                            sc = new SqlCommand("execute spPicture @ID, @type", DBConnection.conn);
                            sc.Parameters.Add("@ID", PID);
                            sc.Parameters.Add("@type", type);
                            SqlDataReader dr = sc.ExecuteReader();
                            MemoryStream ms = new MemoryStream();
                            while (dr.Read())
                            {
                                ms = new MemoryStream((byte[])dr["Picture"]);
                                pictureBox1.Image = Image.FromStream(ms);
                            }
                            cs.CloseConnection();
                            //---------------------------------------------------
                            FetchPatient.patient = tbPatientId.Text.ToString();
                            FetchPatient.package = package;
                            fp.fetchtemp();

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
                catch
                {
                    FetchPatient.Stat = "donthave";
                    MessageBox.Show("There's no more Patient. Please Wait");
                }
            }
            else
            {
                MessageBox.Show("There's no more Patient. Please Wait");
                fp.fetchtemp1();
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            ChangePass cp = new ChangePass();
            FetchPatient fp = new FetchPatient();
            cp.Show();
            ChangePass.username = toolStripTextBox1.Text;
            FetchPatient.username = toolStripTextBox1.Text;
            fp.spfetchPassword();
            ChangePass.password = FetchPatient.pword;
            this.Hide();
        }
    }
}
