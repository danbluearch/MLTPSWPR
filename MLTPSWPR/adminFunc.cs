using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
namespace MLTPSWPR
{

    class adminFunc
    {

        public static MemoryStream ms,tempmem;
        public static int staffID;
        public static int age;
        public static string fname, lname, mname, gender, address, contactno, department, email, username, password;
        public static DateTime dateofbirth, dateregister;
        DBConnection cs = new DBConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand sc = new SqlCommand();
        DataTable dt = new DataTable();

        public DataTable fetchStaff()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spfetchStaff", DBConnection.conn);
                sda.Fill(dt);
                return dt;
            }
            finally 
            {
                cs.CloseConnection();
            }
        }
        public void fetchUpdatestaff()
        {
            try
            {

                cs.Connection();
                sc = new SqlCommand("execute spfetchUpdatestaff @staffID", DBConnection.conn);
                sc.Parameters.Add("@staffId", staffID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    Register.sFname = dr["Fname"].ToString();
                    Register.sMname = dr["Mname"].ToString();
                    Register.sLname = dr["Lname"].ToString();
                    Register.sAge = Convert.ToInt32(dr["Age"].ToString());
                    Register.sGender = dr["Gender"].ToString();
                    Register.sDOB = Convert.ToDateTime(dr["DateOfBirth"].ToString());
                    Register.sDR = Convert.ToDateTime(dr["Registered"].ToString());
                    Register.semail = dr["Email"].ToString();
                    Register.sContactno = dr["ContactNo"].ToString();
                    Register.sDept = dr["Department"].ToString();
                    Register.sAddress = dr["Location"].ToString();
                    Register.susername = dr["Username"].ToString();
                    Register.spassword = dr["Pword"].ToString();
                    Register.sDept = dr["Department"].ToString();
                    Register.mem = new MemoryStream((byte[])dr["Picture"]);
                }
            }
            catch
            {
                MessageBox.Show("No picture");
            }
            finally
            {
                cs.CloseConnection();
            }
            
        }
        public void staffUpdate()
        {
            try
            {
                byte[] pic;
                pic = ms.ToArray();
                cs.Connection();
                sc = new SqlCommand(@"execute spUpdateStaff @staffID,@fname,@lname,@mname,@gender,@address,
                    	@contactno,@department,@email,@username,@password,@age,@dateofbirth,@dateregister,@image", DBConnection.conn);
                sc.Parameters.Add("@staffID", staffID);
                sc.Parameters.Add("@fname", fname);
                sc.Parameters.Add("@lname", lname);
                sc.Parameters.Add("@mname", mname);
                sc.Parameters.Add("@gender", gender);
                sc.Parameters.Add("@address", address);
                sc.Parameters.Add("@contactno", contactno);
                sc.Parameters.Add("@department", department);
                sc.Parameters.Add("@email", email);
                sc.Parameters.Add("@username", username);
                sc.Parameters.Add("@password", password);
                sc.Parameters.Add("@age", age);
                sc.Parameters.Add("@dateofbirth", dateofbirth);
                sc.Parameters.Add("@dateregister", dateregister);
                sc.Parameters.Add("@image",pic);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Update");
            }
            finally 
            {
                cs.CloseConnection();
            }
        }
    }
}
