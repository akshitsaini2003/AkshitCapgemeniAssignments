using Microsoft.AspNetCore.Mvc;
using RoutingCGDemo.Models;

namespace RoutingCGDemo.Controllers
{
    public class StudentController : Controller
    {
        List<Student> studList = new List<Student>()
        {
            new Student{ Id=1, Name="Aman Sharma", Class="B.Tech CSE 3rd Year" },
            new Student{ Id=2, Name="Rohit Kumar", Class="B.Tech IT 2nd Year" },
            new Student{ Id=3, Name="Neha Verma", Class="BCA 1st Year" },
            new Student{ Id=4, Name="Priya Singh", Class="B.Tech CSE 4th Year" },
            new Student{ Id=5, Name="Karan Mehta", Class="MCA 2nd Year" },
            new Student{ Id=6, Name="Simran Kaur", Class="B.Tech ECE 3rd Year" },
            new Student{ Id=7, Name="Rahul Gupta", Class="BCA 2nd Year" },
            new Student{ Id=8, Name="Anjali Sharma", Class="B.Tech CSE 1st Year" },
            new Student{ Id=9, Name="Vikas Yadav", Class="B.Tech ME 4th Year" },
            new Student{ Id=10, Name="Pooja Verma", Class="MCA 1st Year" },
            new Student{ Id=11, Name="Deepak Singh", Class="B.Tech Civil 3rd Year" },
            new Student{ Id=12, Name="Sneha Patel", Class="BCA 3rd Year" },
            new Student{ Id=13, Name="Arjun Malhotra", Class="B.Tech CSE 2nd Year" },
            new Student{ Id=14, Name="Mehak Jain", Class="BBA 2nd Year" },
            new Student{ Id=15, Name="Nikhil Arora", Class="B.Tech IT 4th Year" }
        };
        [Route("studs")]
        public IActionResult GetAllStudents()
        {

            return View(studList);
        }
        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = studList.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [Route("few")]
        public IActionResult fewColumns()
        {
            var fewCol = studList.Select(x => new Student
            {
                Class=x.Class,
                Name=x.Name
            });
            return View(fewCol);
        }
    }
}
