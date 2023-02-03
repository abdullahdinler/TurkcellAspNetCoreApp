using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Helpers;
using AspNetCoreApp.Web.Models;
using AspNetCoreApp.Web.ViewModel;
using AutoMapper;

namespace AspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public ProductController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            string text = "Merhaba Asp.Net Core";
                
            var result = _context.Products.ToList();
            return View(_mapper.Map<List<ProductViewModel>>(result));
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Expert = new Dictionary<String, int>()
            {
                 {"1 Ay",1},
                 {"3 Ay",3},
                 {"6 Ay",6},
                 {"12 Ay",12}
            };
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(_mapper.Map<Product>(product));
                _context.SaveChanges();
                TempData["Alert"] = "Ürün başarılı bir şekilde eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Expert = new Dictionary<String, int>()
                {
                    {"1 Ay",1},
                    {"3 Ay",3},
                    {"6 Ay",6},
                    {"12 Ay",12}
                };
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            TempData["Alert"] = "Ürün başarılı bir şekilde silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            TempData["Alert"] = "Ürün başarılı bir şekilde güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
