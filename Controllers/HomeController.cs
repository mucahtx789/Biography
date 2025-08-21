using System.Diagnostics;
using Biography.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biography.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new BiographyM
            {
                FullName = "Mücahit Demir",
                PhotoUrl = "/images/profile.jpg",
                About = "Yazýlým geliþtirici olarak eðitim ve hobilerim hakkýnda kýsa bilgi..."
            };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = new List<(string Name, string Link, string Description)>
        {
            ("SellPoint", "https://github.com/mucahtx789/SellPoint", "Alýþveriþ sitesi projesi"),
            ("Anket Uygulamasý", "https://github.com/mucahtx789/AnketUygulamasi", "Vue.js ile yapýlmýþ anket uygulamasý")
            // Ýstediðin kadar ekleyebilirsin
        };
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
