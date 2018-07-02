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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;


namespace LocalSite.Model
{
    public class UserActions
    {

        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;


        int n = 0; string s; public string passwrd; string readerPWD,pwd;

        //Json function for cheking a username exist or not
       public bool CheckUserAvailability(string username)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText = "select EmpUserName from EmployeeDetails where EmpUserName='" + username + "@amphorainc.com'";
            cmd.Connection = con;
            //cmd.ExecuteScalar();
            //con.Close();
            //return n;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public int userregister(string user, string password)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText = "insert into EmployeeDetails (EmpUserName,EmpPassword) values('" + user + "@amphorainc.com','" + password + "')";
            cmd.Connection = con;
            n=cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }
        public string userLogin(string Loginusername, string Loginpassword)
        {
            
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText="select EmpPassword from EmployeeDetails where EmpUserName='"+Loginusername+"'";
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                reader.Read();
                pwd = reader["EmpPassword"].ToString();
                s = EncryptionAndDecryption.Class1.Decrypt(pwd);
                con.Close();
                return s;
            }
            else
            {
                s = "User is **NOT REGISTERED** yet";
                con.Close();
                return s;
            }           
        }
        //public string password()
        //{
        //    RandomPasswordGenerateLibrary.Randopwd temp = new Randopwd();
        //    passwrd= temp.ranpwd();
        //    return passwrd;

        //}
        public string sendMail(string mailID)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("AmphoraBDT@amphorainc.com");
            msg.To.Add(mailID+"@amphorainc.com");
            msg.Subject = "Password generation Mail from Amphora BDT";
            RandomPasswordGenerateLibrary.Randopwd temp = new Randopwd();
            passwrd = temp.ranpwd();
            msg.Body = "Password is: "+passwrd;
            msg.IsBodyHtml = true;
            SmtpClient sm = new SmtpClient("172.16.170.145");
            sm.Port = 25;
            sm.Send(msg);
            return passwrd;
        }
        public int changePwd(string user, string oldpwd, string newpwd)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            con.Open();
            cmd.CommandText = "select EmpPassword from EmployeeDetails where EmpUserName='" + user + "@amphorainc.com'";
            cmd.Connection = con;
            s = cmd.ExecuteScalar().ToString();
            if (s == oldpwd&&s!=newpwd)
            {
                cmd.CommandText = "update EmployeeDetails set EmpPassword='" + newpwd + "' where EmpUserName='" + user + "@amphorainc.com'";
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