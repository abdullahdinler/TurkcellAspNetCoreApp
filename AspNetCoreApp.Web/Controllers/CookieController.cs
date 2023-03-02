using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Web.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult CookieCreate()
        {
            // Burada kendi cookie mizi oluşturduk 
            HttpContext.Response.Cookies.Append("backgorund-color","red", new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(1)
            });
            return View();
        }

        public IActionResult CookieRead()
        {
            // burada oluşturulan cookie okuma işlemi yapıldı
          var backgorundColor =  HttpContext.Request.Cookies["backgorund-color"];
          ViewBag.Back = backgorundColor;
          return View();
        }
    }
}
