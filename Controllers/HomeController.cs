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
                PhotoUrl = "images\\profile.jpg",
                About = "Yaz�l�m geli�tirici olarak e�itim ve hobilerim hakk�nda k�sa bilgi..."
            };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = new List<ProjectModel>
    {
                new ProjectModel
        {
            Name = "Anket Uygulamas�",
            Link = "https://github.com/mucahtx789/ankett",
            Description = "Vue.js ile yap�lm�� anket uygulamas�"
        },
                new ProjectModel
        {
            Name = "Hastane Randevu Sistemi",
            Link = "https://github.com/mucahtx789/Randevu",
            Description = "Kullan�c�lar i�in randevu almay� ve y�netmeyi sa�layan uygulama."
        },
        new ProjectModel
        {
            Name = "SellPoint",
            Link = "https://github.com/mucahtx789/SellPoint",
            Description = "Al��veri� sitesi projesi"
        },
        new ProjectModel
        {
            Name = "Cookie Authentication - .NET 6",
            Link = "https://github.com/mucahtx789/ASPNET-MVC-NET6--Cookie-Auth-2",
            Description = "ASP.NET MVC �zerinde cookie tabanl� oturum y�netimi �rne�i."
        },
        new ProjectModel
        {
            Name = "Cookie Authentication - .NET 6",
            Link = "https://github.com/mucahtx789/ASPNET-MVC-NET6--Cookie-Auth-2",
            Description = "ASP.NET MVC �zerinde cookie tabanl� oturum y�netimi �rne�i."
        },
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geli�tirilen emlak ilan y�netim sistemi.."
        }
        ,
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geli�tirilen emlak ilan y�netim sistemi."
        }
        ,
        new ProjectModel
        {
            Name = "Sosyal Medya",
            Link = "https://github.com/mucahtx789/sosyalMedya",
            Description = "Kullan�c�, g�nderi, yorum ve be�eni �zelliklerine sahip bir sosyal medya platformu."
        }
        ,
        new ProjectModel
        {
            Name = "G�rev Takip",
            Link = "https://github.com/mucahtx789/TaskTracker",
            Description = "Kullan�c� g�rev olu�turma ve takip uygulamas�"
        }
        ,
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geli�tirilen emlak ilan y�netim sistemi.."
        }
    };

            return View(projects);
        }

        public IActionResult Contact()
        {
            return View();
        } 
    }
}
