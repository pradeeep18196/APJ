using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using WebApplication.Areas.Admin.Services;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;

namespace WebApplication.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdmissionController : Controller
    {
        private IAdmission _adm;
        private readonly IMapper _mapper;

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
                if (_adm.AppNo(frm.AadharNo) == null)
                {
                    _adm.AddStudent(appform);
                    _adm.SaveImages(_adm.AppNo(), frm);
                    return RedirectToAction("Conform", frm);   //new { AadharNo = frm.AadharNo });
                }
                else
                {
                    /////redirect to action which shows an error called THIS CANDIDAE ALREADY EXIXTS with ApplicationNo
                    //////pending
                }
            }
            LoadDropDownsData();
            //ViewBag.AppNo = _adm.AppNo();
            return View("AddStudent", frm); 
        }

        public IActionResult Conform(ApplicationViewModel AppForm)
        {

            ViewBag.AppNo = _adm.AppNo(AppForm.AadharNo);
            return View(AppForm);
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
                pager = new Pager(_adm.Count(date), page.Value, pageSize);
                SList = _adm.GetAllStudents(date, page.Value, pageSize);
                string NewDate = "";
                NewDate = NewDate + date.Value.Day + '-' + date.Value.Month + '-' + date.Value.Year;
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
        public IActionResult DeleteStudent(int appno)
        {

            return View();
        }
    }
}