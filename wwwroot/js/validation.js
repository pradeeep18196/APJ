$(document).ready(function () {

    $("#StudentForm").validate({
        rules: {
            StudentName: "required",
            FatherName: "required",
            MotherName: "required",
            AadharNo: {
                required: true,
                minlength: 16,
                maxlength: 16
            },
            SchoolEducation: "required",
            HallTicketNo: "required",
            GradePoint: "required",
            DOB: {
                required: true,
                date: true
            },
            SchoolName: "required",
            SchoolAddress: "required",
            CoursePreferred: "required",
            Medium: "required",
            Language: "required",
            Religion: "required",
            Caste: "required",
            SubCaste: "required",
            MotherTongue: "required",
            TotalFee: "required",
            ParentOccupation: "required",
            StudentAddress: "required",
            ContactNo: {
                required: true,
                minlength: 10,
                maxlength: 13
            },
            IdentificationMarks: "required",
            DateOfAdmission: {
                required: true,
                date: true
            }
        },
        messages: {
            StudentName: "Please Enter Student Name",
            FatherName: "Please Enter Father Name",
            MotherName: "Please Enter Mother Name",
            AadharNo: {
                required: "Please provide a AadharNo",
                minlength: "enter 16 characters",
                maxlength: "enter correct  AadharNo"
            },
            SchoolEducation:"Please Enter Education type",
            HallTicketNo: "Please Enter HallTicketNo",
            GradePoint: "Please Enter GradePoint",
            DOB: {
                required: "Please provide a Date of Birth",
            },
            SchoolName: "Please Enter SchoolName",
            SchoolAddress: "Please Enter SchoolAddress",
            CoursePreferred: "Please Enter CoursePreferred",
            Medium: "Please Enter Medium",
            Language: "Please Enter Language",
            Religion: "Please Enter Religion",
            Caste: "Please Enter Caste",
            SubCaste: "Please Enter SubCaste",
            MotherTongue: "Please Enter MotherTongue",
            TotalFee: "Please Enter TotalFee",
            ParentOccupation: "Please Enter ParentOccupation",
            StudentAddress: "Please Enter StudentAddress",
            ContactNo: {
                required: "Please Enter SchoolName",
                minlength: "ContactNo at least have 10 characters",
                maxlength:  "ContactNo atmost have 13 characters"
            },
            IdentificationMarks: "Please Enter IdentificationMarks",
            DateOfAdmission: {
                required:"Please Enter DateOfAdmission",
            }   
        }
    });
});