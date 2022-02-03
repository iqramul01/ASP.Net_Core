using _1263087.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using _1263087.Models.ViewModels;

namespace _1263087.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorQualification> DoctorQualifications { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
