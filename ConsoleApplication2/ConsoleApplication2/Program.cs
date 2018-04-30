using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;
using System.IO;
using Microsoft.Exchange.WebServices.Data;

namespace ExecutejiraBat
{
    class Program
    {
        public void XmlRead()
        {
            // read build version from XML
            FileStream fs = new FileStream(@"C:\tc\icts\Version.xml", FileMode.Open, FileAccess.Read);
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;

            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Full_Build");
            string build = xmlnode[0].ChildNodes.Item(1).InnerText;
            Console.WriteLine("version from XML: "+build);

            //Read a text file and compare build version
            string PrevBuild = File.ReadAllText(@"C:\tc\icts\PrevBuild.txt");
            Console.WriteLine("version from text file: "+PrevBuild);

            if (build.Equals(PrevBuild))
            {
                Console.WriteLine("both equal");
            }
            else
            {
                File.WriteAllText(@"C:\tc\icts\PrevBuild.txt", build);
            }
            
        }

        static bool RedirectionCallback(string url)
        {
            // Return true if the URL is an HTTPS URL.
            return url.ToLower().StartsWith("https://");
        }

        public void MailRead()
        {
            //Application outlookApplication = null;
            //NameSpace outlookNamespace=null;
            //MAPIFolder inboxFolder = null;
            //Items mailItems = null;

            //try
            //{
            //    //outlookApplication = new Application();
            //    //outlookNamespace = outlookApplication.GetNamespace("MAPI");
            //    //inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
            //    //mailItems = inboxFolder.Items;


            //}

            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);
            service.Credentials = new WebCredentials("aakella@amphorainc.com", "2923ujeT");
            service.AutodiscoverUrl("aakella@amphorainc.com", RedirectionCallback);
            service.TraceEnabled = false;
            service.TraceFlags = TraceFlags.All;

            FolderView view = new FolderView(100);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            view.PropertySet.Add(FolderSchema.DisplayName);
            view.Traversal = FolderTraversal.Deep;
            FindFoldersResults findFolderResults = service.FindFolders(WellKnownFolderName.Inbox, view);
            //find specific folder
            foreach (Folder f in findFolderResults)
            {
                //show folderId of the folder "test"
                if (f.DisplayName == "to_do")
                {
                    Console.WriteLine("id is: " + f.Id);
                    var items = service.FindItems(f.Id, new ItemView(5));
                    foreach (EmailMessage msg in items)
                    {
                        Console.WriteLine("###########Subject is:" + msg.Subject.ToString());
                    }

                }
                    
            }
            var filter = new SearchFilter.IsEqualTo(FolderSchema.DisplayName, "to_do");
            //var items=service.FindItems(
                //new FolderId(WellKnownFolderName.Inbox, new Mailbox("to_do")),new ItemView(10));
           
        }

        private void executeBatFile()
        {
            Process proc = null;
            try
            {
                string targetdir = string.Format(@"D:\Teju\VS\Update_Jira");
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetdir;
                proc.StartInfo.FileName = "jira.bat";
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceptionis: "+ex);
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.executeBatFile();
            p.MailRead();
        }

    }
}
