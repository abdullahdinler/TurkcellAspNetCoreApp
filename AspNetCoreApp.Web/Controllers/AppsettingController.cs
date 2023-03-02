using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreApp.Web.Controllers
{
    public class AppsettingController : Controller
    {
        // Appsettings.json sayfasından veri cekme işlemi yapıldı
        private readonly IConfiguration _configuration;

        public AppsettingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var baseUrlOne = _configuration["baseUrl:one"];
            var baseUrlTwo = _configuration.GetSection("baseUrl")["Two"];
            ViewBag.BaseUrl = baseUrlOne;
            ViewBag.BaseUrlTwo = baseUrlTwo;
            return View();
        }
    }
}
