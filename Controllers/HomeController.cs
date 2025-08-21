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
                FullName = "M�cahit Demir",
                PhotoUrl = "/images/profile.jpg",
                About = "Yaz�l�m geli�tirici olarak e�itim ve hobilerim hakk�nda k�sa bilgi..."
            };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = new List<(string Name, string Link, string Description)>
        {
            ("SellPoint", "https://github.com/mucahtx789/SellPoint", "Al��veri� sitesi projesi"),
            ("Anket Uygulamas�", "https://github.com/mucahtx789/AnketUygulamasi", "Vue.js ile yap�lm�� anket uygulamas�")
            // �stedi�in kadar ekleyebilirsin
        };
            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
