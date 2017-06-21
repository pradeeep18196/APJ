using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplication.Areas.Admin.Models
{
    public static class SelectItems
    {
        public static List<SelectListItem> SchoolEducation()
        {
            List<SelectListItem> SchoolEducation = new List<SelectListItem>();
            SchoolEducation.Add(new SelectListItem
            {
                Text = "SSC Regular",
                Value = "SSC Regular"
            });
            SchoolEducation.Add(new SelectListItem
            {
                Text = "CBSE",
                Value = "CBSE",

            });
            SchoolEducation.Add(new SelectListItem
            {
                Text = "ICSE",
                Value = "ICSE"
            });
            SchoolEducation.Add(new SelectListItem
            {
                Text = "SSC Supplementary",
                Value = "SSC Supplementary"
            });
            SchoolEducation.Add(new SelectListItem
            {
                Text = "Open School",
                Value = "Open School"
            });

            return SchoolEducation;
        }
        public static List<SelectListItem> Courses()
        {
            List<SelectListItem> CoursesList = new List<SelectListItem>();
            CoursesList.Add(new SelectListItem
            {
                Text = "M.P.C REGULAR",
                Value = "M.P.C REGULAR"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "M.P.C + AIEEE",
                Value = "M.P.C + AIEEE"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "M.P.C + EAMCET",
                Value = "M.P.C + EAMCET"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "Bi.P.C REGULAR",
                Value = "Bi.P.C REGULAR"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "Bi.P.C + NEET",
                Value = "Bi.P.C + NEET"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "M.E.C REGULAR",
                Value = "M.E.C REGULAR"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "M.E.C + CA/CPT",
                Value = "M.E.C + CA/CPT"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "C.E.C REGULAR",
                Value = "C.E.C REGULAR"
            });
            CoursesList.Add(new SelectListItem
            {
                Text = "C.E.C + CA/CPT",
                Value = "C.E.C + CA/CPT"
            });
            return CoursesList;
        }
        public static List<SelectListItem> Languages()
        {
            List<SelectListItem> LanguagesList = new List<SelectListItem>();
            LanguagesList.Add(new SelectListItem
            {
                Text = "Sanskrit",
                Value = "Sanskrit"
            });
            LanguagesList.Add(new SelectListItem
            {
                Text = "Telugu",
                Value = "Telugu",
            });
            LanguagesList.Add(new SelectListItem
            {
                Text = "Hindi",
                Value = "Hindi"
            });
            LanguagesList.Add(new SelectListItem
            {
                Text = "Arabic",
                Value = "Arabic",
            });
            return LanguagesList;
        }
        public static List<SelectListItem> Castes()
        {
            
            List<SelectListItem> castesList = new List<SelectListItem>();
            castesList.Add(new SelectListItem
            {
                Text = "OC",
                Value = "OC"
            });
            castesList.Add(new SelectListItem
            {
                Text = "BC-A",
                Value = "BC-A",

            });
            castesList.Add(new SelectListItem
            {
                Text = "BC-B",
                Value = "BC-B"
            });
            castesList.Add(new SelectListItem
            {
                Text = "BC-C",
                Value = "BC-C",

            });
            castesList.Add(new SelectListItem
            {
                Text = "BC-D",
                Value = "BC-D"
            });
            castesList.Add(new SelectListItem
            {
                Text = "BC-E",
                Value = "BC-E"
            });
            castesList.Add(new SelectListItem
            {
                Text = "SC",
                Value = "SC",

            });
            castesList.Add(new SelectListItem
            {
                Text = "ST",
                Value = "ST"
            });
            return castesList;
        }
    }
}