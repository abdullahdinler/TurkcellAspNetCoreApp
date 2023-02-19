using AspNetCoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Filters;
using AspNetCoreApp.Web.ViewModel;
using AutoMapper;

namespace AspNetCoreApp.Web.Controllers
{
    [LogFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Context _context;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, Context context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var model = _context.Products.ToList();
            ViewBag.ProductList = _mapper.Map<List<ProductViewModel>>(model);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Visitor()
        {
            return View();
        }


        [HttpPost]
        public IActionResult VisitorAdded(VisitorViewModel visitor)
        {
            try
            {
                var model = _mapper.Map<Visitor>(visitor);
                model.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString()); 
                _context.Visitors.Add(model);
                _context.SaveChanges();
                TempData["Alert"] = "Yorum başarılı bir şekilde yapıldı.";
                return RedirectToAction(nameof(HomeController.Visitor));
            }
            catch (Exception e)
            {
                TempData["Alert"] = "Yorum yapılırken bir hata oluştu. Lütfen daha sonra tekrar deneyin";
                return RedirectToAction(nameof(HomeController.Visitor));
            }
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            errorViewModel.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View(errorViewModel);
        }
    }
}
