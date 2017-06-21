using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.Models;
using WebApplication.Areas.Admin.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdmissionController : Controller
    {
        private IAdmission _adm;
        private readonly IMapper _mapper;
        //AutoMapperProfileConfiguration
        public AdmissionController(IAdmission adm, IMapper mapper)
        {
            _adm = adm;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [NonAction]
        public void LoadDropDownsData()
        {
            ViewBag.SchoolEducation = SelectItems.SchoolEducation();
            ViewBag.Courses = SelectItems.Courses();
            ViewBag.Languages = SelectItems.Languages();
            ViewBag.castes = SelectItems.Castes();
        }
        [HttpGet]
        public IActionResult AddStudent()
        {
            LoadDropDownsData();
            ApplicationViewModel avm = new ApplicationViewModel();
            avm.ApplicationNo = "";
            avm.DateOfAdmission = DateTime.Now;
            avm.DOB = DateTime.Now;
            return View(avm);
        }

        [HttpPost]
        public IActionResult AddStudent(ApplicationViewModel frm)
        {
            if (ModelState.IsValid)
            {
                var appform = _mapper.Map<ApplicationForm>(frm);

                var appNo = _adm.AppNo(frm.StudentName, frm.FatherName, frm.MobileNo);
                if (appNo != null)
                {
                    ViewBag.Message = "THIS CANDIDATE ALREADY EXIXTS with ApplicationNo : " + appNo;
                    return View("DuplicateRecord");
                }
                else
                {
                    var AppNo = _adm.AddStudent(appform);
                    _adm.SaveImages(AppNo, frm);
                    appform = _adm.getStudent(AppNo);
                    ViewBag.msg = "Application is Sucessfully registered with " + AppNo;
                    return View("Conform", appform);
                }
            }
            LoadDropDownsData();
            return View("AddStudent", new { });
        }
        public IActionResult PrintAdmission(string appNo, string Option)
        {
            var appform = _adm.getStudent(appNo);
            ViewBag.option = Option;
            return View(appform);
        }

        [HttpGet]
        public IActionResult EditStudent()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateStudent(string ApplicationNo)
        {
            LoadDropDownsData();
            ViewBag.AppNo = ApplicationNo;
            var appform = _adm.getStudent(ApplicationNo);
            if (appform != null)
            {
                var AppViewForm = _mapper.Map<ApplicationViewModel>(appform);
                return View(AppViewForm);
            }
            ViewBag.Message = "No Candidate Exists With This ApplicationNo:" + ApplicationNo;
            return View("_PopUp");
        }

        [HttpPost]
        public IActionResult UpdateStudent(ApplicationViewModel frm)                
        {
            if (ModelState.IsValid)
            {
                var appform = _mapper.Map<ApplicationForm>(frm);
                _adm.UpdateStudent(appform);
                var appform1 = _mapper.Map<ApplicationViewModel>(frm);
                _adm.SaveImages(frm.ApplicationNo, appform1);
                ViewBag.Message = "Your Application Was Sucessfully Updated";
                return View("_PopUp");
                //return RedirectToAction("EditStudent");
            }
            return View(frm);
        }

        //public PartialViewResult _EditStudent(ApplicationViewModel appform)
        //{
        //    LoadDropDownsData();
        //    return PartialView(appform);
        //}
        /*
        public IActionResult ShowAllStudents(string Group,string studentName, DateTime? date, int? page = 1,int? pageSize=5)
        {
            Pager pager;
            List<ApplicationForm> SList;
            if (date == null)
            {
                pager = new Pager(_adm.Count(null), page.Value, pageSize.Value);
                SList = _adm.GetAllStudents(null, page.Value, pageSize.Value);
            }
            else
            {
                date = new DateTime(date.Value.Year, date.Value.Day, date.Value.Month);
                var totalItems = _adm.Count(date);
                pager = new Pager(totalItems, page.Value, pageSize.Value);
                SList = _adm.GetAllStudents(date, page.Value, pageSize.Value);
                string NewDate = "";
                NewDate = NewDate + date.Value.Day + '-' + date.Value.Month + '-' + date.Value.Year;
                ViewBag.SelectedDate = NewDate;
            }
            ViewBag.Pager = pager;
            ViewBag.Group = Group;
            ViewBag.studentName = studentName;
            ViewBag.pageSize = pageSize;
            return View(SList);
        }*/

        public IActionResult ShowAllStudents(string Group, string studentName, DateTime? date, int? page = 1, int? pageSize = 5)
        {
            Pager pager;
            List<ApplicationForm> SList;
            if (date == null)
            {
                SList = _adm.GetAllStudents(null, page.Value, pageSize.Value, studentName, Group);
                pager = new Pager(_adm.Count(studentName, Group, null), page.Value, pageSize.Value);
            }
            else
            {
                //date = new DateTime(date.Value.Year, date.Value.Day, date.Value.Month);
                SList = _adm.GetAllStudents(date, page.Value, pageSize.Value, studentName, Group);
                var totalItems = _adm.Count(studentName, Group, date);
                pager = new Pager(totalItems, page.Value, pageSize.Value);
                string NewDate = "";
                NewDate = NewDate + date.Value.Day + '-' + date.Value.Month + '-' + date.Value.Year;
                ViewBag.SelectedDate = NewDate;
            }
            ViewBag.Pager = pager;
            ViewBag.Group = Group;
            ViewBag.studentName = studentName;
            ViewBag.pageSize = pageSize;
            return View(SList);
        }


        public IActionResult DeleteStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete_Student(string appno, string description)
        {
            if (_adm.DeleteStudent(appno, description))
            {
                ViewBag.Message = "Application is Sucessfully Deleted";
            }
            else
            {
                ViewBag.Message = "This Application Dose not Exists";
            }
            return View();
        }
    }
}