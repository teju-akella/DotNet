using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using RandomPasswordGenerateLibrary;


namespace LocalSite.Model
{
    public class UserActions
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        

        int n = 0; string s;
        public int userregister(string user, string password)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText = "insert into EmployeeDetails (EmpUserName,EmpPassword) values('" + user + "@amphorainc.com',' " + password + "')";
            cmd.Connection = con;
            n=cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }
        public string userLogin(string Loginusername, string Loginpassword)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText="select * from EmployeeDetails where EmpUserName='"+Loginusername+"'";
            cmd.Connection = con;
            s=cmd.ExecuteScalar().ToString();
           

            con.Close();
            return s;
        }
        public string password()
        {
            RandomPasswordGenerateLibrary.Randopwd temp = new Randopwd();
            string passwrd= temp.ranpwd();
            return passwrd;

        }
        public void sendMail(string mailID)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("AmphoraBDT@amphorainc.com");
            msg.To.Add(mailID+"@amphorainc.com");
            msg.Subject = "Password generation Mail from Amphora BDT";
            msg.Body = "Password is: "+password();
            msg.IsBodyHtml = true;
            SmtpClient sm = new SmtpClient("172.16.170.145");
            sm.Port = 25;
            sm.Send(msg);
        }
        public int changePwd(string user, string oldpwd, string newpwd)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText = "select EmpPassword from EmployeeDetails where EmpUserName='"+user+"'";
            cmd.Connection = con;
            s = cmd.ExecuteScalar().ToString();
            if (s == oldpwd&&s!=newpwd)
            {
                cmd.CommandText = "update EmployeeDetails set EmpPassword='" + newpwd + "' where EmpUserName='" + user + "'";
                cmd.Connection = con;
                n = cmd.ExecuteNonQuery();
            }
            else if (s==newpwd)
            {
                n = 0;
            }
            return n;
        }
    }
}