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
            avm.ApplicationNo = "";          //_adm.AppNo();
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
                var Appno = _adm.AppNo(frm.AadharNo);
                if (Appno == null)
                {
                    _adm.AddStudent(appform);
                    _adm.SaveImages(_adm.AppNo(), frm);
                    ViewBag.AppNo = frm.ApplicationNo;
                    return View("Conform", frm);   
                }
                else
                {                    
                    return RedirectToAction("DuplicateRecord", new { appNo = Appno.ToString() });
                }
            }
            LoadDropDownsData();
            return View("AddStudent",new { }); 
        }
        
        //public IActionResult Conform(ApplicationViewModel AppForm)
        //{
        //    //var AppForm=(ApplicationViewModel)TempData["AppForm"];
        //    ViewBag.AppNo = _adm.AppNo(AppForm.AadharNo);
        //    return View(AppForm);
        //}
        
        public IActionResult DuplicateRecord(string appNo)
        {
            ViewBag.Message = "THIS CANDIDAE ALREADY EXIXTS with ApplicationNo : "+appNo;
            return View();
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
            var AppViewForm = _mapper.Map<ApplicationViewModel>(appform);           //
            if (AppViewForm != null)
            {
                return View(AppViewForm);
            }
            return RedirectToAction("EditStudent");
        }

        [HttpPost]
        public IActionResult UpdateStudent(ApplicationViewModel frm)                //
        {
            if (ModelState.IsValid)
            {
                var appform = _mapper.Map<ApplicationForm>(frm);
                _adm.UpdateStudent(appform);
                var appform1 = _mapper.Map<ApplicationViewModel>(frm);
                _adm.SaveImages(frm.ApplicationNo, appform1);
                return RedirectToAction("EditStudent");
            }
            return View(frm);
        }

        public PartialViewResult _EditStudent(ApplicationViewModel appform)
        {
            LoadDropDownsData();
            return PartialView(appform);
        }
        public IActionResult ShowAllStudents(DateTime? date, int? page = 1)
        {
            var pageSize = 3;
            Pager pager;
            List<ApplicationForm> SList;
            if (date == null)
            {
                pager = new Pager(_adm.Count(null), page.Value, pageSize);
                SList = _adm.GetAllStudents(null, page.Value, pageSize);
             
            }
            else
            {
                var totalItems= _adm.Count(date);
                pager = new Pager(totalItems, page.Value, pageSize);
                SList = _adm.GetAllStudents(date, page.Value, pageSize);
                string NewDate = "";
                NewDate = NewDate + date.Value.Month + '-' + date.Value.Day + '-' + date.Value.Year;
                ViewBag.SelectedDate = NewDate;
            }
            ViewBag.Pager = pager;
            return View(SList);
        }

        public IActionResult DeleteStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete_Student(string appno)
        {
            if(_adm.DeleteStudent(appno))
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