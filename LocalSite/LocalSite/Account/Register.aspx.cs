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

namespace LocalSite.Account
{
    public partial class Register : System.Web.UI.Page
    {
            
        
        SqlConnection con=new SqlConnection();
        SqlCommand cmd = new SqlCommand();  

        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            
        }

        protected void SubmitButtonID_Click(object sender, EventArgs e)
        {
            if (PasswordID.ToString().Equals(ConfirmPasswordID.ToString()))
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
                con.Open();
                cmd.CommandText = "insert into EmployeeDetails values(" + UserNameID.ToString() + "," + PasswordID.ToString() + ")";
                cmd.Connection = con;
                int n = cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                ErrorMsg.Text = "Please make sure your password and Confirm Password columns should match";
            }
            
        }

        

       
        

    }
}
