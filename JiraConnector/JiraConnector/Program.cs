using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atlassian;
using Atlassian.Jira;

namespace JiraConnector
{
    class Program
    {
        public void Connector()
        {
            Jira jiraconn = new Jira("http://amphorainc.atlassian.net/","aakella@amphorainc.com","2923Teju");

            string jqlString = PrepareJqlbyDates("2018-03-01", "2018-03-31");
            IEnumerable<Atlassian.Jira.Issue> jiraIssues = jiraconn.GetIssuesFromJql(jqlString, 10);
            
            foreach(var issue in jiraIssues)
            {
                 System.Console.WriteLine(issue.Key.Value +" -- "+ issue.Status.ToString());
            }
         }

        static string PrepareJqlbyDates(string beginDate, string endDate)
        {
            string jqlString = "project = Amphora Dev Symphony Oil AND status = Ready for Build";
            return jqlString;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Connector();
        }
    }
}
