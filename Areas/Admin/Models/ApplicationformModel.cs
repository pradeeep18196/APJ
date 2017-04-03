using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Areas.Admin.Models
{
    public class ApplicationForm
    {
   
        [Key]
        public int ApplicationNo{get;set;}
        public string StudentName{get; set;}
        public string FatherName{get; set;}
        public string MotherName{get;set;}
        public string AadharNo{get;set;}
        public string SchoolEducation{get; set;}
        public int HallTicketNo{get; set;}
        public double GradePoint{get; set;}
        [Column(TypeName="Date")]
        public DateTime DOB{get; set;}
        public string SchoolName{get; set;}
        public string SchoolAddress{get; set;}
        public string CoursePreferred{get; set;}
        public string Medium{get; set;}
        public string Language{get; set;}
        public string Religion{get;set;}
        public string Caste{get; set;}
        public string SubCaste{get; set;}
        public string MotherTongue{get; set;}
        public int FirstYearFee{get; set;}
        public int SecondYearFee { get; set; }
        public int BalanceFee{get;set;}
        public string ParentOccupation{get; set;}
        public string StudentAddress{get; set;}
        public string ContactNo{get; set;}
        public string MobileNo { set; get; }
        public string IdentificationMarks1{get; set;}
        public string IdentificationMarks2 { get; set; }

        [Column(TypeName="Date")]
        public DateTime DateOfAdmission{get; set;}
        public string Photo{get;set;}
        public string StudentSignature{get; set;}
        public string ParentSignature{get; set;}
        public string SscShortMemo { set; get; }
        public string SscLongMemo { set; get; }
        public string SscTc { set; get; }
        public string SscBonafide { set; get; }
        public string AadharCopy { set; get; }
    }  
}