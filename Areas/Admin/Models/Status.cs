using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.Models
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusDescription { get; set; }
    }
}
