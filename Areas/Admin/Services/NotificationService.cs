using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication.Areas.Admin.Models;
using WebApplication.Data;

namespace WebApplication.Areas.Admin.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async void SendToIndividualStudent(string AppNo_AadharNo, string msg)
        {
            var Contact = _context.ApplicationForms.Where(app => app.AadharNo == AppNo_AadharNo && app.StatusId != 2).Select(app => app.ContactNo).FirstOrDefault();

            string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=YourUserName:YourPassword&senderID=YourSenderID&    receipientno=" + Contact + "&msgtxt=" + msg + "API&state=4";
            WebRequest request = HttpWebRequest.Create(strUrl);
            WebResponse response = await request.GetResponseAsync();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
        }
        public async void SendByGroup(string[] groups, string msg)
        {
            foreach (var branch in groups)
            {
                var ListOfContacts = _context.ApplicationForms.Where(app => app.CoursePreferred == branch && app.StatusId != 2).Select(app => app.ContactNo).ToList();
                foreach (var Contact in ListOfContacts)
                {
                    string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=YourUserName:YourPassword&senderID=YourSenderID&    receipientno=" + Contact + "&msgtxt=" + msg + "API&state=4";
                    WebRequest request = HttpWebRequest.Create(strUrl);
                    WebResponse response = await request.GetResponseAsync();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    string dataString = readStream.ReadToEnd();
                }
            }
        }
        public async void SendToAllStudents(string msg)
        {
            var allContact = _context.ApplicationForms.Where(app => app.StatusId != 2).Select(app => app.ContactNo).ToList();
            foreach (var Contact in allContact)
            {
                string strUrl = "http://api.mVaayoo.com/mvaayooapi/MessageCompose?user=YourUserName:YourPassword&senderID=YourSenderID&    receipientno=" + Contact + "&msgtxt=" + msg + "API&state=4";
                WebRequest request = HttpWebRequest.Create(strUrl);
                WebResponse response = await request.GetResponseAsync();
                Stream s = (Stream)response.GetResponseStream();
                StreamReader readStream = new StreamReader(s);
                string dataString = readStream.ReadToEnd();
            }
        }

        public Boolean IsExists(string AppNo_AadharNo)
        {
            string appNo = null;
            if (AppNo_AadharNo != null)
            {
                if (AppNo_AadharNo.Length == 12)
                {
                    appNo = _context.ApplicationForms.Where(s => s.AadharNo == AppNo_AadharNo.ToString() && s.StatusId == 1).Select(s => s.ApplicationNo).FirstOrDefault();
                }
                else
                {
                    appNo = _context.ApplicationForms.Where(s => s.ApplicationNo == AppNo_AadharNo.ToString() && s.StatusId == 1).Select(s => s.ApplicationNo).FirstOrDefault();
                }
            }
            if (appNo == null)
                return false;
            return true;
        }



        //public string apicall(string url)
        //{
        //    HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        //    try
        //    {
        //        //HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
        //        //StreamReader sr = new StreamReader(httpres.GetResponseStream());

        //        //string results = sr.ReadToEnd();

        //        //sr.Close();
        //        //return results;

        //    }
        //    catch
        //    {
        //        return "0";
        //    }
        //    return "0";
        //}

    }
}
