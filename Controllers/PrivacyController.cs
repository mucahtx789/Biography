using Microsoft.AspNetCore.Mvc;

namespace Biography.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
