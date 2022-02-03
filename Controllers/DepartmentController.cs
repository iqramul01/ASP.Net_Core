
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using _1263087.Data;
using _1263087.Models;
using _1263087.Models.ViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _1263087.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public DepartmentController(IMapper mapper, ApplicationDbContext context)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurentFilter"] = searchString;

            var department = from t in _context.Departments
                             select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                department = department.Where(t => t.DepartmentName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    department = department.OrderByDescending(t => t.DepartmentName);
                    break;

                default:
                    department = department.OrderBy(t => t.DepartmentName);
                    break;
            }

            int pageSize = 3;

            return View(await PaginatedList<Department>.CreateAsync(department.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentVM departmentVM)
        {
            var department = _mapper.Map<DepartmentVM, Department>(departmentVM);
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var singleDepartment = await _context.Departments.FindAsync(id);
            var department = _mapper.Map<Department, DepartmentVM>(singleDepartment);
            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DepartmentVM departmentVM, int id)
        {
            var singleDepartment = await _context.Departments.FindAsync(id);
            //_mapper.Map<TraineeVM, Trainee>(traineeVM, singleTrainee);
            _mapper.Map(departmentVM, singleDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var singleDepartment = await _context.Departments.FindAsync(id);
            var department = _mapper.Map<Department, DepartmentVM>(singleDepartment);
            return View(department);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var singleDepartment = await _context.Departments.FindAsync(id);
            _context.Remove(singleDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var singleDepartment = await _context.Departments.FindAsync(id);
            var department = _mapper.Map<Department, DepartmentVM>(singleDepartment);
            return View(department);
        }

    }
}

