using codeFirstApproach.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace codeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDBContext studentDBContext;

        public HomeController(StudentDBContext studentDBContext)
        {
            this.studentDBContext = studentDBContext;
        }

        public async Task<IActionResult> Index()  
        {
            var stud = await studentDBContext.Students.ToListAsync();
            return View(stud);
        }

        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                await studentDBContext.Students.AddAsync(std);
                await studentDBContext.SaveChangesAsync();
                TempData["message"] = "Inserted";
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        public async Task<IActionResult> Details(int id)
        {
            var std = await studentDBContext.Students.FirstOrDefaultAsync(x=>x.StudentId==id);
            return View(std);

        }

        public async Task<IActionResult> Edit(int? id)
        {
            var std = await studentDBContext.Students.FindAsync(id);
            return View(std);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id ,Student std)
        {
            if (ModelState.IsValid)
            {
                studentDBContext.Students.Update(std);
                await studentDBContext.SaveChangesAsync();
                TempData["message"] = "Updated";
                return RedirectToAction("Index", "Home");
            }
                return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var std = await studentDBContext.Students.FirstOrDefaultAsync(x => x.StudentId == id);
            return View(std);

        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            var std = await studentDBContext.Students.FindAsync(id);

            if(std != null)
            {
                studentDBContext.Students.Remove(std);
                await studentDBContext.SaveChangesAsync();
                TempData["message"] = "Deleted";
                return RedirectToAction("Index", "Home");
            }
            return View();
           

        }







    }
}

