using _1263087.Data;
using _1263087.Models;
using _1263087.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _1263087.Controllers
{
    public class EmployeeController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(s => s.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Create()
        {           
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeVM employeeVM)
        {
            var employee = _mapper.Map<EmployeeVM, Employee>(employeeVM);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {


            var singleEmployee = await _context.Employees.FindAsync(id);
            var employee = _mapper.Map<Employee, EmployeeVM>(singleEmployee);
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", employee.DepartmentID);

            return View(employee);



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeVM employeeVM, int id)
        {
            var singleEmployee = await _context.Employees.FindAsync(id);
            _mapper.Map(employeeVM, singleEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var singleEmployee = await _context.Employees.FindAsync(id);
            var employee = _mapper.Map<Employee, EmployeeVM>(singleEmployee);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var singleEmployee = await _context.Employees.FindAsync(id);
            _context.Remove(singleEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var singleEmployee = await _context.Employees.FindAsync(id);
            var employee = _mapper.Map<Employee, EmployeeVM>(singleEmployee);
            return View(employee);
        }


    }
}
