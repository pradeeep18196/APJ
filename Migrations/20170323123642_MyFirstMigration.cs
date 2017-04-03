using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Abdul_kalam_clg.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    ApplicationNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AadharCopy = table.Column<string>(nullable: true),
                    AadharNo = table.Column<string>(nullable: true),
                    BalanceFee = table.Column<int>(nullable: false),
                    Caste = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    CoursePreferred = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "Date", nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    FirstYearFee = table.Column<int>(nullable: false),
                    GradePoint = table.Column<double>(nullable: false),
                    HallTicketNo = table.Column<int>(nullable: false),
                    IdentificationMarks1 = table.Column<string>(nullable: true),
                    IdentificationMarks2 = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Medium = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    MotherTongue = table.Column<string>(nullable: true),
                    ParentOccupation = table.Column<string>(nullable: true),
                    ParentSignature = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    SchoolAddress = table.Column<string>(nullable: true),
                    SchoolEducation = table.Column<string>(nullable: true),
                    SchoolName = table.Column<string>(nullable: true),
                    SecondYearFee = table.Column<int>(nullable: false),
                    SscBonafide = table.Column<string>(nullable: true),
                    SscLongMemo = table.Column<string>(nullable: true),
                    SscShortMemo = table.Column<string>(nullable: true),
                    SscTc = table.Column<string>(nullable: true),
                    StudentAddress = table.Column<string>(nullable: true),
                    StudentName = table.Column<string>(nullable: true),
                    StudentSignature = table.Column<string>(nullable: true),
                    SubCaste = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.ApplicationNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationForms");
        }
    }
}
