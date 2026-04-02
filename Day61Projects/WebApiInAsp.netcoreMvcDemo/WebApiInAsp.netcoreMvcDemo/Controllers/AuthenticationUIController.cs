using Microsoft.AspNetCore.Mvc;

namespace WebApiInAsp.netcoreMvcDemo.Controllers
{
    public class AuthenticationUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
