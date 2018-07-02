using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LocalSite.Model;
using EncryptionAndDecryption;

namespace LocalSite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["username"] = LoginTextBoxID.Text.ToString();
        }


       

        protected void LoginBtnID_Click(object sender, EventArgs e)
        {
            UserActions regu = new UserActions();
            
            string s = regu.userLogin(LoginTextBoxID.Text+"@amphorainc.com",PasswordTextBoxID.Text);
            if (s == PasswordTextBoxID.Text)
            {
                
                Response.Redirect("/Account/Login.aspx");
                //result.Visible = true;
                //result.Text = "Suceesfully retrived data :" + s;
            }
            else if (s == "User is **NOT REGISTERED** yet")
            {
                result.Visible = true;
                result.ForeColor = System.Drawing.Color.Red;
                result.Text = s;
            }
            else
            {
                result.Visible = true;
                result.ForeColor=System.Drawing.Color.RoyalBlue;
                result.Text = "You have entered **WRONG PASSWORD**";
            }
        }

       
    }
}
