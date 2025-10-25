using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Biography.Controllers
{
    public class SitemapController : Controller
    {
        
        [Route("sitemap.xml")]
        public IActionResult Index()
        {
            Response.ContentType = "application/xml";

            // Sitemap namespace
            XNamespace ns = "https://www.sitemaps.org/schemas/sitemap/0.9";

            // URL seti
            var urlset = new XElement(ns + "urlset",
                // Ana sayfa
                new XElement(ns + "url",
                    new XElement(ns + "loc", "http://mucahitd.com.tr/"),
                    new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                    new XElement(ns + "changefreq", "daily"),
                    new XElement(ns + "priority", "1.0")
                ),
                
                // Privacy sayfası
                new XElement(ns + "url",
                    new XElement(ns + "loc", "http://mucahitd.com.tr/Privacy"),
                    new XElement(ns + "lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd")),
                    new XElement(ns + "changefreq", "monthly"),
                    new XElement(ns + "priority", "0.5")
                )
            );

            var sitemap = new XDocument(urlset);

            return Content(sitemap.ToString(), "application/xml");
        }
    }
}
