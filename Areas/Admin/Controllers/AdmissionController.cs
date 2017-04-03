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

        [HttpGet]
        public IActionResult AddStudent()
        {
            ViewBags();
            ApplicationViewModel avm = new ApplicationViewModel();
            avm.ApplicationNo= _adm.AppNo();
            return View(avm);
        }

        [NonAction]
        public void ViewBags()
        {
            ViewBag.SchoolEducation = SelectItems.SchoolEducation();
            ViewBag.Courses = SelectItems.Courses();
            ViewBag.Languages = SelectItems.Languages();
            ViewBag.castes = SelectItems.Castes();
        }

        [HttpPost]
        public IActionResult AddStudent(ApplicationViewModel frm)
        {
            if (ModelState.IsValid)
            {
                var appform = _mapper.Map<ApplicationForm>(frm);
                _adm.AddStudent(appform);
                _adm.SaveImages(null,frm);
                return RedirectToAction("Index");
            }
            ViewBags();
            ViewBag.AppNo = _adm.AppNo();
            return View("AddStudent", frm);
        }

        [HttpGet]
        public IActionResult EditStudent()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateStudent(int ApplicationNo)
        {
            ViewBags();
            ViewBag.AppNo = ApplicationNo;
            var appform = _adm.getStudent(ApplicationNo);
            var AppViewForm = _mapper.Map<ApplicationViewModel>(appform);
            if (AppViewForm != null)
            {
                return View(AppViewForm);
            }
            return RedirectToAction("EditStudent");
        }

        [HttpPost]
        public IActionResult UpdateStudent(ApplicationViewModel frm)
        {
            if (ModelState.IsValid)
            {
                var appform = _mapper.Map<ApplicationForm>(frm);
                _adm.UpdateStudent(appform);
                _adm.SaveImages(frm.ApplicationNo, frm);
                return RedirectToAction("EditStudent");
            }
            return View(frm);
        }

        public PartialViewResult _EditStudent(ApplicationViewModel appform)
        {
            ViewBags();
            return PartialView(appform);
        }
        public IActionResult ShowAllStudents(DateTime? date,int? page=1)
        {
            var pageSize=5;
            Pager pager;
            List<ApplicationForm> sa;
            if (date==null)
            {
                pager = new Pager(_adm.Count(null), page.Value, pageSize);
                sa = _adm.GetAllStudents(null, page.Value, pageSize);
            }
            else
            {
                pager = new Pager(_adm.Count(date), page.Value, pageSize);
                sa = _adm.GetAllStudents(date, page.Value, pageSize);
            }
            ViewBag.Pager = pager;
            
            return View(sa);
        }
    }
}