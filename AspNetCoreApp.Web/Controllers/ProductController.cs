using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Helpers;
using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private  Context _context;

        private IHelper _helper;
        public ProductController(IHelper helper, Context context)
        {
            _helper = helper;
            _context = context;
        }
       
        public IActionResult Index()
        {
            string text = "Merhaba Asp.Net Core";
            var values = _helper.Upper(text);
                
            var result = _context.Products.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {

            _context.Products.Add(product);
            _context.SaveChanges();
            TempData["Alert"] = "Ürün başarılı bir şekilde eklendi";
            return RedirectToAction("Index");
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
