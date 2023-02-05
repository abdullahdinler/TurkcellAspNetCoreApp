using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Web.Views.Shared.ViewComponents
{
    public class ProductListViewComponent:ViewComponent
    {
        private readonly Context _context;

        public ProductListViewComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke(int id = 1)
        {
            if (id == 1)
            {
                var values = _context.Products.ToList();
                return View("Default",values);
            }
            else
            {
                var values = _context.Products.Take(3).ToList();
                return View("Siyah",values);
            }
        }
    }
}
