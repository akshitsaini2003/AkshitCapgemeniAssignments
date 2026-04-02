using CodeFirstEFInApp.NetCoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CodeFirstEFInApp.NetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EventContext context;

        public HomeController(ILogger<HomeController> logger,EventContext context)
        {
            _logger = logger;
            this.context = context;
        }
        public IActionResult displayEmployee()
        {
            var employees=context.Employees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("displayEmployee");
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee=context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return BadRequest();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            else
            {
                context.Update(employee);
                context.SaveChanges();
                return RedirectToAction("displayEmployee");
            }
            
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return RedirectToAction("displayEmployee");
        }















        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
