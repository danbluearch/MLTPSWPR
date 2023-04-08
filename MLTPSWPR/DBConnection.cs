using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MLTPSWPR
{
    class DBConnection
    {
        
        
        public static SqlConnection conn = null;
        
        public void Connection()
        {
            conn = new SqlConnection(@"Data Source=MELISSA-WIN7\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
            conn.Open();
        }
        public void CloseConnection()
        {
            conn.Close();
        }

     /*   public void UpdateQueue()
        {
            Queing q = new Queing();
            
            Connection();
            SqlCommand cmd = new SqlCommand("select * from Queue_tbl", Class1.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            int count = 0;
            while (dr.Read())
            {
                count += 1;
                q.label2.Text = dr["QueueNo"].ToString();
            }
        }*/
    }
}