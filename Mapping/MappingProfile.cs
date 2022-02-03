
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _1263087.Models;
using _1263087.Models.ViewModels;
using AutoMapper;

namespace _1263087.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();

            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
        }

    }
}
