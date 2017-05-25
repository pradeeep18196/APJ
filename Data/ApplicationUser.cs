using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplication.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
