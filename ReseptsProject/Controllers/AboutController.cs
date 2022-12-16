using Microsoft.AspNetCore.Mvc;

namespace ReseptsProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
