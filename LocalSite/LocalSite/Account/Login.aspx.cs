using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LocalSite.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("ChangePasswordNew.aspx");
            }
            catch (Exception ex)
            {
                Label1.Text = "not changed"+ex;

            }
        }
    }
}
