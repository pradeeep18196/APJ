using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Areas.Admin.Models
{
    public class ApplicationUpdateViewModel
    {
        public int ApplicationNo { get; set; }
        [Required]
        [StringLength(30)]
        public string StudentName { get; set; }
        [Required]
        [StringLength(30)]
        public string FatherName { get; set; }
        [Required]
        [StringLength(30)]
        public string MotherName { get; set; }
        [Required]
        [StringLength(12), MinLength(12), MaxLength(12)]
        public string AadharNo { get; set; }
        [Required]
        public string SchoolEducation { get; set; }
        [Required]
        public int HallTicketNo { get; set; }
        [Required]
        public double GradePoint { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string SchoolName { get; set; }
        [Required]
        public string SchoolAddress { get; set; }
        [Required]
        public string CoursePreferred { get; set; }
        [Required]
        public string Medium { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Religion { get; set; }
        [Required]
        public string Caste { get; set; }
        [Required]
        public string SubCaste { get; set; }
        [Required]
        public string MotherTongue { get; set; }
        [Required]
        public int FirstYearFee { get; set; }
        [Required]
        public int SecondYearFee { get; set; }
        public int BalanceFee { get; set; }
        [Required]
        public string ParentOccupation { get; set; }
        [Required]
        public string StudentAddress { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string MobileNo { set; get; }
        [Required]
        public string IdentificationMarks1 { get; set; }
        public string IdentificationMarks2 { get; set; }
        [Required]
        public DateTime DateOfAdmission { get; set; }
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
