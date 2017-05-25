using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication.Areas.Admin.Models;
namespace WebApplication.Areas.Admin.Services
{
    public interface IAdmission
    {
        void AddStudent(ApplicationForm appForm);
        string AppNo();
        string AppNo(string CName,int year);
        void UpdateStudent(ApplicationForm appForm);
        //void SaveImages(ApplicationViewModel appForm);
        void SaveImages(string appNo,ApplicationViewModel appForm);
        ApplicationForm getStudent(string AppNo);
        List<ApplicationForm> GetAllStudents(DateTime? date,int page,int pageSize);
        int Count(DateTime ?date);
        bool DeleteStudent(string appno);
        string AppNo(string AadharNo);
    }

}