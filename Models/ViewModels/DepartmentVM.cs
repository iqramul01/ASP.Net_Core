using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _1263087.Models.ViewModels
{
    public class DepartmentVM
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "Department Name is Required!")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = " Seat")]
        [Range(10, 999, ErrorMessage = "Number of Seat is Not Valid")]
        public int AvailableSeate { get; set; }
        [Display(Name = " Status")]
        public bool IsActive { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }

    }
}
