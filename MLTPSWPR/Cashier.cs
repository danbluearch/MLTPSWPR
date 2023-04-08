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
using System.IO;

namespace MLTPSWPR
{
    public partial class Cashier : Form
    {
        string package;
        DBConnection cs = new DBConnection();
        public static double a;
        public Cashier()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            FetchPatient fp = new FetchPatient();
            dataGridView1.DataSource = fp.spviewCashier();
            dataGridView1.ClearSelection();

            fp.spCountQ();
            txtQnum.Text = FetchPatient.countq.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                InsertTest ii = new InsertTest();
                InsertTest.patientID = Convert.ToInt32(textBox3.Text);
                InsertTest.cpack = package;
                InsertTest.date = dtpDate.Value;
                ii.InsertCashier();
                ii.inseertcashierpending();
                InsertTest.Qnum = Convert.ToInt32(txtQnum.Text);
                ii.spInsertQ();
            }
            catch
            {
                MessageBox.Show("Please select a Patient");
            }
            finally 
            {
                FetchPatient fp = new FetchPatient();
                fp.spCountQ();
                txtQnum.Text = FetchPatient.countq.ToString();
                dataGridView1.DataSource = fp.spviewCashier();
                dataGridView1.ClearSelection();
                textBox3.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       /* private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }*/

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";
                string fname, mname, lname;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox3.Text = row.Cells["PatientID"].Value.ToString();
                    lname = row.Cells["Lname"].Value.ToString();
                    fname = row.Cells["Fname"].Value.ToString();
                    mname = row.Cells["Mname"].Value.ToString();
                    textBox2.Text = lname + ", " + fname + " " + mname;
                    package = row.Cells["PackageName"].Value.ToString();
                    int ID = Convert.ToInt32(textBox3.Text.ToString());
                    cs.Connection();
                    SqlCommand cmd = new SqlCommand("execute spCashier @patientID", DBConnection.conn);
                    cmd.Parameters.Add("@patientID", ID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    MemoryStream ms = new MemoryStream();
                    string prod = "";
                    double price;
                    while (dr.Read())
                    {
                        ms = new MemoryStream((byte[])dr["Picture"]);
                        pictureBox1.Image = Image.FromStream(ms);
                        prod = dr["ProcedureName"].ToString();
                        price =Convert.ToDouble(dr["Price"].ToString());
                        if (prod == "Laboratory")
                        {
                            textBox4.Text = price.ToString("0.00");
                        }
                        else if (prod == "X-Ray")
                        {
                            textBox5.Text = price.ToString("0.00");
                        }
                        else if (prod == "Neuro")
                        {
                            textBox6.Text = price.ToString("0.00");
                        }
                        else if (prod == "Dental")
                        {
                            textBox7.Text = price.ToString("0.00");
                        }
                        else if (prod == "Optha")
                        {
                            textBox9.Text = price.ToString("0.00");
                        }
                        else if (prod == "Physical Examination")
                        {
                            textBox8.Text = price.ToString("0.00");
                        }
                    }
                    cs.CloseConnection();
                    cs.Connection();
                    Double temp;
                    cmd = new SqlCommand("execute spTotal @patientID", DBConnection.conn);
                    cmd.Parameters.Add("@patientID", ID);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        temp = Convert.ToDouble(dr["Total"].ToString());
                        tbBill.Text = temp.ToString("0.00");
                    }
                    cs.CloseConnection();
                }
                if (package == "COMPLETE") 
                {
                    InsertTest.Laboratory = "Pending";
                    InsertTest.XRay = "Pending";
                    InsertTest.PE = "Pending";
                    InsertTest.coptha = "Pending";
                    InsertTest.Neuro = "Pending";
                    InsertTest.Dental = "Pending";
                }
                //else if (cpack == "PREMED")
                //{
                //    sc.Parameters.Add("@Lab", "Pending");
                //}
                //else if (cpack == "PHASE 1")
                //{
                //    sc.Parameters.Add("@Lab", "Pending");
                //    sc.Parameters.Add("@Xray", "Pending");
                //}
                //else if (cpack == "PHASE 2")
                //{
                //    sc.Parameters.Add("@Lab", "Pending");
                //} 
            }
            catch
            {
                MessageBox.Show("No picture.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            Double temp,temp1;
            string change;
            FetchPatient.bill = tbBill.Text;
            FetchPatient.amount = tbAmount.Text;
            FetchPatient fp = new FetchPatient();
            temp = Convert.ToDouble (fp.spChange());
            tbChange.Text =temp.ToString("0.##");
           if (temp < 0)
            {
                tbChange.Text = "0";
            }   
        }
        private void tbAmount_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            const string message =
                      "Are you sure want to Logout?";

            const string caption = "Logging Out";
            var result = MessageBox.Show(message, caption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
        }
    }
}
