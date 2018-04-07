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

namespace ChatApp
{
    
    //This whole thing is a mess, but it works
    public partial class frmLogin : Form
    {

        public static string CurrentUser;
        string connectionString = @"Data Source=DESKTOP-T42J6PE\SQLEXPRESS;Initial Catalog=UserReg;Integrated Security=True";

        public frmLogin()
        {
            InitializeComponent();
        }
  
        public void btnReg_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                //This block of code checks if the value in the email textbox already exists in the database
                sqlCon.Open();
                SqlCommand checkEmail = new SqlCommand("SELECT COUNT(*) FROM [tblUser] WHERE ([Email] = @email)", sqlCon);
                checkEmail.Parameters.AddWithValue("@email", txtEmail.Text);
                int UserExist = (int)checkEmail.ExecuteScalar();

                if (UserExist > 0)
                {
                    //if the email does exist, this checks if an email exists with the entered password
                    SqlCommand checkPass = new SqlCommand("SELECT COUNT(*) FROM [tblUser] WHERE ([Password] = @pass) and ([Email] = @email)", sqlCon);
                    checkPass.Parameters.AddWithValue("@pass", txtPass.Text);
                    checkPass.Parameters.AddWithValue("@email", txtEmail.Text);
                    int PassCorrect = (int)checkPass.ExecuteScalar();
                    if (PassCorrect == 1)
                    {
                        sqlCon.Close();
                        //stores the username of the user who just logged in
                        CurrentUser = txtEmail.Text;
                        MessageBox.Show("Welcome");
                        sqlCon.Open();
                        //registers the user as online in the database
                        SqlCommand addOnline = new SqlCommand("INSERT INTO tblOnline (usern) VALUES (@username)", sqlCon);
                        addOnline.Parameters.AddWithValue("@username", CurrentUser);
                        addOnline.ExecuteScalar();
                        sqlCon.Close();
                        //logs in
                        FrmChat f2 = new FrmChat();
                        f2.Show();
                        this.Hide();        
                    }
                    else
                    {
                        sqlCon.Close();
                        MessageBox.Show("Password incorrect");
                    }
                }
                else
                {
                    //if the email does not exist, this creates a new entry in the database with the entered email and password
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPass.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                    MessageBox.Show("Account Registered"); 
                }
            }
        }

    }
}
