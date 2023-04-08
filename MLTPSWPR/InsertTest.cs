using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MLTPSWPR
{
    class InsertTest
    {
        public static MemoryStream ms;
        public static int price;
        public static string PatientID, department, Laboratory, XRay, PE, coptha, Dental, Neuro;
        public static string ishi, UAishiVi, AishiVi, remark;
        public static int patientID, pAge, UAFarOD, UAFarOS, UANearOD, UANearOS, AFarOD, AFarOS, ANearOD, ANearOS;
        public static string NBloodPressure, NHeight, NWeight, NAudio, NECG,Xexamination,Xrr,Ximpression;
        public static string pFname, pMname,pLname, pGender, pCivilStatus, pNOE, pNOA, pDestination, pPosition, pAddress, pexam;
        public static string rLname, rFname, rMname, rGender, rMinTime, rMaxTime,cpack;
        public static int rID, rAge,Qnum;
        public static DateTime pDateOfBirth, XrDOE,date;
        public static DateTime rDateOfBirth, rDateOfApp;
        DBConnection cs = new DBConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlCommand sc = new SqlCommand();
        DataTable dt = new DataTable();
        
        public void insertOptha()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spinsertOptha @PatientID,@Ishihara,@UnaidedFarOD,@UnaidedFarOS,@UnaidedNearOD,@UnaidedNearOS,@UnaidedIshiharaVision,@AidedFarOD,@AidedFarOS,@AidedNearOD,@AidedNearOS,@AidedIshiharaVision,@Remarks,@Eyes,@Vision", DBConnection.conn);
                sc.Parameters.Add("@PatientID", Optha.id);
                sc.Parameters.Add("@Ishihara",Optha.ishi);
                sc.Parameters.Add("@UnaidedFarOD",Optha.uodF);
                sc.Parameters.Add("@UnaidedFarOS",Optha.uosF);
                sc.Parameters.Add("@UnaidedNearOD",Optha.uodN);
                sc.Parameters.Add("@UnaidedNearOS",Optha.uosN);
                sc.Parameters.Add("@UnaidedIshiharaVision",Optha.Uishivis);
                sc.Parameters.Add("@AidedFarOD",Optha.aodF);
                sc.Parameters.Add("@AidedFarOS",Optha.aosF);
                sc.Parameters.Add("@AidedNearOD",Optha.aodN);
                sc.Parameters.Add("@AidedNearOS",Optha.aosN);
                sc.Parameters.Add("@AidedIshiharaVision",Optha.Aishivis);
                sc.Parameters.Add("@Remarks",Optha.remarks);
                sc.Parameters.Add("@Eyes",Optha.eyes);
                sc.Parameters.Add("@Vision",Optha.vision);
                sc.ExecuteNonQuery();

                sc = new SqlCommand("execute spupdateXpend @ID,@Lab", DBConnection.conn);
                sc.Parameters.Add("@ID", patientID);
                sc.Parameters.Add("@Lab", "Optha");
                sc.ExecuteNonQuery();
                
                MessageBox.Show("Succesfully Saved");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void spUpdateOptha()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spUpdateOptha @PatientID,@Ishihara,@UnaidedFarOD,@UnaidedFarOS,@UnaidedNearOD,@UnaidedNearOS,@UnaidedIshiharaVision,@AidedFarOD,@AidedFarOS,@AidedNearOD,@AidedNearOS,@AidedIshiharaVision,@Remarks,@Eyes,@Vision", DBConnection.conn);
                sc.Parameters.Add("@PatientID", Optha.id);
                sc.Parameters.Add("@Ishihara", Optha.ishi);
                sc.Parameters.Add("@UnaidedFarOD", Optha.uodF);
                sc.Parameters.Add("@UnaidedFarOS", Optha.uosF);
                sc.Parameters.Add("@UnaidedNearOD", Optha.uodN);
                sc.Parameters.Add("@UnaidedNearOS", Optha.uosN);
                sc.Parameters.Add("@UnaidedIshiharaVision", Optha.Uishivis);
                sc.Parameters.Add("@AidedFarOD", Optha.aodF);
                sc.Parameters.Add("@AidedFarOS", Optha.aosF);
                sc.Parameters.Add("@AidedNearOD", Optha.aodN);
                sc.Parameters.Add("@AidedNearOS", Optha.aosN);
                sc.Parameters.Add("@AidedIshiharaVision", Optha.Aishivis);
                sc.Parameters.Add("@Remarks", Optha.remarks);
                sc.Parameters.Add("@Eyes", Optha.eyes);
                sc.Parameters.Add("@Vision", Optha.vision);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Update");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void InsertPatient()
        {

            try
            {
                byte[] pic;
                pic = ms.ToArray();
                cs.Connection();
                sc = new SqlCommand(@"execute spinsertPatient @Fname,@Mname,@Lname,@Age,
                @Gender,@CivilStatus,@NOE,@NOA,@Destination,@Position,@Address,@DateOfBirth,
                @PackageName,@Stat,@image", DBConnection.conn);
                sc.Parameters.Add("@Fname", pFname);
                sc.Parameters.Add("@Mname", pMname);
                sc.Parameters.Add("@Lname", pLname);
                sc.Parameters.Add("@Age", pAge);
                sc.Parameters.Add("@Gender", pGender);
                sc.Parameters.Add("@CivilStatus", pCivilStatus);
                sc.Parameters.Add("@NOE", pNOE);
                sc.Parameters.Add("@NOA", pNOA);
                sc.Parameters.Add("@Destination", pDestination);
                sc.Parameters.Add("@Position", pPosition);
                sc.Parameters.Add("@Address", pAddress);
                sc.Parameters.Add("@DateOfBirth", pDateOfBirth);
                sc.Parameters.Add("@PackageName", pexam);
                sc.Parameters.Add("@Stat", "Not Paid");
                sc.Parameters.Add("@image",pic);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Save");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void InsertCashier() 
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spinsertCashier @patientID", DBConnection.conn);
                sc.Parameters.Add("@patientID", patientID);
                sc.ExecuteNonQuery();
                cs.CloseConnection();
                
                
                MessageBox.Show("Succesfully Saved");
            }
            finally 
            {
                cs.CloseConnection();
            }
        }
        public void inseertcashierpending()
        {
            try 
            {
                cs.Connection();
                sc = new SqlCommand("execute spinsertCashierpending @ID,@Lab,@Xray,@PE,@optha,@Dental,@neuro,@date", DBConnection.conn);
                sc.Parameters.Add("@ID", patientID);
                if (cpack == "COMPLETE")
                {
                    sc.Parameters.Add("@Lab", "Pending");
                    sc.Parameters.Add("@Xray", "Pending");
                    sc.Parameters.Add("@PE", "Pending");
                    sc.Parameters.Add("@optha", "Pending");
                    sc.Parameters.Add("@Dental", "Pending");
                    sc.Parameters.Add("@neuro", "Pending");
                    sc.Parameters.Add("@date", date);
                }
                else if (cpack == "PREMED")
                {
                    sc.Parameters.Add("@Lab", "Pending");
                    sc.Parameters.Add("@Xray", " ");
                    sc.Parameters.Add("@PE", " ");
                    sc.Parameters.Add("@optha", " ");
                    sc.Parameters.Add("@Dental", " ");
                    sc.Parameters.Add("@neuro", " ");
                    sc.Parameters.Add("@date", date);
                }
                else if (cpack == "PHASE 1")
                {
                    sc.Parameters.Add("@Lab", "Pending");
                    sc.Parameters.Add("@Xray", "Pending");
                    sc.Parameters.Add("@PE", " ");
                    sc.Parameters.Add("@optha", " ");
                    sc.Parameters.Add("@Dental", " ");
                    sc.Parameters.Add("@neuro", " ");
                    sc.Parameters.Add("@date", date);
                }
                else if (cpack == "PHASE 2")
                {
                    sc.Parameters.Add("@Lab", "Pending");
                    sc.Parameters.Add("@Xray", " ");
                    sc.Parameters.Add("@PE", " ");
                    sc.Parameters.Add("@optha", " ");
                    sc.Parameters.Add("@Dental", " ");
                    sc.Parameters.Add("@neuro", " ");
                    sc.Parameters.Add("@date", date);
                }
                sc.ExecuteNonQuery();
            }
            
            finally 
            {
                cs.CloseConnection();
            }
        }
        public void InsertNurse()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spinsertNurse @PatientID,@BloodPressure,@Height,@Weight,@Audio,@ECG", DBConnection.conn);
                sc.Parameters.Add("@PatientID", patientID);
                sc.Parameters.Add("@BloodPressure", NBloodPressure);
                sc.Parameters.Add("@Height", NHeight);
                sc.Parameters.Add("@Weight", NWeight);
                sc.Parameters.Add("@Audio", NAudio);
                sc.Parameters.Add("@ECG", NECG);
                sc.ExecuteNonQuery();

                sc = new SqlCommand("execute spupdateXpend @ID,@Lab", DBConnection.conn);
                sc.Parameters.Add("@ID", patientID);
                sc.Parameters.Add("@Lab", "PE");
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Saved");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void spUpdateNurse()
        {
            try 
            {
                cs.Connection();
                sc = new SqlCommand("execute @PatientID,@BloodPressure,@Height,@Weight,@Audio,@ECG", DBConnection.conn);
                sc.Parameters.Add("@PatientID", patientID);
                sc.Parameters.Add("@BloodPressure", NBloodPressure);
                sc.Parameters.Add("@Height", NHeight);
                sc.Parameters.Add("@Weight", NWeight);
                sc.Parameters.Add("@Audio", NAudio);
                sc.Parameters.Add("@ECG", NECG);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Updated"); 
            }

            catch 
            {
                cs.CloseConnection();
            }
        }

        public void InsertXray()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spinsertXray @patientID,@DOE,@examination,@RR,@impression", DBConnection.conn);
                sc.Parameters.Add("@patientID",patientID);
                sc.Parameters.Add("@DOE",XrDOE);
                sc.Parameters.Add("@examination",Xexamination);
                sc.Parameters.Add("@RR",Xrr);
                sc.Parameters.Add("@impression",Ximpression);
                sc.ExecuteNonQuery();
                sc = new SqlCommand("execute spupdateXpend @ID,@Lab", DBConnection.conn);
                sc.Parameters.Add("@ID",patientID);
                sc.Parameters.Add("@Lab", "Xray");
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Save");
            }
            finally 
            {
                cs.CloseConnection();
            }
        }

        public void UpdateXray()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spupdateXray @patientID,@DOE,@examination,@RR,@impression", DBConnection.conn);
                sc.Parameters.Add("@patientID", patientID);
                sc.Parameters.Add("@DOE", XrDOE);
                sc.Parameters.Add("@examination", Xexamination);
                sc.Parameters.Add("@RR", Xrr);
                sc.Parameters.Add("@impression", Ximpression);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Save");
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void InsertReserve()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand(@"execute spinsertReserve @Fname,@Mname,@Lname,@Age,
                @Gender,@DateOfBirth,@DateOfApp,@MinTime,@MaxTime", DBConnection.conn);
                sc.Parameters.Add("@Fname", rFname);
                sc.Parameters.Add("@Mname", rMname);
                sc.Parameters.Add("@Lname", rLname);
                sc.Parameters.Add("@Age", rAge);
                sc.Parameters.Add("@Gender", rGender);
                sc.Parameters.Add("@DateOfBirth", rDateOfBirth);
                sc.Parameters.Add("@DateOfApp", rDateOfApp);
                sc.Parameters.Add("@MinTime", rMinTime);
                sc.Parameters.Add("@MaxTime", rMaxTime);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Add");
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void UpdateReserve()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand(@"execute spupdateReserve @ReservationID,@Fname,@Mname,@Lname,@Age,@Gender,
                        @DateOfBirth,@DateOfApp,@MinTime,@MaxTime", DBConnection.conn);
                sc.Parameters.Add("@ReservationID", rID);
                sc.Parameters.Add("@Fname", rFname);
                sc.Parameters.Add("@Mname", rMname);
                sc.Parameters.Add("@Lname", rLname);
                sc.Parameters.Add("@Age", rAge);
                sc.Parameters.Add("@Gender", rGender);
                sc.Parameters.Add("@DateOfBirth", rDateOfBirth);
                sc.Parameters.Add("@DateOfApp", rDateOfApp);
                sc.Parameters.Add("@MinTime", rMinTime);
                sc.Parameters.Add("@MaxTime", rMaxTime);
                sc.ExecuteNonQuery();
                MessageBox.Show("Succesfully Update");
            }
            finally
            {
                cs.CloseConnection();
            }
        }

        public void DeleteReserve()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand(@"execute spdeleteReserve @ReservationID", DBConnection.conn);
                sc.Parameters.Add("@ReservationID", rID);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void spInsertQ()
        {
            try
            {
                Cashier c = new Cashier();
                cs.Connection();
                sc = new SqlCommand(@"execute spInsertQ @ID,@Qnum,@Package", DBConnection.conn);
                sc.Parameters.Add("@ID", patientID);
                sc.Parameters.Add("@Qnum",Qnum);
                sc.Parameters.Add("@Package", cpack);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void resetQ() 
        {
            try 
            {
                cs.Connection();
                sc = new SqlCommand("execute resetQ", DBConnection.conn);
                sc.ExecuteNonQuery();
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        public void spaddLab()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand("execute spaddLab @department, @price", DBConnection.conn);
                sc.Parameters.Add("@department", department);
                sc.Parameters.Add("@price", price.ToString("C0"));
                sc.ExecuteNonQuery();
                MessageBox.Show("Laboratory created");
            }
            finally
            {
                cs.CloseConnection();
            }
        }
        /*public string DeleteTime()
        {
            try
            {
                cs.Connection();
                sc = new SqlCommand(@"execute spdeleteTime", DBConnection.conn);
                SqlDataReader dr = sc.ExecuteReader();
                string date = "";
                string time = "";
                while (dr.Read())
                {
                    date = dr["DateOfApp"].ToString();
                    time = dr["MinTime"].ToString();
                }
                DataTable dt;

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                cs.CloseConnection();
            }
        }*/
    }
}
