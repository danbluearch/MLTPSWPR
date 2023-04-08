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
using System.Data;
namespace MLTPSWPR
{
    public partial class Reception : Form
    {
        DBConnection cs = new DBConnection();
        public Reception()
        {
            InitializeComponent();
        }

        public static string temp = " ";

        private void button1_Click(object sender, EventArgs e)
        {
            WalkIn form = new WalkIn();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reserve form = new Reserve();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();

            f1.Show();
            this.Hide();
        }

        private void Reception_Load(object sender, EventArgs e)
        {
        //    DataTable dt = new DataTable();
        //    cs.Connection();
        //    SqlDataAdapter sda = new SqlDataAdapter("Select * from Patient_tbl",DBConnection.conn);
        //    sda.Fill(dt);
        //    dataGridView1.DataSource = dt;
        //    dataGridView1.ClearSelection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const string message =
                    "Are you sure want to Reset the Queueing?";

            const string caption = "Resetting the Queueing Number";
            var result = MessageBox.Show(message, caption,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InsertTest it = new InsertTest();
                it.resetQ();
                MessageBox.Show("Sucessfully Reset");
            }
        }

        //private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (dataGridView1.SelectedRows.Count > 0)
        //        {
        //            temp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        //        }
        //        else
        //        {
        //            temp = " ";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    if (temp == " ")
        //    {
        //        MessageBox.Show("Select a row.");
        //    }
        //    else
        //    {
        //        WalkIn w = new WalkIn();
        //        w.textBox1.Text = dataGridView1.CurrentRow.Cells["NOE"].Value.ToString();
        //        w.textBox2.Text = dataGridView1.CurrentRow.Cells["NOA"].Value.ToString();
        //        w.textBox3.Text = dataGridView1.CurrentRow.Cells["Destination"].Value.ToString();
        //        w.textBox4.Text = dataGridView1.CurrentRow.Cells["Lname"].Value.ToString();
        //        w.textBox5.Text = dataGridView1.CurrentRow.Cells["Fname"].Value.ToString();
        //        w.textBox6.Text = dataGridView1.CurrentRow.Cells["Mname"].Value.ToString();
        //        w.textBox7.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();

        //        if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
        //        {
        //            w.radioButton1.Checked = true;
        //        }
        //        else if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
        //        {
        //            w.radioButton2.Checked = true;
        //        }

        //        w.comboBox1.Text = dataGridView1.CurrentRow.Cells["CivilStatus"].Value.ToString();
        //        w.textBox10.Text = dataGridView1.CurrentRow.Cells["Position"].Value.ToString();
        //        w.textBox11.Text = dataGridView1.CurrentRow.Cells["Address"].Value.ToString();
        //        w.comboBox2.Text = "REMED";

        //        w.checkBox2.Enabled = true;
        //        w.checkBox3.Enabled = true;
        //        w.checkBox4.Enabled = true;
        //        w.checkBox5.Enabled = true;
        //        w.checkBox6.Enabled = true;
        //        w.checkBox7.Enabled = true;

        //        w.Show();
        //        w.dtpBday.Checked = true;
        //        w.dtpBday.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DateOfBirth"].Value);
        //        this.Hide();
        //    }
        //}
    }
}
