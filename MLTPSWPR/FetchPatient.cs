using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MLTPSWPR
{
    class FetchPatient
    {
        public static string patient = "", procedure = "",package, pword, username, tableName;
        public static string name, agency, id, gender, status;
        public static string exam, radio, impress;
        public static string oname, oagency, odestination,oid;
        public static int countq,age,oage;
        public static string nblood, nweight, nheight, naudio, necg;
        public static DateTime dob, doa, doe;
        public static string bill,amount,change1;
        DBConnection cs = new DBConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        NursingStation ns = new NursingStation();
        SqlCommand sc = new SqlCommand();
        DataTable dt = new DataTable();
        public static string Stat = "donthave",stat1 ="Not",department;
        string change;
        public static int Qnum,tempQnum;
        //public DataTable viewOptha()
        //{
        //    try
        //    {
        //        cs.Connection();
        //        sda = new SqlDataAdapter("execute spviewOptha", DBConnection.conn);
        //        sda.Fill(dt);
        //        return dt;
        //    }
        //    finally 
        //    {
        //        cs.CloseConnection();
        //    }
        //}
        public DataTable spviewCashier()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spviewCashier", DBConnection.conn);
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spFetchUpdateNurse()
        {
            try
            {
                
                cs.Connection();
                sc = new SqlCommand("execute spFetchUpdateNurse @PatientID",DBConnection.conn);
                sc.Parameters.Add("@PatientID",Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    nblood = dr["BloodPressure"].ToString();
                    nheight = dr["Height"].ToString();
                    nweight = dr["Weigh"].ToString();
                    naudio= dr["Audio"].ToString();
                    necg = dr["ECG"].ToString();
                }
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spviewNurse()
        {
            try
            {
                string lname, fname, mname;
                cs.Connection();
                sc = new SqlCommand("execute spFetchPatient @ID", DBConnection.conn);
                sc.Parameters.Add("@ID", Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    id = dr["PatientID"].ToString();
                    lname = dr["Lname"].ToString();
                    fname = dr["Fname"].ToString();
                    mname = dr["Mname"].ToString();
                    name = lname + ", " + fname + " " + mname;
                    gender = dr["Gender"].ToString();
                    dob = Convert.ToDateTime(dr["DateofBirth"].ToString());
                    age = Convert.ToInt32(dr["Age"].ToString());
                    //status = dr["CivilStatus"].ToString();
                    agency = dr["NOA"].ToString();
                }
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public DataTable spviewLaboratory()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spviewLaboratory", DBConnection.conn);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spviewXray()
        {
            try
            {
                string lname, fname, mname;
                cs.Connection();
                sc = new SqlCommand("execute spFetchPatient @ID", DBConnection.conn);
                sc.Parameters.Add("@ID", Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    id = dr["PatientID"].ToString();
                    lname = dr["Lname"].ToString();
                    fname = dr["Fname"].ToString();
                    mname = dr["Mname"].ToString();
                    name = lname + ", " + fname + " " + mname;
                    gender= dr["Gender"].ToString();
                    dob =Convert.ToDateTime(dr["DateofBirth"].ToString());
                    age =Convert.ToInt32( dr["Age"].ToString());
                    status = dr["CivilStatus"].ToString();
                    agency = dr["NOA"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spviewOptha()
        {
            try
            {
                string lname, fname, mname;
                cs.Connection();
                sc = new SqlCommand("execute spFetchPatient @ID", DBConnection.conn);
                sc.Parameters.Add("@ID", Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    oid = dr["PatientID"].ToString();
                    lname = dr["Lname"].ToString();
                    fname = dr["Fname"].ToString();
                    mname = dr["Mname"].ToString();
                    oname = lname + ", " + fname + " " + mname;
                    //gender = dr["Gender"].ToString();
                   // dob = Convert.ToDateTime(dr["DateofBirth"].ToString());
                    oage = Convert.ToInt32(dr["Age"].ToString());
                    //status = dr["CivilStatus"].ToString();
                    oagency = dr["NOA"].ToString();
                    odestination = dr["Destination"].ToString();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public DataTable spviewReserve()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spviewReserve", DBConnection.conn);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public DataTable spdeleteTime()
        {
            try
            {
                cs.Connection();
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter("execute spdeleteTime", DBConnection.conn);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public DataTable spfetchColumns()
        {
            try
            {
                cs.Connection();
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter("execute spfetchColumns @tableName", DBConnection.conn);
                sda.SelectCommand.Parameters.Add("@tableName", tableName);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public string spQueuing()
        {
            try
            {
                loginacc l = new loginacc();

                Qnum += 1;
                cs.Connection();
                sc = new SqlCommand("execute spQueuing @num", DBConnection.conn);
                sc.Parameters.Add("@num", Qnum);
                SqlDataReader dr = sc.ExecuteReader();
                while(dr.Read())
                {
                    patient = dr["PatientID"].ToString();
                    procedure = dr["ProcedureName"].ToString();
                    Main.package =dr ["Package"].ToString();
                    if(procedure == loginacc.department)
                    {
                        Stat = "have";
                        
                    }
                    if (Stat == "have")
                    {
                        tempQnum = Qnum; 
                        break;
                    }
                }
                if (patient == "")
                {
                    Qnum = tempQnum;
                    Stat = "have";
                    stat1 = "empty";
                }
                return Convert.ToString(Qnum);
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public DataTable spviewAll()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spviewAll @dept", DBConnection.conn);
                sda.SelectCommand.Parameters.Add("@dept", department);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public string spChange()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spChange @amount,@bill", DBConnection.conn);
                sc.Parameters.Add("@amount", amount);
                sc.Parameters.Add("@bill", bill);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    change = dr["Change"].ToString();
                    change1 = change1;
                }
                return change;

                cs.CloseConnection();
            }
            catch
            {
                return change;
            }
        }

        public DataTable spviewReserveByDate()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spviewReserveByDate @DateOfApp", DBConnection.conn);
                sda.SelectCommand.Parameters.Add("@DateOfApp", doa);
                sda.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spfetchUpdateOptha()
        {
            try 
            {
                cs.Connection();
                sc = new SqlCommand("execute spFetchUpdateOptha @id", DBConnection.conn);
                sc.Parameters.Add("@id",Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    Optha.id = dr["PatientID"].ToString(); //PatientID,
                    Optha.ishi = dr["Ishihara"].ToString();//Ishihara,
                    Optha.uodF = dr["UnaidedFarOD"].ToString();//UnaidedFarOD,
                    Optha.uosF = dr["UnaidedFarOS"].ToString();//UnaidedFarOS,
                    Optha.uodN = dr["UnaidedNearOD"].ToString();//UnaidedNearOD,
                    Optha.uosN = dr["UnaidedNearOS"].ToString();//UnaidedNearOS,
                    Optha.Uishivis = dr["UnaidedIshiharaVision"].ToString();//UnaidedIshiharaVision,
                    Optha.aodF = dr["AidedFarOD"].ToString();//AidedFarOD,
                    Optha.aosF = dr["AidedFarOS"].ToString();//AidedFarOS,
                    Optha.aodN = dr["AidedNearOD"].ToString();//AidedNearOD,
                    Optha.aosN = dr["AidedNearOS"].ToString();//AidedNearOS,
                    Optha.Aishivis = dr["AidedIshiharaVision"].ToString();//AidedIshiharaVision,
                    Optha.remarks = dr["Remarks"].ToString();//Remarks,
                    Optha.eyes = dr["Eyes"].ToString();//Eyes,
                    Optha.vision = dr["Vision"].ToString();//Vision
                }
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public void spfetchPending()
        {
            try
            {
                string lname,fname,mname;
                cs.Connection();
                sc = new SqlCommand("execute spFetchPatient @ID",DBConnection.conn);
                sc.Parameters.Add("@ID",Main.ID);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {   
                    lname = dr["Lname"].ToString();
                    fname = dr["Fname"].ToString();
                    mname = dr["Mname"].ToString();
                    Pending.name = lname + "," + fname + " " + mname;
                    Pending.agency = dr["NOA"].ToString();
                    Pending.age = Convert.ToInt32(dr["Age"].ToString());
                    Pending.package = dr["PackageName"].ToString();
                    Pending.position = dr["Position"].ToString();
                    Pending.destination = dr["Destination"].ToString();
                    Pending.gender = dr["Gender"].ToString();
                }
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public DataTable fetchPending()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spfetchPending @ID", DBConnection.conn);
                sda.SelectCommand.Parameters.Add("@ID",Main.ID);
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spFetchXray()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spFetchXray @patientID", DBConnection.conn);
                sc.Parameters.Add("@patientID", Main.ID);
                
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    doe = Convert.ToDateTime(dr["dateofExam"].ToString());
                    exam = dr["Examination"].ToString();
                    radio = dr["RadioReport"].ToString();
                    impress = dr["Impression"].ToString();
                }
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spCountQ()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spCountQ", DBConnection.conn);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    countq = Convert.ToInt16(dr["Total"].ToString());
                    countq += 1;
                }
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public void fetchQP()
        {
            try 
            {
                string lname, fname, mname;
                cs.Connection();
                sc = new SqlCommand("execute spfetchQP @ID",DBConnection.conn);
                sc.Parameters.Add("@ID",tempQnum);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    Main.PID = dr["PatientID"].ToString();
                    lname = dr["Lname"].ToString();
                    fname = dr["Fname"].ToString();
                    mname = dr["Mname"].ToString();
                    Main.Name = lname + ", " + fname + " " + mname;
                    Main.Age = dr["Age"].ToString();
                    Main.Gender = dr["Gender"].ToString();
                    Main.Address = dr["Address"].ToString();
                    Main.dob = Convert.ToDateTime(dr["DateOfBirth"].ToString());
                }
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public void fetchtemp()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute fetchtemp @Qnum,@ID,@Package",DBConnection.conn);
                sc.Parameters.Add("@Qnum", Qnum);
                sc.Parameters.Add("@ID",patient);
                sc.Parameters.Add("@Package",package);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void fetchtemp1()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute fetchtemp1 @Qnum,@ID,@Package", DBConnection.conn);
                sc.Parameters.Add("@Qnum", tempQnum);
                sc.Parameters.Add("@ID", patient);
                sc.Parameters.Add("@Package", package);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public int maxcount()
        {
            try
            {
                int a = 0;
                cs.Connection();
                sc = new SqlCommand("execute maxcount", DBConnection.conn);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    a = Convert.ToInt32(dr["maxcount"].ToString());
                }
                return a;
            }
            catch
            {
                return 0;
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public DataTable spfetchDepartment()
        {
            try
            {
                cs.Connection();
                sda = new SqlDataAdapter("execute spfetchDepartment", DBConnection.conn);
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return dt;
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spfetchPassword()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spfetchPassword @Username", DBConnection.conn);
                sc.Parameters.Add("@Username", username);
                SqlDataReader dr = sc.ExecuteReader();
                while (dr.Read())
                {
                    ChangePass cp = new ChangePass();
                    pword = dr["Pword"].ToString();
                }
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void spupdatePassword()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spupdatePassword @Username,@Pword", DBConnection.conn);
                sc.Parameters.Add("@Username", username);
                sc.Parameters.Add("@Pword", pword);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }
    }
}
