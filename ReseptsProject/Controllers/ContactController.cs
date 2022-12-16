using Microsoft.AspNetCore.Mvc;

namespace ReseptsProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
