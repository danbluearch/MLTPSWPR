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
    public partial class Queing : Form
    {
        DBConnection cs = new DBConnection();
        public Queing()
        {
            InitializeComponent();
        }
        private void Queing_Load(object sender, EventArgs e) 
        {
        }
        //{
        //    cs.Connection();
        //    SqlCommand cmd = new SqlCommand("select * from Queue_tbl", DBConnection.conn);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        label2.Text = dr["QueueNo"].ToString();
        //    }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Queing q = new Queing();
            //q.Load();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
