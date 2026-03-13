using Microsoft.AspNetCore.Mvc;
using MVCExampleDemo.Models;
using System.Diagnostics;

namespace MVCExampleDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string sampleDemo1()
        {
            return "Akshit Saini";
        }

        public string sampleDemo2(int age,string name)
        {
            return $"The name is {name} and having age {age}";
        }

        public IActionResult sampleDemo3()
        {
            int age = 22;
            string name = "Akshit saini";
            ViewBag.name = name;
            ViewBag.age = age;

            ViewData["Message"] = "Welcome to Asp.Net Core Learning";
            ViewData["Year"]=DateTime.Now.Year;
            return View();
        }

        Employee obj = new Employee()
        {
            EmployeeId = 1,
            EmployeeName = "Akshit Saini",
            EmpSalary = 25000
        };
        public IActionResult singleObjectPassing()
        {
           return View(obj);
        }

        List<Employee> empList=new List<Employee>()
        {
            new Employee{EmployeeId=102,EmployeeName="Vaibhav",EmpSalary=50000,ImageUrl="/images/empCollection/apple.jpg" ,DeptId=10},
            new Employee{EmployeeId=103,EmployeeName="Anshul",EmpSalary=60000,ImageUrl="/images/empCollection/cold_drink.webp" ,DeptId=10},
            new Employee{EmployeeId=104,EmployeeName="Himanshu",EmpSalary=40000,ImageUrl="/images/empCollection/rice.webp" ,DeptId=20},
            new Employee{EmployeeId=105,EmployeeName="Samar",EmpSalary=45000,ImageUrl="/images/empCollection/roti.webp" ,DeptId=30},
            new Employee{EmployeeId=106,EmployeeName="Akshit",EmpSalary=55000,ImageUrl="/images/empCollection/urad_dal.webp" ,DeptId=20},
        };
        List<Dept> deptlist = new List<Dept>()
        {
         new Dept {DeptId=10,DeptName="Sales"},

         new Dept {DeptId=20,DeptName="HR"},

         new Dept {DeptId=30,DeptName="Software"}
        };
        public IActionResult collectionOfDept()
        {
            return View(deptlist);
        }

        public IActionResult EmpsInDept(int deptId)
        {
            var employees=empList.Where(x=>x.DeptId==deptId).ToList();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee=empList.FirstOrDefault(e=>e.EmployeeId== id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult SearchEmp(int empId)
        {
            Employee emp=(from e1 in empList where e1.EmployeeId == empId select e1).FirstOrDefault();
            if (emp == null)
            {
                return NotFound(); 
            }
            return View(emp);
        }

        public IActionResult CollectionOfObjectPassing()
        {
            return View(empList);
        }

        public IActionResult display()
        {
            return View();
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




        //Department Controller Work
       

        //public IActionResult MixedObjectPassing(int empId)
        //{
        //    var query1=deptlist.ToList();
        //    Employee emp=empList.Where(x=>x.EmployeeId==empId).FirstOrDefault();

        //    var query2 = emp;
        //    return View(query1, query2);
        //}

        public IActionResult MixedObjectPassing(int empId)
        {
            var query1 = deptlist.ToList();
            Employee emp = empList.Where(x => x.EmployeeId == empId).FirstOrDefault();

            var query2 = emp;

            EmpDeptViewModel obj=new EmpDeptViewModel()
            {
                deptList=query1,
                emp=query2,
                date=DateTime.Now
            };

            return View(obj);
        }









    }
}
