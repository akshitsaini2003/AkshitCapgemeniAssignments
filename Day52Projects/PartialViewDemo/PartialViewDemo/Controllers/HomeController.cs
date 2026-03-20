using Microsoft.AspNetCore.Mvc;
using PartialViewDemo.Models;
using System.Diagnostics;

namespace PartialViewDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }


        Employee emp = new Employee()
        {
            EmpId = 102,
            EmpName = "Rohit Sharma",
            Email = "rohit.sharma@company.com",
            Description = "Senior Software Engineer with over 5 years of experience in designing and developing enterprise applications using .NET technologies. Skilled in microservices architecture, RESTful APIs, and cloud integration. Strong leadership qualities with experience in mentoring junior developers."
        };
        public IActionResult DisplayEmployee()
        {
            return View(emp);
        }



        public ActionResult DisplayAllEmp()
        {
            List<Employee> emplist = new List<Employee>()
    {
        new Employee{
            EmpId=101,
            EmpName="Raghavendra Ponde",
            Email="raghav.ponde@techsolutions.com",
            Description="Experienced freelance technical trainer specializing in .NET technologies, cloud computing, and enterprise application development. Has trained over 500+ students and professionals with a focus on real-world project implementation."
        },

        new Employee{
            EmpId=102,
            EmpName="Suresh Kumar",
            Email="suresh.kumar@innovatex.com",
            Description="Backend developer with 4+ years of experience in ASP.NET Core and SQL Server. Skilled in building scalable REST APIs and optimizing database performance for high-traffic applications."
        },

        new Employee{
            EmpId=103,
            EmpName="Kiran Patel",
            Email="kiran.patel@webworks.com",
            Description="Frontend developer passionate about creating responsive and user-friendly web interfaces using HTML, CSS, JavaScript, and modern frameworks like Angular and React."
        },

        new Employee{
            EmpId=104,
            EmpName="Mahesh Verma",
            Email="mahesh.verma@cloudsync.com",
            Description="DevOps engineer with expertise in CI/CD pipelines, Docker, and Azure cloud services. Focused on automating deployment processes and ensuring high availability of applications."
        },

        new Employee{
            EmpId=105,
            EmpName="Neha Sharma",
            Email="neha.sharma@hrconnect.com",
            Description="Human Resources specialist with experience in recruitment, employee engagement, and performance management. Strong interpersonal skills and a people-first approach."
        },

        new Employee{
            EmpId=106,
            EmpName="Amit Singh",
            Email="amit.singh@datasphere.com",
            Description="Data analyst skilled in data visualization, SQL, and Power BI. Helps organizations make data-driven decisions by analyzing trends and creating insightful dashboards."
        },

        new Employee{
            EmpId=107,
            EmpName="Priya Mehta",
            Email="priya.mehta@fintechlabs.com",
            Description="Software engineer with a strong foundation in object-oriented programming and microservices architecture. Passionate about building secure and high-performance financial applications."
        }
    };

            return View(emplist);
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
