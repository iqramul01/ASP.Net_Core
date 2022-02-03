using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1263087.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        public string CompanyName { get; set; }
        public string Designation { get; set; }        
        public int StaffID { get; set; }
        public virtual Staff Staff { get; private set; }
    }
}
