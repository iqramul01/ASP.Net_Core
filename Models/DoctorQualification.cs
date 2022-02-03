using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _1263087.Models
{
    public class DoctorQualification
    {

        [Key]
        public int QualificationID { get; set; }
        public string Degree { get; set;}
        public DateTime CompletionDate { get; set; }
        public int Duration { get; set; }
        public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
