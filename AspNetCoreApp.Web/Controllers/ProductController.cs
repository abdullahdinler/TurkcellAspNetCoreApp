using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly Context _c = new Context();

       
        public IActionResult Index()
        {
            var result = _c.Products.ToList();
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

            _c.Products.Add(product);
            _c.SaveChanges();
            TempData["Alert"] = "Ürün başarılı bir şekilde eklendi";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _c.Products.Find(id);
            _c.Products.Remove(product);
            TempData["Alert"] = "Ürün başarılı bir şekilde silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _c.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Product product)
        {
            _c.Products.Update(product);
            _c.SaveChanges();
            TempData["Alert"] = "Ürün başarılı bir şekilde güncellendi.";
            return RedirectToAction("Index");
        }
    }
}
