using Microsoft.EntityFrameworkCore;

namespace  WebApplication.Areas.Admin.Models
{
    public partial class ApplicationDbContext1:DbContext
    {
        public ApplicationDbContext1(DbContextOptions<ApplicationDbContext1> options) :base(options)
        {

        }

        public DbSet<ApplicationForm> ApplicationForms{get;set;}
    }
}