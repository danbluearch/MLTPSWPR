using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace MLTPSWPR
{
    class RegisterStaff
    {
        public static MemoryStream ms;
        public static int age;
        public static string fname, lname, mname, gender, address, contactno, department, email, username, password;
        public static DateTime dateofbirth, dateregister;
        DBConnection cs = new DBConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand sc = new SqlCommand();
        DataTable dt = new DataTable();
        public void register()
        {
            try
            {
                byte[] pic;
                pic = ms.ToArray();
                cs.Connection();
                sc = new SqlCommand(@"execute spregisterStaff @fname,@mname,@lname,@age,@gender,@dob,@dr,
                @email,@contactno,@dept,@address,@username,@pword,@stat,@image", DBConnection.conn);
                sc.Parameters.Add("@fname",fname);
                sc.Parameters.Add("@mname", mname);
                sc.Parameters.Add("@lname", lname);
                sc.Parameters.Add("@age", age);
                sc.Parameters.Add("@gender", gender);
                sc.Parameters.Add("@dob", dateofbirth);
                sc.Parameters.Add("@dr", dateregister);
                sc.Parameters.Add("@email", email);
                sc.Parameters.Add("@contactno", contactno);
                sc.Parameters.Add("@dept", department);
                sc.Parameters.Add("@address", address);
                sc.Parameters.Add("@username", username);
                sc.Parameters.Add("@pword", password);
                sc.Parameters.Add("@stat", "Logout");
                sc.Parameters.Add("@image", pic);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Save");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
    }
}
