using _1263087.Data;
using _1263087.Models;
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
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHost;

        public DoctorController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            this._context = context;
            this._webHost = webHost;
        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctors.Include(d => d.Department);
            return View(await applicationDbContext.ToListAsync());

        }
        [HttpGet]
        public IActionResult Create()
        {
            Doctor doctor = new Doctor();
            doctor.DoctorQualifications.Add(new DoctorQualification() { QualificationID = 1 }); 
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = MyImageUpload(doctor);
                doctor.Picture = uniqueFileName;

                _context.Add(doctor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Doctor doctor = await _context.Doctors
                .Include(q => q.DoctorQualifications)
                .Where(d => d.DoctorID == Id).FirstOrDefaultAsync();

            if(doctor==null)
            {
                return NotFound();
            }
            
            ViewBag.DepartmentID = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", doctor.DepartmentID);

            return View(doctor);
        }
        private string MyImageUpload(Doctor doctor)
        {
            string uniqueFileName = null;

            if (doctor.UploadImage != null)
            {
                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Image/");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + doctor.UploadImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    doctor.UploadImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                
                    string uniqueFileName = MyImageUpload(doctor);
                    doctor.Picture = uniqueFileName;


                foreach (var dq in doctor.DoctorQualifications)
                {
                    _context.Entry(dq).State = EntityState.Modified;
                }
                _context.Entry(doctor).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            ViewBag.DepartmentID = new SelectList(_context.Departments, "DepartmentID", "DepartmentName", doctor.DepartmentID);

            return View(doctor);
        }



        public async Task<IActionResult> Details(int Id)
        {
            Doctor doctor = await _context.Doctors
                .Include(q => q.DoctorQualifications)
                .Where(d => d.DoctorID == Id).FirstOrDefaultAsync();

            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            Doctor doctor = await _context.Doctors
                .Include(q => q.DoctorQualifications)
                .Where(d => d.DoctorID == Id).FirstOrDefaultAsync();

            return View(doctor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Doctor doctor)
        {
            _context.Attach(doctor);
            _context.Entry(doctor).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


       

    }
}
