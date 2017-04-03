using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication.Areas.Admin.Models;

namespace Abdul_kalam_clg.Migrations
{
    [DbContext(typeof(ApplicationDbContext1))]
    [Migration("20170323123642_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.Areas.Admin.Models.ApplicationForm", b =>
                {
                    b.Property<int>("ApplicationNo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AadharCopy");

                    b.Property<string>("AadharNo");

                    b.Property<int>("BalanceFee");

                    b.Property<string>("Caste");

                    b.Property<string>("ContactNo");

                    b.Property<string>("CoursePreferred");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DateOfAdmission")
                        .HasColumnType("Date");

                    b.Property<string>("FatherName");

                    b.Property<int>("FirstYearFee");

                    b.Property<double>("GradePoint");

                    b.Property<int>("HallTicketNo");

                    b.Property<string>("IdentificationMarks1");

                    b.Property<string>("IdentificationMarks2");

                    b.Property<string>("Language");

                    b.Property<string>("Medium");

                    b.Property<string>("MobileNo");

                    b.Property<string>("MotherName");

                    b.Property<string>("MotherTongue");

                    b.Property<string>("ParentOccupation");

                    b.Property<string>("ParentSignature");

                    b.Property<string>("Photo");

                    b.Property<string>("Religion");

                    b.Property<string>("SchoolAddress");

                    b.Property<string>("SchoolEducation");

                    b.Property<string>("SchoolName");

                    b.Property<int>("SecondYearFee");

                    b.Property<string>("SscBonafide");

                    b.Property<string>("SscLongMemo");

                    b.Property<string>("SscShortMemo");

                    b.Property<string>("SscTc");

                    b.Property<string>("StudentAddress");

                    b.Property<string>("StudentName");

                    b.Property<string>("StudentSignature");

                    b.Property<string>("SubCaste");

                    b.HasKey("ApplicationNo");

                    b.ToTable("ApplicationForms");
                });
        }
    }
}
