using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LocalSite.Model;
using EncryptionAndDecryption;


namespace LocalSite.Account
{
    public partial class Register : System.Web.UI.Page
    {
            
        
        SqlConnection con=new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        UserActions regu = new UserActions();

        string s; int n;

        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordTextBoxID.Enabled = false;
            ConfirmPasswordTextBoxID.Enabled = false;
            SendPwdID.Text = "Send Password";
            
        }

        protected void SubmitButtonID_Click(object sender, EventArgs e)
        {
            //if (PasswordID.ToString().Equals(ConfirmPasswordID.ToString()))
            if (PasswordTextBoxID.Text.Equals(Session["MailPassword"]))
            {
                /*con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
                con.Open();
                cmd.CommandText = "insert into EmployeeDetails (EmpUserName,EmpPassword) values('" + UserNameTextBoxID.Text + "',' " + PasswordTextBoxID.Text + "')";
                cmd.Connection = con;
                int n = cmd.ExecuteNonQuery();
                con.Close();*/


                s = EncryptionAndDecryption.Class1.Encrypt(PasswordTextBoxID.Text);
                int n=regu.userregister(UserNameTextBoxID.Text, s);
                if (n>0)
                {
                    ErrorMsg.Visible = true;
                    ErrorMsg.Text = "Created User entry Sucessfully";
                    UserNameTextBoxID.Text = "";
                }
            }
            else
            {
                ErrorMsg.Text = "Please make sure your password should be the one sent to your mail ";
            }

            
        }

        protected void CancelRegisterID_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }


        protected void SendPwdID_Click(object sender, EventArgs e)
        {
            // n= regu.CheckUserAvailability(UserNameTextBoxID.Text);
            if (regu.CheckUserAvailability(UserNameTextBoxID.Text)==true)
            //if(s!=null)
            {
                ErrorMsg.Visible = true;
                ErrorMsg.Text = "UserName Not Available";
                
            }
             else
            {
               
                Session["MailPassword"] = "";
                Session["MailPassword"] = regu.sendMail(UserNameTextBoxID.Text);
                PasswordTextBoxID.Enabled = true;
                ConfirmPasswordTextBoxID.Enabled = true;
                SendPwdID.Text = "Re Send Password";
            }
            
        }

        //protected void UserNameTextBoxID_TextChanged(object sender, EventArgs e)
        //{
          
        //        ErrorMsg.Text = "UserName Available";
        //    }
           
        //}

        

       
        

    }
}
