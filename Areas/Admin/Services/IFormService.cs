using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication.Areas.Admin.Models;
namespace WebApplication.Areas.Admin.Services
{
    public interface IAdmission
    {
        string AddStudent(ApplicationForm appForm);
        string AppNo(string CName,int year);
        void UpdateStudent(ApplicationForm appForm);        
        void SaveImages(string appNo,ApplicationViewModel appForm);
        ApplicationForm getStudent(string AppNo);
        List<ApplicationForm> GetAllStudents(DateTime? date,int page,int pageSize, string studentName, string group);
        int Count(string studentName, string group, DateTime? Date);
        bool DeleteStudent(string appno,string description);
        string AppNo(string Sname,string Fname,string MobileNo);
    }

}