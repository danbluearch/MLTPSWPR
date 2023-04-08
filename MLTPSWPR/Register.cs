using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MLTPSWPR
{
    public partial class Register : Form
    {
       
        public static MemoryStream  mem; 
        public static string action,sFname,sMname,sLname,sAddress,sGender,semail,sContactno,sDept,susername,spassword;
       public static int sAge;
        public static DateTime sDOB,sDR;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            
            
            FetchPatient fp = new FetchPatient();
            cbDept.DataSource = fp.spfetchDepartment().DefaultView;
            cbDept.DisplayMember = "departmentName";
            cbDept.Text = "";
            
            if (action == "SignUp")
            {
                button3.Text = "Register";
            }
            else if (action == "Update") 
            {
                button3.Text = "Update";
                txtFname.Text = sFname.ToString();
                txtMname.Text = sMname.ToString();
                txtLname.Text = sLname.ToString();
                txtage.Text = sAge.ToString();
                txtaddress.Text = sAddress.ToString();
                if (sGender == "Male" || sGender == "male")
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                txtemail.Text = semail.ToString();
                dtpDatebirth.Text = sDOB.ToShortDateString();
                dtpDateReg.Text = sDR.ToShortDateString();
                txtcontactNo.Text = sContactno.ToString();
                cbDept.Text = sDept.ToString();
                txtusername.Text = susername.ToString();
                txtpassword.Text = spassword.ToString();
                pictureBox1.Image = Image.FromStream(mem);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Register")
            {
                try
                {
                    const string message =
                        "Are you sure want to register this?";

                    const string caption = "Adding Staff";
                    var result = MessageBox.Show(message, caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        RegisterStaff.fname = txtFname.Text.ToString();
                        RegisterStaff.mname = txtMname.Text.ToString();
                        RegisterStaff.lname = txtLname.Text.ToString();
                        RegisterStaff.age = Convert.ToInt32(txtage.Text.ToString());
                        if (rdMale.Checked == true)
                        {
                            RegisterStaff.gender = "Male";
                        }
                        else if (rdFemale.Checked == true)
                        {
                            RegisterStaff.gender = "Female";
                        }
                        else
                        {
                            MessageBox.Show("Please select a gender");
                        }
                        RegisterStaff.address = txtaddress.Text.ToString();
                        RegisterStaff.contactno = txtcontactNo.Text.ToString();
                        RegisterStaff.department = cbDept.Text.ToString();
                        RegisterStaff.email = txtemail.Text.ToString();
                        RegisterStaff.username = txtusername.Text.ToString();
                        RegisterStaff.password = txtpassword.Text.ToString();
                        RegisterStaff.dateofbirth = dtpDatebirth.Value;
                        RegisterStaff.dateregister = dtpDateReg.Value;
                        if (pictureBox1.Image != null)
                        {
                            MemoryStream tms = new MemoryStream();
                            pictureBox1.Image.Save(tms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            RegisterStaff.ms = tms;
                        }
                        else 
                        {
                            MessageBox.Show("Please insert a picture");
                        }
                        RegisterStaff rs = new RegisterStaff();
                        rs.register();
                        txtFname.Text = "";
                        txtMname.Text = "";
                        txtLname.Text = "";
                        txtage.Text = "";
                        txtaddress.Text = "";
                        txtcontactNo.Text = "";
                        cbDept.Text = "";
                        txtemail.Text = "";
                        txtusername.Text = "";
                        txtpassword.Text = "";
                        this.Hide();
                        Admin a = new Admin();
                        a.Show();
                    }
                }
                catch
                {
                    MessageBox.Show("Somethings wrong!! Please check and fill all the information");
                }
            }
            else if (button3.Text == "Update")
            {
                try
                {
                    
                    adminFunc.fname = txtFname.Text.ToString();
                    adminFunc.mname = txtMname.Text.ToString();
                    adminFunc.lname = txtLname.Text.ToString();
                    adminFunc.age = Convert.ToInt32(txtage.Text.ToString());
                    if (rdMale.Checked == true)
                    {
                        adminFunc.gender = "Male";
                    }
                    else if (rdFemale.Checked == true)
                    {
                        adminFunc.gender = "Female";
                    }
                    else
                    {
                        MessageBox.Show("Please select a gender");
                    }
                    adminFunc.address = txtaddress.Text.ToString();
                    adminFunc.contactno = txtcontactNo.Text.ToString();
                    adminFunc.department = cbDept.Text.ToString();
                    adminFunc.email = txtemail.Text.ToString();
                    adminFunc.username = txtusername.Text.ToString();
                    adminFunc.password = txtpassword.Text.ToString();
                    adminFunc.dateofbirth = dtpDatebirth.Value;
                    adminFunc.dateregister = dtpDateReg.Value;
                    if (pictureBox1.Image != null)
                    {
                        MemoryStream tms = new MemoryStream();
                        pictureBox1.Image.Save(tms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        adminFunc.ms = tms;
                    }
                    else
                    {
                        MessageBox.Show("Please insert a picture");
                    }
                    adminFunc af = new adminFunc();
                    af.staffUpdate();
                    adminFunc.staffID = 0;
                    this.Hide();
                    Admin a = new Admin();
                    a.Show();
                }
                catch
                {
                    MessageBox.Show("Please fill all the information");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminFunc.staffID = 0;
            Admin A = new Admin();
            A.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(open.FileName);
                pictureBox1.Image = img.GetThumbnailImage(126, 122, null, new IntPtr());
            }
        }
    }
}
