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
    public partial class Admin : Form
    {
        DBConnection cs = new DBConnection();
        SqlCommand sc = new SqlCommand();
        public Admin()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Register f13 = new Register();
            f13.Show();
            this.Hide();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            adminFunc af = new adminFunc();
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = af.fetchStaff();
            dataGridView1.ClearSelection();
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                string fname, mname, lname, type = "Staff";
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    adminFunc.staffID = Convert.ToInt32(row.Cells["StaffID"].Value.ToString());
                    lname = row.Cells["Lname"].Value.ToString();
                    fname = row.Cells["Fname"].Value.ToString();
                    mname = row.Cells["Mname"].Value.ToString();
                    textBox2.Text = lname + ", " + fname + " " + mname;
                    textBox3.Text = row.Cells["Age"].Value.ToString();
                    textBox4.Text = row.Cells["Gender"].Value.ToString();
                    textBox5.Text = row.Cells["Department"].Value.ToString();
                    textBox6.Text = row.Cells["Status"].Value.ToString();
                    dtpBday.Value = Convert.ToDateTime(row.Cells["DateofBirth"].Value);
                    cs.Connection();
                    sc = new SqlCommand("execute spPicture @ID, @type", DBConnection.conn);
                    sc.Parameters.Add("@ID", adminFunc.staffID);
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
                MessageBox.Show("No picture");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Register.action = "SignUp";
            Register f13 = new Register();
            f13.Show();
            this.Hide();
        }

        private void tsbLogout_Click(object sender, EventArgs e)
        {
             const string message =
                    "Are you sure want to Logout?";

                const string caption = "Logging Out";
                var result = MessageBox.Show(message, caption,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    loginacc la = new loginacc();
                    la.spLogout();
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            if (adminFunc.staffID == 0)
            {
                MessageBox.Show("Please select a staff");
            }
            else
            {
                Register.action = "Update";
                Register r = new Register();
                adminFunc af = new adminFunc();
                af.fetchUpdatestaff();
                r.Show();
                this.Hide();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AddLaboratory al = new AddLaboratory();
            al.Show();
            this.Hide();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Columns c = new Columns();
            c.Show();
            this.Hide();
        }
    }
}
