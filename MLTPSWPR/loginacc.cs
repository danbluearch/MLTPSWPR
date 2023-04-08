using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace MLTPSWPR
{
    
    class loginacc
    {
        
        public static string username = "", password = "",department;
        public static string ID;
        DBConnection cs = new DBConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand sc = new SqlCommand();
        DataTable dt = new DataTable();
        public string verify()
        {
           try
            {
              cs.Connection();
              sc = new SqlCommand("execute spaccvalid '"+username+"','"+password+"'",DBConnection.conn);
              SqlDataReader dr = sc.ExecuteReader();
              string account = "";
              while (dr.Read())
              {
                  account = dr["department"].ToString();
                  ID = dr["StaffID"].ToString();
              }
              Main.department = account;
              department = account;
              return account;
            }
          catch (Exception ex)
            {
                return ex.ToString();
            }
          finally
            {
                cs.CloseConnection();
            }
        }
        public void spLogin()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute splogin @ID",DBConnection.conn);
                sc.Parameters.Add("@ID", ID);
                sc.ExecuteNonQuery();
            }
            finally 
            {
                cs.CloseConnection();
            }
        }
        public void spLogout()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute splogout @ID", DBConnection.conn);
                sc.Parameters.Add("@ID", ID);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }
    }
}
