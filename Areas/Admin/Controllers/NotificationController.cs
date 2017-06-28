using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using WebApplication.Areas.Admin.Services;
using System.Net;
using System.IO;

namespace WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private INotificationService _notification;
        private IAdmission _adm;
        public NotificationController(INotificationService notification, IAdmission adm)
        {
            _notification = notification;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendNotification(int selection, string AppNo_AadharNo, string description, string[] groups)
        {
            //if (_notification.IsExists(AppNo_AadharNo))
            //{
                if (selection == 1)
                {
                    _notification.SendToIndividualStudent(AppNo_AadharNo, description);
                }
                else if (selection == 2)
                {
                    _notification.SendByGroup(groups, description);
                }
                else if (selection == 3)
                {
                    _notification.SendToAllStudents(description);
                }
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }
    }        
}
