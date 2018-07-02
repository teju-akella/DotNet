using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LocalSite.Model;

namespace LocalSite.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        UserActions regu = new UserActions();
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void ChangePwdBtnID_Click(object sender, EventArgs e)
        {
            int n = regu.changePwd(Session["username"].ToString(), OldPwdTxtBoxID.Text, ForgetNewPwdtxtbxID.Text);
            if (n > 0)
            {
                ChangePwdLabelID.Enabled = true;
                ChangePwdLabelID.Text = "password changed sucessfully";
            }
            else
            {
                ChangePwdLabelID.Enabled = true;
                ChangePwdLabelID.Text = "please enter diffrent password";
            }
        }

        
    }
}
