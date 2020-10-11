using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolAppDBFirst.Models;

namespace SchoolAppDBFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SchoolAppDBFirstContext _dbContext = new SchoolAppDBFirstContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ViewAllStudents()
        {
           var students= _dbContext.Student.ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            var allSchools = _dbContext.School.ToList();
            ViewBag.schools = allSchools;
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student s)
        {
            _dbContext.Add(s);
            _dbContext.SaveChanges();
            return RedirectToAction("ViewAllStudents");
        }
        [HttpGet]
        public IActionResult UpdateStudent()
        {
            var allSchools = _dbContext.School.ToList();
            ViewBag.schools = allSchools;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateStudent(Student s)
        {
            _dbContext.Update(s);
            _dbContext.SaveChanges();
            return RedirectToAction("ViewAllStudents");
        }
        [HttpGet]
        public IActionResult StudentDetails(int id)
        {
            Student s = _dbContext.Student.SingleOrDefault(ss => ss.Id == id);
           
            var schoolId = _dbContext.School.SingleOrDefault(ss => ss.Id == s.SchoolId);
            ViewBag.schoolName = schoolId.SchoolName;
            return View(s);
        }

        [HttpGet]
        public IActionResult DeleteStudent(int studentId)
        {
            Student StId = _dbContext.Student.SingleOrDefault(i => i.Id == studentId);
            if (StId == null)
            {return NotFound();}
            _dbContext.Student.Remove(StId);
            _dbContext.SaveChanges(); 
            return RedirectToAction("ViewAllStudents");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
