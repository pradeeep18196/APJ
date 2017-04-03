using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WebApplication.Areas.Admin.Services
{
    public class Admission : IAdmission
    {
        private readonly ApplicationDbContext1 _context;
        private IHostingEnvironment _environment;
        public Admission(ApplicationDbContext1 context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public void AddStudent(ApplicationForm appForm)
        {
            var appNo = AppNo();

            appForm.Photo = "StudentPhoto_" + appNo.ToString() + ".jpg";
            appForm.StudentSignature = "StudentSign_" + appNo.ToString() + ".jpg";
            appForm.ParentSignature = "ParentSign_" + appNo.ToString() + ".jpg";
            appForm.SscShortMemo = "SscShortMemo_" + appNo.ToString() + ".jpg";
            appForm.SscLongMemo = "SscLongMemo_" + appNo.ToString() + ".jpg";
            appForm.SscTc = "SscTc_" + appNo.ToString() + ".jpg";
            appForm.SscBonafide = "SscBonafide_" + appNo.ToString() + ".jpg";
            appForm.AadharCopy = "AadharCopy_" + appNo.ToString() + ".jpg";
            _context.ApplicationForms.Add(appForm);
            _context.SaveChanges();
        }
        /*
        public void SaveImages(ApplicationViewModel appForm)
        {
            var appNo = AppNo();
            var path = System.IO.Path.Combine(_environment.WebRootPath, "images\\Photos");
            var StudentPhoto = System.IO.Path.Combine(path, "StudentPhoto_" + appNo.ToString() + ".jpg");
            var StudentSign = System.IO.Path.Combine(path, "StudentSign_" + appNo.ToString() + ".jpg");
            var ParentSign = System.IO.Path.Combine(path, "ParentSign_" + appNo.ToString() + ".jpg");
            var SscShortMemo = System.IO.Path.Combine(path, "SscShortMemo_" + appNo.ToString() + ".jpg");
            var SscLongMemo = System.IO.Path.Combine(path, "SscLongMemo_" + appNo.ToString() + ".jpg");
            var SscTc = System.IO.Path.Combine(path, "SscTc_" + appNo.ToString() + ".jpg");
            var SscBonafide = System.IO.Path.Combine(path, "SscBonafide_" + appNo.ToString() + ".jpg");
            var AadharCopy = System.IO.Path.Combine(path, "AadharCopy_" + appNo.ToString() + ".jpg");

            var fs1 = new System.IO.FileStream(StudentPhoto, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs2 = new System.IO.FileStream(StudentSign, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs3 = new System.IO.FileStream(ParentSign, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs4 = new System.IO.FileStream(SscShortMemo, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs5 = new System.IO.FileStream(SscLongMemo, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs6 = new System.IO.FileStream(SscTc, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs7 = new System.IO.FileStream(SscBonafide, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs8 = new System.IO.FileStream(AadharCopy, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            appForm.StudentPhoto.CopyToAsync(fs1);
            appForm.StudentSign.CopyToAsync(fs2);
            appForm.ParentSign.CopyToAsync(fs3);
            appForm.ShortMemo.CopyToAsync(fs4);
            appForm.LongMemo.CopyToAsync(fs5);
            appForm.Tc.CopyToAsync(fs6);
            appForm.Bonafide.CopyToAsync(fs7);
            appForm.Aadhar.CopyToAsync(fs8);
        }
        */
        public void SaveImages(int ?appNo, ApplicationViewModel appForm)
        {
            if(appNo==null)
                appNo = AppNo();
            var path = System.IO.Path.Combine(_environment.WebRootPath, "images\\Photos");
            var StudentPhoto = System.IO.Path.Combine(path, "StudentPhoto_" + appNo.ToString() + ".jpg");
            var StudentSign = System.IO.Path.Combine(path, "StudentSign_" + appNo.ToString() + ".jpg");
            var ParentSign = System.IO.Path.Combine(path, "ParentSign_" + appNo.ToString() + ".jpg");
            var SscShortMemo = System.IO.Path.Combine(path, "ShortMemo_" + appNo.ToString() + ".jpg");
            var SscLongMemo = System.IO.Path.Combine(path, "SscLongMemo_" + appNo.ToString() + ".jpg");
            var SscTc = System.IO.Path.Combine(path, "SscTc_" + appNo.ToString() + ".jpg");
            var SscBonafide = System.IO.Path.Combine(path, "SscBonafide_" + appNo.ToString() + ".jpg");
            var AadharCopy = System.IO.Path.Combine(path, "AadharCopy_" + appNo.ToString() + ".jpg");

            var fs1 = new System.IO.FileStream(StudentPhoto, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs2 = new System.IO.FileStream(StudentSign, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs3 = new System.IO.FileStream(ParentSign, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs4 = new System.IO.FileStream(SscShortMemo, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs5 = new System.IO.FileStream(SscLongMemo, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs6 = new System.IO.FileStream(SscTc, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs7 = new System.IO.FileStream(SscBonafide, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            var fs8 = new System.IO.FileStream(AadharCopy, System.IO.FileMode.Create, System.IO.FileAccess.Write);

            appForm.StudentPhoto.CopyToAsync(fs1);
            appForm.StudentSign.CopyToAsync(fs2);
            appForm.ParentSign.CopyToAsync(fs3);
            appForm.ShortMemo.CopyToAsync(fs4);
            appForm.LongMemo.CopyToAsync(fs5);
            appForm.Tc.CopyToAsync(fs6);
            appForm.Bonafide.CopyToAsync(fs7);
            appForm.Aadhar.CopyToAsync(fs8);
        }

        public int AppNo()
        {
            var appNo = _context.ApplicationForms.OrderByDescending(m => m.ApplicationNo).Select(m => m.ApplicationNo).FirstOrDefault();
            return ++appNo;
        }

        public void UpdateStudent(ApplicationForm appForm)
        {
            appForm.Photo = "StudentPhoto_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.StudentSignature = "StudentSign_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.ParentSignature = "ParentSign_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.ParentSignature = "ParentSign_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.SscShortMemo = "SscShortMemo_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.SscLongMemo = "SscLongMemo_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.SscTc = "SscTc_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.SscBonafide = "SscBonafide_" + appForm.ApplicationNo.ToString() + ".jpg";
            appForm.AadharCopy = "AadharCopy_" + appForm.ApplicationNo.ToString() + ".jpg";

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
            appForm1.BalanceFee = appForm.BalanceFee;
            appForm1.ParentOccupation = appForm.ParentOccupation;
            appForm1.StudentAddress = appForm.StudentAddress;
            appForm1.ContactNo = appForm.ContactNo;
            appForm1.MobileNo = appForm.MobileNo;
            appForm1.DateOfAdmission = appForm.DateOfAdmission;
            appForm1.Photo = appForm.Photo;
            appForm1.StudentSignature = appForm.StudentSignature;
            appForm1.ParentSignature = appForm.ParentSignature;

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
        public ApplicationForm getStudent(int AppNo)
        {
            return _context.ApplicationForms.Where(s => s.ApplicationNo == AppNo).FirstOrDefault();
        }
        public List<ApplicationForm> GetAllStudents(DateTime? date, int page, int pageSize)
        {
            if (date == null)
            {
                var Student = _context.ApplicationForms.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return Student;
            }
            var Students = _context.ApplicationForms.Where(s => s.DateOfAdmission == date).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Students;
        }
        public int Count(DateTime ?Date)
        {
            if(Date!=null)
                return _context.ApplicationForms.Where(date=>date.DateOfAdmission==Date).Count();
            return _context.ApplicationForms.Count();
        }
    }
}