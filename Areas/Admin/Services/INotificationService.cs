using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Services
{
    public interface INotificationService
    {
        void SendToIndividualStudent(string AppNo_AadharNo, string msg);
        void SendByGroup(string[] groups, string msg);
        void SendToAllStudents(string msg);
        Boolean IsExists(string AppNo_AadharNo);
    }
}
