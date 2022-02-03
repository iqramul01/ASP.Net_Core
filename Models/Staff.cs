using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _1263087.Models
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
        [Required(ErrorMessage = "Staff is Required!")]
        [StringLength(25, ErrorMessage = "Name must be less than 25 character")]
        public string StaffName { get; set; }
        [Required(ErrorMessage = "Contact Address is Required!")]
        public string ContactAddress { get; set; }
        [Required(ErrorMessage = "Email is Required!")]
        public string EmailAddress { get; set; }

        public string ConfirmEmail { get; set; }

        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        public string Picture { get; set; }
        [NotMapped]
        public IFormFile UploadImage { get; set; }
        public bool IsActive { get; set; }
        
        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}

