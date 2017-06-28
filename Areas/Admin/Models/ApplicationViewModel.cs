using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebApplication.Areas.Admin.Models
{
    public class ApplicationViewModel
    {
        public string ApplicationNo { get; set; }
        [Required(ErrorMessage = "The Surname field  is required")]
        public string Surname { get; set; }
        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(30)]
        public string FatherName { get; set; }
        [Required]
        public string CoursePreferred { get; set; }
        [Required]
        public string MotherName { get; set; }
        //[StringLength(12),MinLength(12),MaxLength(12)]
        public string AadharNo { get; set; }
                    
        public string SchoolEducation { get; set; }
                    
        public int HallTicketNo { get; set; }
                    
        public double GradePoint { get; set; }
        [Required]
        public DateTime DOB { get; set; }
                    
        public string SchoolName { get; set; }
                    
        public string SchoolAddress { get; set; }
                    
        public string Medium { get; set; }
                    
        public string Language { get; set; }
                    
        public string Religion { get; set; }
                    
        public string Caste { get; set; }
                    
        public string SubCaste { get; set; }
                    
        public string MotherTongue { get; set; }
                    
        public int FirstYearFee { get; set; }
                    
        public int SecondYearFee { get; set; }
                    
        public string ParentOccupation { get; set; }
                    
        public string StudentAddress { get; set; }
        public string ContactNo { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Mobile number must be numeric")]
        [MinLength(10), MaxLength(10)]
        public string MobileNo { set; get; }
                    
        public string IdentificationMarks1 { get; set; }
        public string IdentificationMarks2 { get; set; }
                    
        public DateTime DateOfAdmission { get; set; }
                    
        //[StringLength(4),MinLength(4),MaxLength(4)]
        public string SscPassedYear { get; set; }
        public string Photo { get; set; }
        public string StudentSignature { get; set; }
        public string ParentSignature { get; set; }
        public string SscShortMemo { set; get; }
        public string SscLongMemo { set; get; }
        public string SscTc { set; get; }
        public string SscBonafide { set; get; }
        public string AadharCopy { set; get; }
        public IFormFile StudentPhoto { get; set; }
        public IFormFile StudentSign { get; set; }
        public IFormFile ParentSign { get; set; }
        public IFormFile ShortMemo { set; get; }
        public IFormFile LongMemo { set; get; }
        public IFormFile Tc { set; get; }
        public IFormFile Bonafide { set; get; }
        public IFormFile Aadhar { set; get; }
    }
}