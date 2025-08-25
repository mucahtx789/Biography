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
                PhotoUrl = "images\\profile.jpg",
                About = "Yazýlým geliþtirici olarak eðitim ve hobilerim hakkýnda kýsa bilgi..."
            };
            return View(model);
        }

        public IActionResult Projects()
        {
            var projects = new List<ProjectModel>
    {
                new ProjectModel
        {
            Name = "Anket Uygulamasý",
            Link = "https://github.com/mucahtx789/ankett",
            Description = "Vue.js ile yapýlmýþ anket uygulamasý"
        },
                new ProjectModel
        {
            Name = "Hastane Randevu Sistemi",
            Link = "https://github.com/mucahtx789/Randevu",
            Description = "Kullanýcýlar için randevu almayý ve yönetmeyi saðlayan uygulama."
        },
        new ProjectModel
        {
            Name = "SellPoint",
            Link = "https://github.com/mucahtx789/SellPoint",
            Description = "Alýþveriþ sitesi projesi"
        },
        new ProjectModel
        {
            Name = "Cookie Authentication - .NET 6",
            Link = "https://github.com/mucahtx789/ASPNET-MVC-NET6--Cookie-Auth-2",
            Description = "ASP.NET MVC üzerinde cookie tabanlý oturum yönetimi örneði."
        },
        new ProjectModel
        {
            Name = "Cookie Authentication - .NET 6",
            Link = "https://github.com/mucahtx789/ASPNET-MVC-NET6--Cookie-Auth-2",
            Description = "ASP.NET MVC üzerinde cookie tabanlý oturum yönetimi örneði."
        },
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geliþtirilen emlak ilan yönetim sistemi.."
        }
        ,
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geliþtirilen emlak ilan yönetim sistemi."
        }
        ,
        new ProjectModel
        {
            Name = "Sosyal Medya",
            Link = "https://github.com/mucahtx789/sosyalMedya",
            Description = "Kullanýcý, gönderi, yorum ve beðeni özelliklerine sahip bir sosyal medya platformu."
        }
        ,
        new ProjectModel
        {
            Name = "Görev Takip",
            Link = "https://github.com/mucahtx789/TaskTracker",
            Description = "Kullanýcý görev oluþturma ve takip uygulamasý"
        }
        ,
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geliþtirilen emlak ilan yönetim sistemi.."
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
