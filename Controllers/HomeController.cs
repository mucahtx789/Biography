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
                PhotoUrl = "images/profile.jpg",
                About = "Yazılım geliştirici olarak eğitim ve hobilerim hakkında kısa bilgi..."
            };

            var projects = new List<ProjectModel>
    {
                new ProjectModel
        {
            Name = "SilentWingstr site",
            Link = "https://www.silentwingstr.com",
            Description = "Drone ve Teknoloji hakkında  yapmış olduğum site"
        },
                new ProjectModel
        {
            Name = "Anket Uygulaması",
            Link = "https://github.com/mucahtx789/ankett",
            Description = "Vue.js ile yapılmış anket uygulaması"
        },
                new ProjectModel
        {
            Name = "Hastane Randevu Sistemi",
            Link = "https://github.com/mucahtx789/Randevu",
            Description = "Kullanıcılar için randevu almayı ve yönetmeyi sağlayan uygulama."
        },
        new ProjectModel
        {
            Name = "SellPoint",
            Link = "https://github.com/mucahtx789/SellPoint",
            Description = "Alışveriş sitesi projesi"
        },
        new ProjectModel
        {
            Name = "Cookie Authentication - .NET 6",
            Link = "https://github.com/mucahtx789/ASPNET-MVC-NET6--Cookie-Auth-2",
            Description = "ASP.NET MVC üzerinde cookie tabanlı oturum yönetimi örneği."
        },
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geliştirilen emlak ilan yönetim sistemi.."
        },
        
        new ProjectModel
        {
            Name = "Sosyal Medya",
            Link = "https://github.com/mucahtx789/sosyalMedya",
            Description = "Küçük sosyal medya platformu."
        }
        ,
        new ProjectModel
        {
            Name = "Görev Takip",
            Link = "https://github.com/mucahtx789/TaskTracker",
            Description = "Kullanıcı görev oluşturna ve takip uygulaması"
        }
        ,
        new ProjectModel
        {
            Name = "Emlak",
            Link = "https://github.com/mucahtx789/Emlak",
            Description = "ASP.NET Core ve Entity Framework ile geliþtirilen emlak ilan yönetim sistemi.."
        }
    };

            ViewBag.Projects = projects; 
            return View(model);
        }
    }
}
