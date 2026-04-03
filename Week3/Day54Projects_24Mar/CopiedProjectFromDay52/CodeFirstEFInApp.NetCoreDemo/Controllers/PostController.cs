using Microsoft.AspNetCore.Mvc;

namespace CodeFirstEFInApp.NetCoreDemo.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
