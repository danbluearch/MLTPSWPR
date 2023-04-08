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
    public partial class Reserve : Form
    {
        public Reserve()
        {
            InitializeComponent();
        }

        public static string temp = " ";

        private void Reserve_Load(object sender, EventArgs e)
        {
            FetchPatient fp = new FetchPatient();
            dataGridView1.DataSource = fp.spviewReserve();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ClearSelection();

            dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reception form = new Reception();
            form.Show();
            this.Hide();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    temp = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                else
                {
                    temp = " ";
                }
            }
            catch
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddReserve adr = new AddReserve();
            adr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (temp == " ")
            {
                MessageBox.Show("Select a row.");
            }
            else
            {
                AddReserve adr = new AddReserve();
                adr.Text = "UpdateReserve";
                adr.textBox4.Text = dataGridView1.CurrentRow.Cells["Lname"].Value.ToString();
                adr.textBox5.Text = dataGridView1.CurrentRow.Cells["Fname"].Value.ToString();
                adr.textBox6.Text = dataGridView1.CurrentRow.Cells["Mname"].Value.ToString();
                adr.textBox7.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();

                if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
                {
                    adr.radioButton1.Checked = true;
                }
                else if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
                {
                    adr.radioButton2.Checked = true;
                }

                adr.comboBox2.Text = dataGridView1.CurrentRow.Cells["MinTime"].Value.ToString();
                adr.textBox1.Text = dataGridView1.CurrentRow.Cells["MaxTime"].Value.ToString();
                adr.button1.Text = "Update";
                adr.Show();
                adr.dateTimePicker1.Checked = true;
                adr.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DateOfBirth"].Value);
                adr.dateTimePicker2.Checked = true;
                adr.dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DateOfApp"].Value);
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (temp == " ")
            {
                MessageBox.Show("Select a row.");
            }
            else
            {
                InsertTest it = new InsertTest();
                InsertTest.rID = Convert.ToInt32(temp);
                it.DeleteReserve();

                dataGridView1.DataSource = null;
                FetchPatient fp = new FetchPatient();
                dataGridView1.DataSource = fp.spviewReserve();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ClearSelection();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (temp == " ")
            {
                MessageBox.Show("Select a row.");
            }
            else
            {
                WalkIn wi = new WalkIn();
                wi.button1.Text = "Cancel";
                wi.button2.Text = "Continue";
                wi.textBox4.Text = dataGridView1.CurrentRow.Cells["Lname"].Value.ToString();
                wi.textBox5.Text = dataGridView1.CurrentRow.Cells["Fname"].Value.ToString();
                wi.textBox6.Text = dataGridView1.CurrentRow.Cells["Mname"].Value.ToString();
                wi.textBox7.Text = dataGridView1.CurrentRow.Cells["Age"].Value.ToString();
                wi.dtpBday.Checked = true;
                wi.dtpBday.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["DateOfBirth"].Value);
                if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Male")
                {
                    wi.radioButton1.Checked = true;
                }
                else if (dataGridView1.CurrentRow.Cells["Gender"].Value.ToString() == "Female")
                {
                    wi.radioButton2.Checked = true;
                }
                wi.Show();
                this.Hide();

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked == true)
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Long;

                FetchPatient fp = new FetchPatient();
                FetchPatient.doa = dateTimePicker1.Value;
                dataGridView1.DataSource = fp.spviewReserveByDate();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ClearSelection();
            }
            else
            {
                dateTimePicker1.CustomFormat = " ";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
        }
    }
}
