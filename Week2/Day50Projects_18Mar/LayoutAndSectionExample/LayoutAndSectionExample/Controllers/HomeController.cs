using Microsoft.AspNetCore.Mvc;
using LayoutAndSectionExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace LayoutAndSectionExample.Controllers
{
    public class HomeController : Controller
    {
        // Temporary data store - in real app ye database se aayega
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, EmpName = "Rajesh Kumar", salary = 85000 },
            new Employee { EmployeeID = 2, EmpName = "Priya Sharma", salary = 75000 },
            new Employee { EmployeeID = 3, EmpName = "Amit Patel", salary = 65000 },
            new Employee { EmployeeID = 4, EmpName = "Neha Gupta", salary = 70000 },
            new Employee { EmployeeID = 5, EmpName = "Vikram Singh", salary = 90000 }
        };

        private static List<Department> departments = new List<Department>
        {
            new Department { DeptID = 1, DeptName = "IT" },
            new Department { DeptID = 2, DeptName = "HR" },
            new Department { DeptID = 3, DeptName = "Finance" },
            new Department { DeptID = 4, DeptName = "Marketing" }
        };

        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            ViewData["PageIcon"] = "chart-line";

            // Calculate statistics
            int totalEmployees = employees.Count;
            int totalDepartments = departments.Count;
            int activeEmployees = employees.Count(e => e.salary > 0); // Assuming all are active
            double averageSalary = employees.Any() ? employees.Average(e => e.salary) : 0;

            // Store in ViewBag
            ViewBag.TotalEmployees = totalEmployees;
            ViewBag.TotalDepartments = totalDepartments;
            ViewBag.ActiveEmployees = activeEmployees;
            ViewBag.AverageSalary = averageSalary;

            // Recent employees for display
            ViewBag.RecentEmployees = employees.OrderByDescending(e => e.EmployeeID).Take(3).ToList();

            // Department distribution
            var deptDistribution = new Dictionary<string, int>
            {
                { "IT", employees.Count(e => e.EmployeeID <= 2) }, // Sample distribution
                { "HR", employees.Count(e => e.EmployeeID > 2 && e.EmployeeID <= 4) },
                { "Finance", employees.Count(e => e.EmployeeID == 5) }
            };
            ViewBag.DeptDistribution = deptDistribution;

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Policy";
            ViewData["PageIcon"] = "lock";
            ViewData["Breadcrumb"] = "<li class='breadcrumb-item'><a href='/'>Home</a></li><li class='breadcrumb-item active'>Privacy</li>";

            return View();
        }
    }
}