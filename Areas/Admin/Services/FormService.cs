using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Areas.Admin.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using WebApplication.Data;

namespace WebApplication.Areas.Admin.Services
{
    public class Admission : IAdmission
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        public Admission(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public void AddStudent(ApplicationForm appForm)
        {        
            appForm.ApplicationNo = AppNo(appForm.CoursePreferred, appForm.DateOfAdmission.Year);
            appForm.StatusId = 1;
            _context.ApplicationForms.Add(appForm);
            _context.SaveChanges();
        }
        public void SaveImages(string appNo, ApplicationViewModel appForm)
        {
            ApplicationForm Form = getStudent(appNo);
            if (appNo == null)
                appNo = AppNo(appForm.CoursePreferred, appForm.DateOfAdmission.Year);    

            var path = Path.Combine(_environment.WebRootPath, "images\\Photos");
            if (appForm.StudentPhoto != null)
            {
                Form.Photo = "StudentPhoto_" + appNo.ToString() + ".jpg";
                var StudentPhoto = Path.Combine(path, Form.Photo);
                if (File.Exists(StudentPhoto))
                {
                    File.Delete(StudentPhoto);
                }
                using (FileStream fs1 = new FileStream(StudentPhoto, FileMode.Create, FileAccess.Write))
                {
                    appForm.StudentPhoto.CopyTo(fs1);
                    fs1.Flush();
                }
            }
            if (appForm.StudentSign != null)
            {
                Form.StudentSignature = "StudentSign_" + appNo.ToString() + ".jpg";
                var StudentSign = Path.Combine(path, Form.StudentSignature);
                if (File.Exists(StudentSign))
                {
                    File.Delete(StudentSign);
                }
                var fs2 = new FileStream(StudentSign, FileMode.Create, FileAccess.Write);
                appForm.StudentSign.CopyToAsync(fs2);
            }
            if (appForm.ParentSign != null)
            {
                Form.ParentSignature = "ParentSign_" + appNo.ToString() + ".jpg";
                var ParentSign = Path.Combine(path, Form.ParentSignature);
                if (File.Exists(ParentSign))
                {
                    File.Delete(ParentSign);
                }
                var fs3 = new FileStream(ParentSign, FileMode.Create, FileAccess.Write);
                appForm.ParentSign.CopyToAsync(fs3);
            }
            if (appForm.ShortMemo != null)
            {
                Form.SscShortMemo = "SscShortMemo_" + appNo.ToString() + ".jpg";
                var SscShortMemo = Path.Combine(path, Form.SscShortMemo);
                if (File.Exists(SscShortMemo))
                {
                    File.Delete(SscShortMemo);
                }
                var fs4 = new FileStream(SscShortMemo, FileMode.Create, FileAccess.Write);
                appForm.ShortMemo.CopyToAsync(fs4);
            }
            if (appForm.LongMemo != null)
            {
                Form.SscLongMemo = "SscLongMemo_" + appNo.ToString() + ".jpg";
                var SscLongMemo = Path.Combine(path, Form.SscLongMemo);
                if (File.Exists(SscLongMemo))
                {
                    File.Delete(SscLongMemo);
                }
                var fs5 = new FileStream(SscLongMemo, FileMode.Create, FileAccess.Write);
                appForm.LongMemo.CopyToAsync(fs5);
            }
            if (appForm.Tc != null)
            {
                Form.SscTc = "SscTc_" + appNo.ToString() + ".jpg";
                var SscTc = Path.Combine(path, Form.SscTc);
                if (File.Exists(SscTc))
                {
                    File.Delete(SscTc);
                }
                var fs6 = new FileStream(SscTc, FileMode.Create, FileAccess.Write);
                appForm.Tc.CopyToAsync(fs6);
            }
            if (appForm.Bonafide != null)
            {
                Form.SscBonafide = "SscBonafide_" + appNo.ToString() + ".jpg";
                var SscBonafide = Path.Combine(path, Form.SscBonafide);
                if (File.Exists(SscBonafide))
                {
                    File.Delete(SscBonafide);
                }
                var fs7 = new FileStream(SscBonafide, FileMode.Create, FileAccess.Write);
                appForm.Bonafide.CopyToAsync(fs7);
            }
            if (appForm.Aadhar != null)
            {
                Form.AadharCopy = "AadharCopy_" + appNo.ToString() + ".jpg";
                var AadharCopy = Path.Combine(path, Form.AadharCopy);
                if (File.Exists(AadharCopy))
                {
                    File.Delete(AadharCopy);
                }
                var fs8 = new FileStream(AadharCopy, FileMode.Create, FileAccess.Write);
                appForm.Aadhar.CopyToAsync(fs8);
            }
            _context.SaveChanges();
        }
        public string AppNo()
        {
            return "";
        }
        public string AppNo(string CName,int year)
        {
            var rollno = year % 100;
            string appNo="";

            //pending
            if (CName.Contains("M.P.C"))
            {
                appNo = _context.ApplicationForms.OrderByDescending(m => m.ApplicationNo).Where(m=>m.CoursePreferred.Contains("M.P.C")).Select(m => m.ApplicationNo).FirstOrDefault();
                if(appNo==null)
                    appNo = (rollno.ToString()) + (rollno + 2) + 11000;
            }
            else if (CName.Contains("Bi.P.C"))
            {
                appNo = _context.ApplicationForms.OrderByDescending(m => m.ApplicationNo).Where(m => m.CoursePreferred.Contains("Bi.P.C")).Select(m => m.ApplicationNo).FirstOrDefault();
                if (appNo == null)
                    appNo = (rollno.ToString()) + (rollno + 2) + 12000;
            }
            else if (CName.Contains("M.E.C"))
            {
                appNo = _context.ApplicationForms.OrderByDescending(m => m.ApplicationNo).Where(m => m.CoursePreferred.Contains("M.E.C")).Select(m => m.ApplicationNo).FirstOrDefault();
                if (appNo == null)
                    appNo = (rollno.ToString()) + (rollno + 2) + 13000;
            }
            else if(CName.Contains("C.E.C"))
            {
                appNo = _context.ApplicationForms.OrderByDescending(m => m.ApplicationNo).Where(m => m.CoursePreferred.Contains("C.E.C")).Select(m => m.ApplicationNo).FirstOrDefault();
                if (appNo == null)
                    appNo = (rollno.ToString()) + (rollno + 2) + 14000;
            }
            appNo = (int.Parse(appNo) + 1).ToString();
            return appNo;
        }

        public void UpdateStudent(ApplicationForm appForm)
        {
            // _context.ApplicationForms.Attach(appForm).State=EntityState.Modified;
            // _context.ApplicationForms.Update(appForm);

            var appForm1 = _context.ApplicationForms.Where(s => s.ApplicationNo == appForm.ApplicationNo).FirstOrDefault();
            appForm1.StudentName = appForm.StudentName;
            appForm1.FatherName = appForm.FatherName;
            appForm1.MotherName = appForm.MotherName;
            appForm1.AadharNo = appForm.AadharNo;
            appForm1.SchoolEducation = appForm.SchoolEducation;
            appForm1.HallTicketNo = appForm.HallTicketNo;
            appForm1.GradePoint = appForm.GradePoint;
            appForm1.DOB = appForm.DOB;
            appForm1.SchoolName = appForm.SchoolName;
            appForm1.SchoolAddress = appForm.SchoolAddress;
            appForm1.CoursePreferred = appForm.CoursePreferred;
            appForm1.Medium = appForm.Medium;
            appForm1.Language = appForm.Language;
            appForm1.Religion = appForm.Religion;
            appForm1.Caste = appForm.Caste;
            appForm1.SubCaste = appForm.SubCaste;
            appForm1.MotherTongue = appForm.MotherTongue;
            appForm1.FirstYearFee = appForm.FirstYearFee;
            appForm1.SecondYearFee = appForm.SecondYearFee;
            appForm1.ParentOccupation = appForm.ParentOccupation;
            appForm1.StudentAddress = appForm.StudentAddress;
            appForm1.ContactNo = appForm.ContactNo;
            appForm1.MobileNo = appForm.MobileNo;
            appForm1.DateOfAdmission = appForm.DateOfAdmission;
            _context.SaveChanges();
        }
        /*
                public void UpdateStudent(ApplicationForm appForm)
                {
                    var appNo = _context.ApplicationForms.Where(s=>s.ApplicationNo==appForm.ApplicationNo).FirstOrDefault();

                    appForm.Photo= "StudentPhoto_"+appForm.ApplicationNo.ToString()+".jpg";
                    appForm.StudentSignature="StudentSign_"+appForm.ApplicationNo.ToString()+".jpg";
                    appForm.ParentSignature="ParentSign_"+appForm.ApplicationNo.ToString()+".jpg";

                    _context.ApplicationForms.Update(appForm); 
                    _context.SaveChanges();
                }
        */
        public ApplicationForm getStudent(string AppNo_AadharNo)
        {
            if(AppNo_AadharNo.Length==12)
            {
                return _context.ApplicationForms.Where(s => s.AadharNo == AppNo_AadharNo.ToString() && s.StatusId == 1).FirstOrDefault();
            }
            return _context.ApplicationForms.Where(s => s.ApplicationNo == AppNo_AadharNo.ToString() && s.StatusId == 1).FirstOrDefault();
        }
        public List<ApplicationForm> GetAllStudents(DateTime? date, int page, int pageSize)
        {
            if (date == null)
            {
                var Student = _context.ApplicationForms.Where(s => s.StatusId == 1).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Student;
            }
            var Students = _context.ApplicationForms.Where(s => s.DateOfAdmission == date ).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Students;
        }
        public int Count(DateTime? Date)
        {
            int count;
            if (Date != null)
                count= _context.ApplicationForms.Where(date => date.DateOfAdmission == Date).Count();
            else
                count =_context.ApplicationForms.Count();
            return count;
        }

        public bool DeleteStudent(string AppNo_AadharNo)
        {
            ApplicationForm appform;

            if (AppNo_AadharNo.Length == 12)
            {
                appform = _context.ApplicationForms.Where(app => app.AadharNo == AppNo_AadharNo).FirstOrDefault();
            }
            else
            {
                appform = _context.ApplicationForms.Where(app => app.ApplicationNo == AppNo_AadharNo).FirstOrDefault();
            }   
            if (appform != null)
            {

                appform.StatusId = 2;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public string AppNo(string AadharNo)
        {
            return _context.ApplicationForms.Where(a => a.AadharNo == AadharNo && a.StatusId == 1).Select(s=>s.ApplicationNo ).FirstOrDefault();
        }
    }
}