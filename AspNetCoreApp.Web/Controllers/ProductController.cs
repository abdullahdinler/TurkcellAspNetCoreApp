using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Models;

namespace AspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private Context c = new Context();

        public IActionResult Index()
        {
           var result =  c.Products.ToList();
            return View(result);
        }
    }
}
