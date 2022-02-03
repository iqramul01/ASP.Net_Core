using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _1263087.Data;
using _1263087.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using _1263087.Models.ViewModels;


namespace _1263087.Controllers
{
    public class Staff01Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public Staff01Controller(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            this._context = context;
            this._webHost = webHost;
        }


        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Staffs.Include(s => s.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            StaffVM staffVM = new StaffVM();
            staffVM.Experiences.Add(new Experience() { ExperienceID = 1 });
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            return View(staffVM);
        }

        private string MyImageUpload(Staff staff)
        {
            string uniqueFileName = null;

            if (staff.UploadImage != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Image");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + staff.UploadImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    staff.UploadImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StaffVM staffVM)
        {
            Staff staff = new Staff();
            if (ModelState.IsValid)
            {
                staff.StaffName = staffVM.StaffName;
                staff.ContactAddress = staffVM.ContactAddress;
                staff.EmailAddress = staffVM.EmailAddress;
                staff.ConfirmEmail = staffVM.ConfirmEmail;
                staff.DateOfBirth = staffVM.DateOfBirth;
                staff.Salary = staffVM.Salary;
                staff.Picture = staffVM.Picture;
                staff.DepartmentID = staffVM.DepartmentID;
                staff.UploadImage = staffVM.UploadImage;
                staff.IsActive = staffVM.IsActive;
                staff.Experiences = staffVM.Experiences;

                string uniqueFileName = MyImageUpload(staff);
                staff.Picture = uniqueFileName;

                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(staff);
        }


        public async Task<IActionResult> Details(int id)
        {
            Staff staff = await _context.Staffs
                .Include(q => q.Experiences)
                .Where(d => d.StaffID == id).FirstOrDefaultAsync();

            var staffVM = new StaffVM();

            staffVM.StaffName = staff.StaffName;
            staffVM.ContactAddress = staff.ContactAddress;
            staffVM.EmailAddress = staff.EmailAddress;
            staffVM.ConfirmEmail = staff.ConfirmEmail;
            staffVM.DateOfBirth = staff.DateOfBirth;
            staffVM.Salary = staff.Salary;
            staffVM.Picture = staff.Picture;
            staffVM.DepartmentID = staff.DepartmentID;
            staffVM.UploadImage = staff.UploadImage;
            staffVM.IsActive = staff.IsActive;
            staffVM.Experiences = staff.Experiences;

            return View(staffVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            Staff staff = await _context.Staffs
                  .Include(q => q.Experiences)
                  .Where(d => d.StaffID == id).FirstOrDefaultAsync();
            var staffVM = new StaffVM();
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", staff.DepartmentID);


            staffVM.StaffName = staff.StaffName;
            staffVM.ContactAddress = staff.ContactAddress;
            staffVM.EmailAddress = staff.EmailAddress;
            staffVM.ConfirmEmail = staff.ConfirmEmail;
            staffVM.DateOfBirth = staff.DateOfBirth;
            staffVM.Salary = staff.Salary;
            staffVM.Picture = staff.Picture;
            staffVM.DepartmentID = staff.DepartmentID;
            staffVM.UploadImage = staff.UploadImage;
            staffVM.IsActive = staff.IsActive;
            staffVM.Experiences = staff.Experiences;


            return View(staffVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StaffVM staffVM, int id = 0)
        {
            Staff staff = await _context.Staffs.FindAsync(id);

            if (ModelState.IsValid)
            {
                string uniqueFileName = MyImageUpload(staff);
                staff.Picture = uniqueFileName;


                staff.StaffName = staffVM.StaffName;
                staff.ContactAddress = staffVM.ContactAddress;
                staff.EmailAddress = staffVM.EmailAddress;
                staff.ConfirmEmail = staffVM.ConfirmEmail;
                staff.DateOfBirth = staffVM.DateOfBirth;
                staff.Salary = staffVM.Salary;
                staff.Picture = staffVM.Picture;
                staff.DepartmentID = staffVM.DepartmentID;
                staff.UploadImage = staffVM.UploadImage;
                staff.IsActive = staffVM.IsActive;
                staff.Experiences = staffVM.Experiences;

                _context.Entry(staff).State = EntityState.Modified;
                foreach (var dq in staff.Experiences)
                {
                    _context.Entry(dq).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", staff.DepartmentID);
            return View(staff);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            Staff staff = await _context.Staffs
                  .Include(q => q.Experiences)
                  .Where(d => d.StaffID == id).FirstOrDefaultAsync();
            var staffVM = new StaffVM();
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", staff.DepartmentID);


            staffVM.StaffName = staff.StaffName;
            staffVM.ContactAddress = staff.ContactAddress;
            staffVM.EmailAddress = staff.EmailAddress;
            staffVM.ConfirmEmail = staff.ConfirmEmail;
            staffVM.DateOfBirth = staff.DateOfBirth;
            staffVM.Salary = staff.Salary;
            staffVM.Picture = staff.Picture;
            staffVM.DepartmentID = staff.DepartmentID;
            staffVM.UploadImage = staff.UploadImage;
            staffVM.IsActive = staff.IsActive;
            staffVM.Experiences = staff.Experiences;


            return View(staffVM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffID == id);
        }
    }
}
