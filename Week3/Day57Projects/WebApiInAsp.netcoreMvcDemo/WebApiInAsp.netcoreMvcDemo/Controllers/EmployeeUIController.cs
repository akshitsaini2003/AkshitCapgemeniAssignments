using Microsoft.AspNetCore.Mvc;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    public class EmployeeUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
